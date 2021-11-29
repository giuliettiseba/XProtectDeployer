using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using XProtectDeployer.Utils;

namespace XProtectDeployer
{
    public partial class Form1 : Form
    {
        // Join the dark theme 
        readonly Color TEXTBACKCOLOR = ColorTranslator.FromHtml("#252526");
        readonly Color BACKCOLOR = ColorTranslator.FromHtml("#2D2D30");
        readonly Color INFOCOLOR = ColorTranslator.FromHtml("#1E7AD4");
        readonly Color MESSAGECOLOR = ColorTranslator.FromHtml("#86A95A");
        readonly Color DEBUGCOLOR = ColorTranslator.FromHtml("#DCDCAA");
        readonly Color ERRORCOLOR = ColorTranslator.FromHtml("#B0572C");


        private static String REMOTEFOLDER = @"C:\ProgramData\Milestone\XProtectDeployer";
        private static String REMOTESHARENAME = "XProtectDeployer";


        BindingList<KeyValuePair<string, string>> installers_List = new BindingList<KeyValuePair<string, string>>();
        BindingList<KeyValuePair<string, string>> selected_installers_List = new BindingList<KeyValuePair<string, string>>();

        public Form1()
        {
            
            //var script = FetchScript("Register-VmsServer.txt");

            InitializeComponent();

            this.textBox_Console.BackColor = TEXTBACKCOLOR;
            this.BackColor = BACKCOLOR;
            this.groupBox1.BackColor = BACKCOLOR;
            this.groupBox2.BackColor = BACKCOLOR;
            TestParameters();
        }

        private void TestParameters()
        {
            textBox_address.Text = "10.1.0.20";
            textBox_domain.Text = "MEX-LAB";
            textBox_user.Text = "SGIU";
            textBox_password.Text = "Milestone1$";
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            foreach (var file in GetDownloadManagerFiles())
            {
                installers_List.Add(new KeyValuePair<string, string>(file, Path.GetFileName(file)));
            }
            listBox_Installers.Sorted = true;
            //listBox_Selected_Installers.Sorted = true;

            listBox_Installers.DataSource = installers_List;
            listBox_Installers.ValueMember = "Key";
            listBox_Installers.DisplayMember = "Value";

            listBox_Selected_Installers.DataSource = selected_installers_List;
            listBox_Selected_Installers.ValueMember = "Key";
            listBox_Selected_Installers.DisplayMember = "Value";

            textBox_ManagementServer.Text = NetworkTools.GetHostname();
            if (selected_installers_List.Count == 0) button_remove.Enabled = false;
        }


        private string[] GetDownloadManagerFiles()
        {
            string downloadManagerPath = GetDownloadManagerPath();
            if (downloadManagerPath != null)
            {
                string[] filesToRemove = new string[2] { "SSCMManager.exe", "SSCMRegister.exe" };

                if (Directory.Exists(downloadManagerPath))
                {
                    string[] files = Directory.GetFiles(downloadManagerPath, "*.exe", SearchOption.AllDirectories).Where(val => !filesToRemove.Contains(Path.GetFileName(val))).ToArray(); ;
                    return files;
                }
            }
            return new string[0];
        }

        private string GetDownloadManagerPath()
        {

            try
            {
                using (RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\WOW6432Node\VideoOS\SSCM"))
                {
                    if (key != null)
                    {
                        Object o = key.GetValue("InstalledPath");
                        if (o != null)
                        {
                            String path = o as String;
                            return path;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                WriteInConsole(ex.Message, LogType.error);
            }
            return null;
        }

        private void button_LoadLocalInstaller_Click(object sender, EventArgs e)
        {
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "Installer Executable (*.exe)|*.exe|Installer Executable (*.msi)|*.msi|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;
                    installers_List.Add(new KeyValuePair<string, string>(filePath, Path.GetFileName(filePath)));

                }
            }
        

        }

        private void button_insert_Click(object sender, EventArgs e)
        {
            KeyValuePair<string, string> selectedItem = (KeyValuePair<string, string>)listBox_Installers.SelectedItem;
            InsertFile(selectedItem.Key);
            button_insert.Enabled = false;
            if (selected_installers_List.Count > 0) button_remove.Enabled = true;
        }


        private void button_remove_Click(object sender, EventArgs e)
        {
            KeyValuePair<string, string> selectedItem = (KeyValuePair<string, string>)listBox_Selected_Installers.SelectedItem;
            RemoveFile(selectedItem.Key);
            button_insert.Enabled = true;
            if (selected_installers_List.Count == 0) button_remove.Enabled = false;
        }

        private void InsertFile(string selectedItem)
        {
            KeyValuePair<string, string> ítem = installers_List.First(e => e.Key == selectedItem);
            installers_List.Remove(ítem);
            selected_installers_List.Add(ítem);
        }

        private void RemoveFile(string selectedItem)
        {
            KeyValuePair<string, string> ítem = selected_installers_List.First(e => e.Key == selectedItem);
            selected_installers_List.Remove(ítem);
            installers_List.Add(ítem);
        }



        private void button_deploy_Click(object sender, EventArgs e)
        {
            StartDeploy();
        }

        private void StartDeploy()
        {

            foreach (var item in selected_installers_List)
            {
                var listOfTasks = new List<Task>();

                foreach (DataGridViewRow row in workstations_dataGridView.Rows)
                {
                    WorkstationInfo workstationInfo = new WorkstationInfo()
                    {
                        Address = NetworkTools.ResolveHostNametoIP(row.Cells["address"].Value.ToString()),
                        Domain = row.Cells["domain"].Value.ToString(),
                        User = row.Cells["user"].Value.ToString(),
                        Password = row.Cells["password"].Value.ToString(),
                    };

                    string parameters = "";
                    if (item.Value.Contains("RecordingServer"))
                    {
                        var hostname = textBox_ManagementServer.Text;
                        parameters = $" --parameters=SERVERHOSTNAME:{hostname}:CONNECTEDTOSERVER:false";
                    }

                    parameters += $" {textBox_silentInstallParameter.Text}";
                    listOfTasks.Add(new Task(() => CallInstaller(workstationInfo, item.Key, parameters)));   /// The call to start the remothe algoritm 
                }

                int _maxDegreeOfParallelism = (int)numericUpDown_MaxDegreeOfParallelism.Value;

                Task tasks = StartAndWaitAllThrottledAsync(listOfTasks, _maxDegreeOfParallelism, -1).ContinueWith(result =>
                {
                    WriteInConsole("Task(s) completed", LogType.message);
                });
            }
        }

        /// <summary>
        /// To intall the Device pack the steps are
        /// Identify if the installation will be performed locally or remote
        /// If is local just execute the file
        /// If remotely:
        /// 1) establish a connection with the WMI scope.
        /// 2) Create a folder in the remote server
        /// 3) Share the remote folder (public) 
        /// 4) Copy the file (public) -> todo: use impersonating, then the folder doesn't need to be public
        /// 5) Executhe the installation file 
        /// 6) Unshare the folder
        /// 7) Delete the folder
        /// </summary>
        /// <param name="workstationInfo"></param>
        /// <param name="file"></param>
        private void CallInstaller(WorkstationInfo workstationInfo, string file, string parameters)
        {

            if (NetworkTools.IsLocalServer(workstationInfo.Address))
            {
                ManagementScope scope = new ManagementScope(@"\\LOCALHOST\root\cimv2");
                ExecuteFile(workstationInfo, scope, file, parameters);
            }
            else
            {
                ManagementScope scope = NetworkTools.EstablishConnection(workstationInfo);
                var file_name = Path.GetFileName(file);
                CreateRemoteFolder(workstationInfo, scope);
                ShareRemoteFolder(workstationInfo, scope);
                CopyFile(workstationInfo, file);

                ExecuteFile(workstationInfo, scope, REMOTEFOLDER + "\\" + file_name, parameters);
                if (Path.GetFileName(file).Contains("RecordingServer"))                 /// Extend this as necesary 
                {
                    RegisterService(workstationInfo, NetworkTools.GetHostname());
                    StartService(workstationInfo, scope, "Milestone XProtect Recording Server");
                }
                UnshareRemoteFolder(workstationInfo, scope);
                DeleteRemoteFolder(workstationInfo, scope);
            }
        }

        private void StartService(WorkstationInfo workstationInfo, ManagementScope scope, string serviceName)
        {
            SelectQuery query = new SelectQuery("select * from Win32_Service where name = '" + serviceName + "'");
            using (ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query))
            {
                ManagementObjectCollection collection = searcher.Get();
                foreach (ManagementObject service in collection.OfType<ManagementObject>())
                {
                    if (service.Properties["State"].Value.Equals("Stopped"))
                        service.InvokeMethod("StartService", null);
                }
            }
        }


        private void RegisterService(WorkstationInfo workstationInfo, string hostname)
        {

            WriteInConsole("Register Service", LogType.info);

            // create Powershell runspace

            Runspace runspace = RunspaceFactory.CreateRunspace();

            // open it

            runspace.Open();

            // create a pipeline and feed it the script text


            PowerShell ps = PowerShell.Create();


            //var script = File.ReadAllText(@".\Resources\Register-VmsServer.ps1"

            var script = FetchScript("Register-VmsServer.txt");
            ps.AddScript(script, true) ;

            ps.AddParameter(workstationInfo.Address);
            ps.AddParameter($"{workstationInfo.Domain}\\{workstationInfo.User}");
            ps.AddParameter(workstationInfo.Password);
            ps.AddParameter(hostname);

            var results = ps.Invoke();

            if (ps.HadErrors)
            {

                foreach (var error in ps.Streams.Error)
                {
                    WriteInConsole(error.Exception.Message, LogType.error);
                }

            }

            foreach (PSObject obj in results)
            {

                WriteInConsole(obj.ToString(), LogType.debug);
            }

            WriteInConsole("Register Service. Completed.", LogType.info);
        }



        /////////////////////////////////
        // REMOTE LOGIC IMPLEMENTATION //
        /////////////////////////////////


        /// <summary>
        /// Create the folder 
        /// </summary>
        /// <param name="workstationInfo"></param>
        /// <param name="theScope"></param>

        private void CreateRemoteFolder(WorkstationInfo workstationInfo, ManagementScope theScope)
        {
            try
            {


                WriteInConsole("Creating Share Folder " + workstationInfo.Address, LogType.info);
                var Win32_Process_Class = new ManagementClass(theScope, new ManagementPath("Win32_Process"), new ObjectGetOptions());
                object[] cmdMdTemp = { "cmd.exe /c md " + REMOTEFOLDER };
                var mdResult = Win32_Process_Class.InvokeMethod("Create", cmdMdTemp);
                WriteInConsole("Create Share Folder " + CodeToStringConverters.ErrorCodeToString(Convert.ToInt32(mdResult)), LogType.info);
                Thread.Sleep(2000);  /// I hate this method, using cmd to create the folder is not nice, 


            }
            catch (Exception e)
            {
                WriteInConsole(e.Message, LogType.error);


            }
        }

        /// <summary>
        /// Share the folder 
        /// </summary>
        /// <param name="workstationInfo"></param>
        /// <param name="theScope"></param>
        private void ShareRemoteFolder(WorkstationInfo workstationInfo, ManagementScope theScope)
        {
            try
            {
                WriteInConsole("Sharing Folder " + workstationInfo.Address, LogType.info);
                var winShareClass = new ManagementClass(theScope, new ManagementPath("Win32_Share"), new ObjectGetOptions());
                ManagementBaseObject shareParams = NetworkTools.SetShareParams(winShareClass, REMOTEFOLDER, REMOTESHARENAME);
                var outParams = winShareClass.InvokeMethod("Create", shareParams, null);
                WriteInConsole("Share Folder " + CodeToStringConverters.ShareFolderErrorCodeToString(Convert.ToInt32(outParams.Properties["ReturnValue"].Value)), LogType.info);
            }
            catch (Exception e)
            {
                WriteInConsole(e.Message, LogType.error);
            }
        }

        /// <summary>
        /// Copy the hotfix
        /// </summary>
        /// <param name="workstationInfo"></param>
        /// <param name="file"></param>
        private void CopyFile(WorkstationInfo workstationInfo, string srcFile)
        {
            try
            {
                string shareFolder = @"\\" + workstationInfo.Address + "\\" + REMOTESHARENAME;

                var file_name = Path.GetFileName(srcFile);
                WriteInConsole("Copying file: " + srcFile + @" to " + shareFolder + "\\" + file_name, LogType.info);

                NetworkShare.DisconnectFromShare(shareFolder, true); //Disconnect in case we are currently connected with our credentials;
                NetworkShare.ConnectToShare(shareFolder, workstationInfo.Domain + "\\" + workstationInfo.User, workstationInfo.Password); //Connect with the new credentials

                File.Copy(srcFile, shareFolder + "\\" + file_name);

                NetworkShare.DisconnectFromShare(shareFolder, false); //Disconnect from the server.
                WriteInConsole("File Copied", LogType.info);
            }
            catch (System.IO.IOException ex)
            {
                WriteInConsole(ex.Message, LogType.error);
            }
        }

        /// <summary>
        /// Execute the file
        /// </summary>
        /// <param name="workstationInfo"></param>
        /// <param name="theScope"></param>
        /// <param name="file"></param>
        /// <param name="args"></param>
        private void ExecuteFile(WorkstationInfo workstationInfo, ManagementScope theScope, string file, string args)
        {
            WriteInConsole("Executing Installer on server " + workstationInfo.Address, LogType.info);

            object[] theProcessToRun = { file + args, null, null, 0 };

            ManagementClass theClass = new ManagementClass(theScope, new ManagementPath("Win32_Process"), new ObjectGetOptions());

            try
            {
                var output = theClass.InvokeMethod("Create", theProcessToRun);
                Thread.Sleep(1000);

                String ProcID = theProcessToRun[3].ToString();

                WriteInConsole("Execute Installer on server " + workstationInfo.Address + ": " + CodeToStringConverters.ErrorCodeToString(Convert.ToInt32(output)), LogType.info);

                WriteInConsole("PID on server  " + workstationInfo.Address + ": " + ProcID, LogType.debug);


                WqlEventQuery wQuery = new WqlEventQuery("Select * From __InstanceDeletionEvent Within 1 Where TargetInstance ISA 'Win32_Process'");

                using (ManagementEventWatcher wWatcher = new ManagementEventWatcher(theScope, wQuery))
                {
                    bool stopped = false;

                    WriteInConsole("Installing " + Path.GetFileName(file) + " on server: " + workstationInfo.Address, LogType.message);

                    while (stopped == false)
                    {
                        using (ManagementBaseObject MBOobj = wWatcher.WaitForNextEvent())
                        {
                            if (((ManagementBaseObject)MBOobj["TargetInstance"])["ProcessID"].ToString() == ProcID)
                            {
                                // the process has stopped
                                stopped = true;
                                WriteInConsole("Installation Process Finished on server: " + workstationInfo.Address, LogType.message);
                                // Install Finish 
                            }
                        }
                    }
                    wWatcher.Stop();
                }
            }
            catch (Exception ex)
            {
                WriteInConsole(ex.Message, LogType.error);
            }

        }


        /// <summary>
        /// Unshare the folder
        /// </summary>
        /// <param name="workstationInfo"></param>
        /// <param name="theScope"></param>
        private void UnshareRemoteFolder(WorkstationInfo workstationInfo, ManagementScope theScope)
        {
            try
            {
                WriteInConsole("Unsharing Folder " + workstationInfo.Address, LogType.info);

                var win32_Share_class = new ManagementClass(theScope, new ManagementPath("Win32_Share"), new ObjectGetOptions());
                ManagementObjectCollection collection = win32_Share_class.GetInstances();

                foreach (ManagementObject item in collection)
                {
                    if (Convert.ToString(item["Name"]).Equals(REMOTESHARENAME))
                    {
                        var unshareOutParams = item.InvokeMethod("Delete", new object[] { });
                        WriteInConsole("Unshare Folder " + CodeToStringConverters.ShareFolderErrorCodeToString(Convert.ToInt32(unshareOutParams)), LogType.info);
                    }
                }

            }
            catch (Exception ex)
            {
                WriteInConsole(ex.Message, LogType.error);
            }


        }

        /// <summary>
        /// Delete the folder
        /// </summary>
        /// <param name="workstationInfo"></param>
        /// <param name="theScope"></param>
        private void DeleteRemoteFolder(WorkstationInfo workstationInfo, ManagementScope theScope)
        {
            try
            {
                WriteInConsole("Removing Share Folder " + workstationInfo.Address, LogType.info);
                var Win32_Process_Class = new ManagementClass(theScope, new ManagementPath("Win32_Process"), new ObjectGetOptions());
                object[] cmdRMTemp = { @"cmd.exe /c rmdir /s /q " + REMOTEFOLDER };
                var rmResult = Win32_Process_Class.InvokeMethod("Create", cmdRMTemp);
                WriteInConsole("Remove Share Folder " + CodeToStringConverters.ErrorCodeToString(Convert.ToInt32(rmResult)), LogType.info);

            }
            catch (Exception ex)
            {
                WriteInConsole(ex.Message, LogType.error);
            }

        }





        bool debug = true;
        private void WriteInConsole(string text, LogType type)
        {
            if (debug || type != LogType.debug)
            {
                textBox_Console.Invoke((MethodInvoker)delegate
                {
                    Color _color;
                    switch (type)
                    {
                        case LogType.debug:
                            _color = DEBUGCOLOR;
                            break;
                        case LogType.message:
                            _color = MESSAGECOLOR;
                            break;
                        case LogType.info:
                            _color = INFOCOLOR;
                            break;
                        case LogType.error:
                            _color = ERRORCOLOR;
                            break;
                        default:
                            _color = Color.White;
                            break;
                    }
                    textBox_Console.SelectionStart = textBox_Console.TextLength;
                    textBox_Console.SelectionLength = 0;

                    textBox_Console.SelectionColor = _color;
                    textBox_Console.AppendText(DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") + ": " + text + Environment.NewLine);
                    textBox_Console.SelectionColor = textBox_Console.ForeColor;

                    textBox_Console.SelectionStart = textBox_Console.TextLength;
                    textBox_Console.ScrollToCaret();
                });
            }
        }

        // HIDE PASSWORD ON DATAGRID
        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 3 && e.Value != null)
            {
                e.Value = new String('*', e.Value.ToString().Length);
            }
        }


        enum LogType
        {
            debug,
            message,
            info,
            error,
        }



        /// <summary>
        /// Thread execution control, limit the parallelism 
        /// </summary>
        /// <param name="tasksToRun"></param>
        /// <param name="maxTasksToRunInParallel"></param>
        /// <param name="timeoutInMilliseconds"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task StartAndWaitAllThrottledAsync(IEnumerable<Task> tasksToRun, int maxTasksToRunInParallel, int timeoutInMilliseconds, CancellationToken cancellationToken = new CancellationToken())
        {
            List<Task> tasks = tasksToRun.ToList(); // Convert to a list of tasks so that we don't enumerate over it multiple times needlessly.
            using (var throttler = new SemaphoreSlim(maxTasksToRunInParallel))
            {
                var postTaskTasks = new List<Task>();

                // Have each task notify the throttler when it completes so that it decrements the number of tasks currently running.
                tasks.ForEach(t => postTaskTasks.Add(t.ContinueWith(tsk => throttler.Release())));

                // Start running each task.
                foreach (var task in tasks)
                {
                    // Increment the number of tasks currently running and wait if too many are running.
                    await throttler.WaitAsync(timeoutInMilliseconds, cancellationToken);

                    cancellationToken.ThrowIfCancellationRequested();
                    task.Start();
                }

                // Wait for all of the provided tasks to complete.
                // We wait on the list of "post" tasks instead of the original tasks, otherwise there is a potential race condition where the throttlers using block is exited before some Tasks have had their "post" action completed, which references the throttler, resulting in an exception due to accessing a disposed object.
                await Task.WhenAll(postTaskTasks.ToArray());
            }
        }

        private void button_add_Click(object sender, EventArgs e)
        {
            WorkstationInfo workstationInfo = GetWorkStationInfo();
            AddWorkStation(workstationInfo);
        }

        private WorkstationInfo GetWorkStationInfo()
        {
            return new WorkstationInfo
            {
                Address = textBox_address.Text,
                Domain = textBox_domain.Text,
                User = textBox_user.Text,
                Password = textBox_password.Text
            };
        }

        private void AddWorkStation(WorkstationInfo workstationInfo)
        {
            if (ValidateInput(workstationInfo))
            {
                int newrow = workstations_dataGridView.Rows.Add();
                workstations_dataGridView.Rows[newrow].Cells["address"].Value = workstationInfo.Address;
                workstations_dataGridView.Rows[newrow].Cells["domain"].Value = workstationInfo.Domain;
                workstations_dataGridView.Rows[newrow].Cells["user"].Value = workstationInfo.User;
                workstations_dataGridView.Rows[newrow].Cells["password"].Value = workstationInfo.Password;
                workstations_dataGridView.Rows[newrow].Cells["remove"].Value = "X";
            }



        }


        static string FetchScript(string resName)
        {
            Assembly currentAssembly = Assembly.GetExecutingAssembly();

            string[] names = currentAssembly.GetManifestResourceNames();
            //XProtectDeployer.Resources.Register_VmsServer.ps1
            //XProtectDeployer.Resources.Register-VmsServer.ps1"
            using (var stream = currentAssembly.GetManifestResourceStream($"XProtectDeployer.Resources.{resName}"))
            using (var reader = new StreamReader(stream))
            {
                // TODO: read the stream here
                string contents = reader.ReadToEnd();
                return contents;
            }

        }


        private bool ValidateInput(WorkstationInfo workstationInfo)
        {
            if (string.IsNullOrEmpty(workstationInfo.Address))
            {
                return false;
            };
            if (string.IsNullOrEmpty(workstationInfo.Domain))
            {
                return false;
            };
            if (string.IsNullOrEmpty(workstationInfo.User))
            {
                return false;
            };
            if (string.IsNullOrEmpty(workstationInfo.Password))
            {
                return false;
            };

            // Try to ping 
            /// CODE

            // Do not add duplicate entries 
            foreach (DataGridViewRow row in workstations_dataGridView.Rows)
            {
                if (row.Cells["address"].Value.ToString() == workstationInfo.Address)
                {
                    return false;
                }
            }
            return true;
        }

        private void workstations_dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ignore clicks that are not on button cells. 
            if (e.RowIndex < 0 || e.ColumnIndex != workstations_dataGridView.Columns["remove"].Index) return;

            workstations_dataGridView.Rows.RemoveAt(e.RowIndex);
        }

        private void button_LoadFromCSV_Click(object sender, EventArgs e)
        {
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "CSV File (*.csv)|*.csv|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;
                }
            }
            ReadCSV(filePath);
        }

        private void ReadCSV(string filePath)
        {
            using (var reader = new StreamReader(filePath))
            {
                List<string> listA = new List<string>();
                List<string> listB = new List<string>();
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');

                    WorkstationInfo workstationInfo = new WorkstationInfo();
                    workstationInfo.Address = values[0];
                    workstationInfo.Domain = values[1];
                    workstationInfo.User = values[2];
                    workstationInfo.Password = values[3];


                    AddWorkStation(workstationInfo);
                }
            }
        }



        // HIDE PASSWORD ON DATAGRID
        private void workstations_dataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 3 && e.Value != null)
            {
                e.Value = new String('*', e.Value.ToString().Length);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

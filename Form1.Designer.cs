namespace XProtectDeployer
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.listBox_Installers = new System.Windows.Forms.ListBox();
            this.listBox_Selected_Installers = new System.Windows.Forms.ListBox();
            this.button_insert = new System.Windows.Forms.Button();
            this.button_remove = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button_LoadFromCSV = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label_address = new System.Windows.Forms.Label();
            this.textBox_password = new System.Windows.Forms.TextBox();
            this.textBox_user = new System.Windows.Forms.TextBox();
            this.textBox_domain = new System.Windows.Forms.TextBox();
            this.textBox_address = new System.Windows.Forms.TextBox();
            this.button_add = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.workstations_dataGridView = new System.Windows.Forms.DataGridView();
            this.address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.domain = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.user = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.password = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remove = new System.Windows.Forms.DataGridViewButtonColumn();
            this.textBox_Console = new System.Windows.Forms.RichTextBox();
            this.numericUpDown_MaxDegreeOfParallelism = new System.Windows.Forms.NumericUpDown();
            this.button_deploy = new System.Windows.Forms.Button();
            this.textBox_ManagementServer = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button_LoadLocalInstaller = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBox_silentInstallParameter = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.splitContainer5 = new System.Windows.Forms.SplitContainer();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.workstations_dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_MaxDegreeOfParallelism)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer5)).BeginInit();
            this.splitContainer5.Panel1.SuspendLayout();
            this.splitContainer5.Panel2.SuspendLayout();
            this.splitContainer5.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBox_Installers
            // 
            this.listBox_Installers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox_Installers.FormattingEnabled = true;
            this.listBox_Installers.HorizontalScrollbar = true;
            this.listBox_Installers.Location = new System.Drawing.Point(0, 0);
            this.listBox_Installers.Name = "listBox_Installers";
            this.listBox_Installers.Size = new System.Drawing.Size(320, 160);
            this.listBox_Installers.TabIndex = 0;
            // 
            // listBox_Selected_Installers
            // 
            this.listBox_Selected_Installers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox_Selected_Installers.FormattingEnabled = true;
            this.listBox_Selected_Installers.HorizontalScrollbar = true;
            this.listBox_Selected_Installers.Location = new System.Drawing.Point(0, 0);
            this.listBox_Selected_Installers.Name = "listBox_Selected_Installers";
            this.listBox_Selected_Installers.Size = new System.Drawing.Size(336, 160);
            this.listBox_Selected_Installers.TabIndex = 1;
            // 
            // button_insert
            // 
            this.button_insert.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_insert.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_insert.ForeColor = System.Drawing.Color.Snow;
            this.button_insert.Location = new System.Drawing.Point(3, 3);
            this.button_insert.Name = "button_insert";
            this.button_insert.Size = new System.Drawing.Size(34, 74);
            this.button_insert.TabIndex = 2;
            this.button_insert.Text = ">";
            this.button_insert.UseVisualStyleBackColor = true;
            this.button_insert.Click += new System.EventHandler(this.button_insert_Click);
            // 
            // button_remove
            // 
            this.button_remove.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_remove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_remove.ForeColor = System.Drawing.Color.Snow;
            this.button_remove.Location = new System.Drawing.Point(3, 83);
            this.button_remove.Name = "button_remove";
            this.button_remove.Size = new System.Drawing.Size(34, 74);
            this.button_remove.TabIndex = 2;
            this.button_remove.Text = "<";
            this.button_remove.UseVisualStyleBackColor = true;
            this.button_remove.Click += new System.EventHandler(this.button_remove_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button_LoadFromCSV);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label_address);
            this.groupBox1.Controls.Add(this.textBox_password);
            this.groupBox1.Controls.Add(this.textBox_user);
            this.groupBox1.Controls.Add(this.textBox_domain);
            this.groupBox1.Controls.Add(this.textBox_address);
            this.groupBox1.Controls.Add(this.button_add);
            this.groupBox1.ForeColor = System.Drawing.Color.Snow;
            this.groupBox1.Location = new System.Drawing.Point(7, 51);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(355, 108);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Workstation";
            // 
            // button_LoadFromCSV
            // 
            this.button_LoadFromCSV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_LoadFromCSV.ForeColor = System.Drawing.Color.Snow;
            this.button_LoadFromCSV.Location = new System.Drawing.Point(189, 72);
            this.button_LoadFromCSV.Name = "button_LoadFromCSV";
            this.button_LoadFromCSV.Size = new System.Drawing.Size(154, 23);
            this.button_LoadFromCSV.TabIndex = 6;
            this.button_LoadFromCSV.Text = "Load From CSV";
            this.button_LoadFromCSV.UseVisualStyleBackColor = true;
            this.button_LoadFromCSV.Click += new System.EventHandler(this.button_LoadFromCSV_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(178, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Password";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(202, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "User";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Domain";
            // 
            // label_address
            // 
            this.label_address.AutoSize = true;
            this.label_address.Location = new System.Drawing.Point(16, 24);
            this.label_address.Name = "label_address";
            this.label_address.Size = new System.Drawing.Size(45, 13);
            this.label_address.TabIndex = 2;
            this.label_address.Text = "Address";
            // 
            // textBox_password
            // 
            this.textBox_password.Location = new System.Drawing.Point(237, 44);
            this.textBox_password.Name = "textBox_password";
            this.textBox_password.PasswordChar = '*';
            this.textBox_password.Size = new System.Drawing.Size(106, 20);
            this.textBox_password.TabIndex = 4;
            // 
            // textBox_user
            // 
            this.textBox_user.Location = new System.Drawing.Point(237, 18);
            this.textBox_user.Name = "textBox_user";
            this.textBox_user.Size = new System.Drawing.Size(106, 20);
            this.textBox_user.TabIndex = 3;
            // 
            // textBox_domain
            // 
            this.textBox_domain.Location = new System.Drawing.Point(67, 44);
            this.textBox_domain.Name = "textBox_domain";
            this.textBox_domain.Size = new System.Drawing.Size(106, 20);
            this.textBox_domain.TabIndex = 2;
            // 
            // textBox_address
            // 
            this.textBox_address.Location = new System.Drawing.Point(67, 18);
            this.textBox_address.Name = "textBox_address";
            this.textBox_address.Size = new System.Drawing.Size(106, 20);
            this.textBox_address.TabIndex = 1;
            // 
            // button_add
            // 
            this.button_add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_add.ForeColor = System.Drawing.Color.Snow;
            this.button_add.Location = new System.Drawing.Point(19, 72);
            this.button_add.Name = "button_add";
            this.button_add.Size = new System.Drawing.Size(154, 23);
            this.button_add.TabIndex = 5;
            this.button_add.Text = "ADD";
            this.button_add.UseVisualStyleBackColor = true;
            this.button_add.Click += new System.EventHandler(this.button_add_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.workstations_dataGridView);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.ForeColor = System.Drawing.Color.Snow;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(704, 208);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Servers Queue";
            // 
            // workstations_dataGridView
            // 
            this.workstations_dataGridView.AllowUserToAddRows = false;
            this.workstations_dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.workstations_dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.workstations_dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.address,
            this.domain,
            this.user,
            this.password,
            this.remove});
            this.workstations_dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.workstations_dataGridView.Location = new System.Drawing.Point(3, 16);
            this.workstations_dataGridView.Name = "workstations_dataGridView";
            this.workstations_dataGridView.RowHeadersVisible = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.DarkGray;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Snow;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.workstations_dataGridView.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.workstations_dataGridView.Size = new System.Drawing.Size(698, 189);
            this.workstations_dataGridView.TabIndex = 0;
            this.workstations_dataGridView.TabStop = false;
            this.workstations_dataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.workstations_dataGridView_CellClick);
            this.workstations_dataGridView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.workstations_dataGridView_CellFormatting);
            // 
            // address
            // 
            this.address.FillWeight = 98.12186F;
            this.address.HeaderText = "Address";
            this.address.Name = "address";
            // 
            // domain
            // 
            this.domain.FillWeight = 98.12186F;
            this.domain.HeaderText = "Domain";
            this.domain.Name = "domain";
            // 
            // user
            // 
            this.user.FillWeight = 98.12186F;
            this.user.HeaderText = "User";
            this.user.Name = "user";
            // 
            // password
            // 
            this.password.FillWeight = 98.12186F;
            this.password.HeaderText = "Password";
            this.password.Name = "password";
            // 
            // remove
            // 
            this.remove.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.remove.FillWeight = 20F;
            this.remove.HeaderText = "";
            this.remove.Name = "remove";
            this.remove.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.remove.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.remove.Width = 20;
            // 
            // textBox_Console
            // 
            this.textBox_Console.BackColor = System.Drawing.SystemColors.InfoText;
            this.textBox_Console.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_Console.Location = new System.Drawing.Point(0, 0);
            this.textBox_Console.Name = "textBox_Console";
            this.textBox_Console.Size = new System.Drawing.Size(704, 131);
            this.textBox_Console.TabIndex = 13;
            this.textBox_Console.TabStop = false;
            this.textBox_Console.Text = "";
            // 
            // numericUpDown_MaxDegreeOfParallelism
            // 
            this.numericUpDown_MaxDegreeOfParallelism.Location = new System.Drawing.Point(125, 74);
            this.numericUpDown_MaxDegreeOfParallelism.Name = "numericUpDown_MaxDegreeOfParallelism";
            this.numericUpDown_MaxDegreeOfParallelism.Size = new System.Drawing.Size(106, 20);
            this.numericUpDown_MaxDegreeOfParallelism.TabIndex = 34;
            this.numericUpDown_MaxDegreeOfParallelism.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // button_deploy
            // 
            this.button_deploy.BackColor = System.Drawing.SystemColors.HotTrack;
            this.button_deploy.BackgroundImage = global::XProtectDeployer.Properties.Resources.clipart4511373;
            this.button_deploy.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button_deploy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_deploy.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.button_deploy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_deploy.Location = new System.Drawing.Point(239, 19);
            this.button_deploy.Name = "button_deploy";
            this.button_deploy.Size = new System.Drawing.Size(75, 76);
            this.button_deploy.TabIndex = 33;
            this.button_deploy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_deploy.UseVisualStyleBackColor = false;
            this.button_deploy.Click += new System.EventHandler(this.button_deploy_Click);
            // 
            // textBox_ManagementServer
            // 
            this.textBox_ManagementServer.Location = new System.Drawing.Point(125, 22);
            this.textBox_ManagementServer.Name = "textBox_ManagementServer";
            this.textBox_ManagementServer.Size = new System.Drawing.Size(106, 20);
            this.textBox_ManagementServer.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Management Server";
            // 
            // button_LoadLocalInstaller
            // 
            this.button_LoadLocalInstaller.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_LoadLocalInstaller.ForeColor = System.Drawing.Color.Snow;
            this.button_LoadLocalInstaller.Location = new System.Drawing.Point(5, 9);
            this.button_LoadLocalInstaller.Name = "button_LoadLocalInstaller";
            this.button_LoadLocalInstaller.Size = new System.Drawing.Size(693, 32);
            this.button_LoadLocalInstaller.TabIndex = 37;
            this.button_LoadLocalInstaller.Text = "Load Local Installer";
            this.button_LoadLocalInstaller.UseVisualStyleBackColor = true;
            this.button_LoadLocalInstaller.Click += new System.EventHandler(this.button_LoadLocalInstaller_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.textBox_silentInstallParameter);
            this.groupBox3.Controls.Add(this.button_deploy);
            this.groupBox3.Controls.Add(this.textBox_ManagementServer);
            this.groupBox3.Controls.Add(this.numericUpDown_MaxDegreeOfParallelism);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.ForeColor = System.Drawing.Color.Snow;
            this.groupBox3.Location = new System.Drawing.Point(367, 51);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(329, 108);
            this.groupBox3.TabIndex = 36;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Deploy";
            // 
            // textBox_silentInstallParameter
            // 
            this.textBox_silentInstallParameter.Location = new System.Drawing.Point(125, 48);
            this.textBox_silentInstallParameter.Name = "textBox_silentInstallParameter";
            this.textBox_silentInstallParameter.Size = new System.Drawing.Size(106, 20);
            this.textBox_silentInstallParameter.TabIndex = 1;
            this.textBox_silentInstallParameter.Text = "--quiet";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(67, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Parameter";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(64, 76);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 13);
            this.label6.TabIndex = 35;
            this.label6.Text = "Parallelism";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer4);
            this.splitContainer1.Size = new System.Drawing.Size(704, 681);
            this.splitContainer1.SplitterDistance = 160;
            this.splitContainer1.TabIndex = 38;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.IsSplitterFixed = true;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.listBox_Installers);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer2.Size = new System.Drawing.Size(704, 160);
            this.splitContainer2.SplitterDistance = 320;
            this.splitContainer2.TabIndex = 39;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer3.IsSplitterFixed = true;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.tableLayoutPanel1);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.listBox_Selected_Installers);
            this.splitContainer3.Size = new System.Drawing.Size(380, 160);
            this.splitContainer3.SplitterDistance = 40;
            this.splitContainer3.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.button_remove, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.button_insert, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(40, 160);
            this.tableLayoutPanel1.TabIndex = 41;
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer4.IsSplitterFixed = true;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Name = "splitContainer4";
            this.splitContainer4.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.button_LoadLocalInstaller);
            this.splitContainer4.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer4.Panel1.Controls.Add(this.groupBox3);
            this.splitContainer4.Panel1MinSize = 170;
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.splitContainer5);
            this.splitContainer4.Size = new System.Drawing.Size(704, 517);
            this.splitContainer4.SplitterDistance = 170;
            this.splitContainer4.TabIndex = 0;
            // 
            // splitContainer5
            // 
            this.splitContainer5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer5.Location = new System.Drawing.Point(0, 0);
            this.splitContainer5.Name = "splitContainer5";
            this.splitContainer5.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer5.Panel1
            // 
            this.splitContainer5.Panel1.Controls.Add(this.groupBox2);
            // 
            // splitContainer5.Panel2
            // 
            this.splitContainer5.Panel2.Controls.Add(this.textBox_Console);
            this.splitContainer5.Size = new System.Drawing.Size(704, 343);
            this.splitContainer5.SplitterDistance = 208;
            this.splitContainer5.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(704, 681);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(720, 720);
            this.Name = "Form1";
            this.Text = "XProtect Deployer";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.workstations_dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_MaxDegreeOfParallelism)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            this.splitContainer5.Panel1.ResumeLayout(false);
            this.splitContainer5.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer5)).EndInit();
            this.splitContainer5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBox_Installers;
        private System.Windows.Forms.ListBox listBox_Selected_Installers;
        private System.Windows.Forms.Button button_insert;
        private System.Windows.Forms.Button button_remove;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label_address;
        private System.Windows.Forms.TextBox textBox_password;
        private System.Windows.Forms.TextBox textBox_user;
        private System.Windows.Forms.TextBox textBox_domain;
        private System.Windows.Forms.TextBox textBox_address;
        private System.Windows.Forms.Button button_add;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView workstations_dataGridView;
        private System.Windows.Forms.RichTextBox textBox_Console;
        private System.Windows.Forms.NumericUpDown numericUpDown_MaxDegreeOfParallelism;
        private System.Windows.Forms.Button button_deploy;
        private System.Windows.Forms.TextBox textBox_ManagementServer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_LoadLocalInstaller;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox textBox_silentInstallParameter;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewTextBoxColumn address;
        private System.Windows.Forms.DataGridViewTextBoxColumn domain;
        private System.Windows.Forms.DataGridViewTextBoxColumn user;
        private System.Windows.Forms.DataGridViewTextBoxColumn password;
        private System.Windows.Forms.DataGridViewButtonColumn remove;
        private System.Windows.Forms.Button button_LoadFromCSV;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.SplitContainer splitContainer5;
    }
}


using System.Windows.Forms;

namespace XProtectDeployer
{
    internal class WorkstationInfo
    {
        public WorkstationInfo()
        {
        }

        public string Address { get; internal set; }
        public string Domain { get; internal set; }
        public string User { get; internal set; }
        public string Password { get; internal set; }
    }
}
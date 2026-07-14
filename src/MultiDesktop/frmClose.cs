using System.Diagnostics;

namespace MultiDesktop
{
    public partial class frmClose : Form
    {
        public frmClose()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Process.GetCurrentProcess().Kill();
        }

        private void btnMin_Click(object sender, EventArgs e)
        {
            Program.IsMinWindow = true;
            Close();
        }

        private void frmClose_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.IsMinWindowAsk = !checkbox1.Checked;
            Properties.Settings.Default.Save();
        }
    }
}

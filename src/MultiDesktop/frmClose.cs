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
            if (checkbox1.Checked)
            {
                AppSettingsManager.AppSettings.Rows.Find("ExitMode")?["Value"] = 2;
                AppSettingsManager.AppSettings.WriteXml("AppSettings.xml", System.Data.XmlWriteMode.WriteSchema);
            }
            Process.GetCurrentProcess().Kill();
        }

        private void btnMin_Click(object sender, EventArgs e)
        {
            Program.IsMinWindow = true;
            Close();
            if (checkbox1.Checked)
            {
                AppSettingsManager.AppSettings.Rows.Find("ExitMode")?["Value"] = 1;
                AppSettingsManager.AppSettings.WriteXml("AppSettings.xml", System.Data.XmlWriteMode.WriteSchema);

            }
        }

        private void frmClose_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}

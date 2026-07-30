using System.Data;

namespace MultiDesktop
{
    public partial class frmSet : Form
    {

        public frmSet()
        {
            InitializeComponent();
        }

        private void drpColorMode_SelectedValueChanged(object sender, AntdUI.ObjectNEventArgs e)
        {
            drpColorMode.Text = drpColorMode.SelectedValue?.ToString();
            AppSettingsManager.ColorMode.TryGetValue(drpColorMode.Text, out SystemColorMode systemColorMode);
            Application.SetColorMode(systemColorMode);
        }

        private void btnSaveSettings_Click(object sender, EventArgs e)
        {
            AppSettingsManager.AppSettings.Rows.Find("Color")?["Value"] = AppSettingsManager.GetColorNum(drpColorMode.Text);
            AppSettingsManager.AppSettings.Rows.Find("ExitMode")?["Value"] = AppSettingsManager.GetExitModeNum(drpExitMode.Text);
            AppSettingsManager.AppSettings.WriteXml("AppSettings.xml", XmlWriteMode.WriteSchema);
            Close();
        }

        private void frmSet_Load(object sender, EventArgs e)
        {
            drpColorMode.Text =AppSettingsManager.GetColor(Convert.ToInt16(AppSettingsManager.AppSettings.Rows.Find("Color")?["Value"]));
            drpExitMode.Text = AppSettingsManager.GetExitMode(Convert.ToInt16(AppSettingsManager.AppSettings.Rows.Find("ExitMode")?["Value"]));
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();

        }

        private void drpExitMode_SelectedValueChanged(object sender, AntdUI.ObjectNEventArgs e)
        {
            drpExitMode.Text = drpExitMode.SelectedValue?.ToString();
        }
    }
}

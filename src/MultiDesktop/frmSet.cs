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
            MultiDesktop.Properties.Settings.Default.ColorMode = drpColorMode.Text;
            if (drpExitAction.Text == "询问")
            {
                Properties.Settings.Default.IsMinWindowAsk = true;
            }
            else
            {
                Properties.Settings.Default.IsMinWindowAsk = false;
                if (drpExitAction.Text == "最小化到后台")
                {
                    Properties.Settings.Default.AutoMin=true;
                }
                else
                {
                    Properties.Settings.Default.AutoMin = false;
                }
            }
            Properties.Settings.Default.strAutoMin = drpExitAction.Text;
            Properties.Settings.Default.Save(); // 别忘了保存！
            Close();
        }

        private void frmSet_Load(object sender, EventArgs e)
        {
            drpColorMode.Text = Properties.Settings.Default.ColorMode;
            drpExitAction.Text = Properties.Settings.Default.strAutoMin;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();

        }

        private void drpExitAction_SelectedValueChanged(object sender, AntdUI.ObjectNEventArgs e)
        {
            drpExitAction.Text = drpExitAction.SelectedValue?.ToString();
        }
    }
}

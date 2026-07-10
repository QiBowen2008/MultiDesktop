using System;
using System.Windows.Forms;
using MultiDesktop.Models;
using MultiDesktop.Services;

namespace MultiDesktop
{
    public partial class frmLauncher : Form
    {
        public frmLauncher()
        {
            InitializeComponent();
        }

        private void frmLauncher_Load(object sender, EventArgs e)
        {
            LoadConfig();
            RefreshDesktopList();
        }

        private void LoadConfig()
        {
            AppState.Config = JsonConfigManager.Load(AppCommon.ConfigPath);
        }

        private void RefreshDesktopList()
        {
            lvDesktops.Items.Clear();

            if (AppState.Config == null || AppState.Config.Desktops == null)
                return;

            foreach (var desktop in AppState.Config.Desktops)
            {
                var item = new ListViewItem(desktop.Name);
                item.SubItems.Add(desktop.GetEffectivePath());
                item.Tag = desktop;
                lvDesktops.Items.Add(item);
            }

            if (lvDesktops.Items.Count > 0)
                lvDesktops.Items[0].Selected = true;
        }

        private void lvDesktops_DoubleClick(object sender, EventArgs e)
        {
            SwitchToSelectedDesktop();
        }

        private void btnSwitch_Click(object sender, EventArgs e)
        {
            SwitchToSelectedDesktop();
        }

        private void SwitchToSelectedDesktop()
        {
            if (lvDesktops.SelectedItems.Count == 0)
            {
                MessageBox.Show("请先选择一个桌面。", "提示",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var desktop = lvDesktops.SelectedItems[0].Tag as DesktopInfo;
            if (desktop == null) return;

            try
            {
                DesktopSwitcher.SwitchToDesktop(desktop.GetEffectivePath());
                Application.Exit();
            }
            catch (Exception ex)
            {
                MessageBox.Show("切换桌面失败：" + ex.Message, "错误",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnManage_Click(object sender, EventArgs e)
        {
            using (var frm = new frmMain())
            {
                this.Hide();
                frm.ShowDialog(this);
                this.Show();

                AppState.Config = JsonConfigManager.Load(AppCommon.ConfigPath);
                RefreshDesktopList();
            }
        }
    }
}

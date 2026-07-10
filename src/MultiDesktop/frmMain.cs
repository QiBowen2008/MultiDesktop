using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using MultiDesktop.Models;
using MultiDesktop.Services;

namespace MultiDesktop
{
    public partial class frmMain : Form
    {
        private DesktopConfigData _config;
        private DesktopInfo _selectedDesktop;
        private bool _isUpdating;

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            _config = AppState.Config ?? JsonConfigManager.Load(AppCommon.ConfigPath);
            RefreshDesktopList();
        }

        #region 列表管理

        private void RefreshDesktopList()
        {
            _isUpdating = true;
            lvDesktops.Items.Clear();

            if (_config?.Desktops == null) { _isUpdating = false; return; }

            foreach (var desktop in _config.Desktops)
            {
                var item = new ListViewItem(desktop.Name);
                item.SubItems.Add(desktop.GetEffectivePath());
                item.Tag = desktop;
                lvDesktops.Items.Add(item);
            }

            if (lvDesktops.Items.Count > 0)
                lvDesktops.Items[0].Selected = true;

            _isUpdating = false;
            AutoFitListViewColumns();
        }

        private void lvDesktops_Resize(object sender, EventArgs e)
        {
            AutoFitListViewColumns();
        }

        private void AutoFitListViewColumns()
        {
            if (lvDesktops.Columns.Count < 2) return;
            int w = lvDesktops.ClientSize.Width - 4;
            if (w < 100) return;
            lvDesktops.Columns[0].Width = w * 40 / 100;
            lvDesktops.Columns[1].Width = w * 60 / 100;
        }

        private void lvDesktops_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isUpdating) return;

            if (lvDesktops.SelectedItems.Count > 0)
            {
                _selectedDesktop = lvDesktops.SelectedItems[0].Tag as DesktopInfo;
                PopulateDetailPanel();
            }
            else
            {
                _selectedDesktop = null;
                ClearDetailPanel();
            }
        }

        #endregion

        #region 详情面板

        private void grpDetail_Resize(object sender, EventArgs e)
        {
            const int margin = 18;
            const int btnWidth = 42;
            const int gap = 8;

            int w = grpDetail.ClientSize.Width;
            if (w < 100) return;

            txtName.Width = w - margin * 2;

            btnBrowsePath.Left = w - margin - btnWidth;
            txtPath.Width = btnBrowsePath.Left - txtPath.Left - gap;
        }

        private void PopulateDetailPanel()
        {
            if (_selectedDesktop == null) return;

            _isUpdating = true;
            txtName.Text = _selectedDesktop.Name;
            txtPath.Text = _selectedDesktop.GetEffectivePath();

            bool isDefault = _selectedDesktop.IsDefault;
            txtName.Enabled = !isDefault;
            txtPath.Enabled = !isDefault;
            btnBrowsePath.Enabled = !isDefault;
            btnDelete.Enabled = !isDefault;
            _isUpdating = false;
        }

        private void ClearDetailPanel()
        {
            _isUpdating = true;
            txtName.Text = "";
            txtPath.Text = "";
            txtName.Enabled = false;
            txtPath.Enabled = false;
            btnBrowsePath.Enabled = false;
            btnDelete.Enabled = false;
            _isUpdating = false;
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            if (_isUpdating || _selectedDesktop == null) return;
            if (lvDesktops.SelectedItems.Count > 0)
                lvDesktops.SelectedItems[0].Text = txtName.Text;
        }

        private void btnBrowsePath_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog(this) == DialogResult.OK)
            {
                txtPath.Text = folderBrowserDialog.SelectedPath;
                if (_selectedDesktop != null && lvDesktops.SelectedItems.Count > 0)
                    lvDesktops.SelectedItems[0].SubItems[1].Text = txtPath.Text;
            }
        }

        #endregion

        #region 操作按钮

        private void btnSaveDetail_Click(object sender, EventArgs e)
        {
            if (_selectedDesktop == null)
            {
                MessageBox.Show("请先选择一个桌面。", "提示",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("桌面名称不能为空。", "提示",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return;
            }

            string path = txtPath.Text.Trim();
            if (!_selectedDesktop.IsDefault)
            {
                if (string.IsNullOrEmpty(path))
                {
                    MessageBox.Show("桌面路径不能为空，请选择桌面文件夹。", "提示",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPath.Focus();
                    return;
                }
                if (!Directory.Exists(path))
                {
                    MessageBox.Show("桌面路径 \"" + path + "\" 不存在，请重新选择。",
                        "路径无效", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPath.Focus();
                    return;
                }
            }

            _selectedDesktop.Name = txtName.Text.Trim();
            if (!_selectedDesktop.IsDefault)
                _selectedDesktop.Path = path;

            if (JsonConfigManager.Save(AppCommon.ConfigPath, _config))
            {
                if (lvDesktops.SelectedItems.Count > 0)
                {
                    var item = lvDesktops.SelectedItems[0];
                    item.Text = _selectedDesktop.Name;
                    item.SubItems[1].Text = _selectedDesktop.GetEffectivePath();
                }
                MessageBox.Show("保存成功。", "提示",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("保存失败，请检查文件权限。", "错误",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_selectedDesktop == null) return;
            if (_selectedDesktop.IsDefault)
            {
                MessageBox.Show("当前桌面不可删除。", "提示",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show(
                "确定要删除桌面 \"" + _selectedDesktop.Name + "\" 吗？此操作不可恢复。",
                "确认删除", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result != DialogResult.Yes) return;

            _config.Desktops.Remove(_selectedDesktop);
            for (int i = 0; i < _config.Desktops.Count; i++)
                _config.Desktops[i].Id = i;

            JsonConfigManager.Save(AppCommon.ConfigPath, _config);
            _selectedDesktop = null;
            RefreshDesktopList();
        }

        private void btnAddDesktop_Click(object sender, EventArgs e)
        {
            string baseName = "新桌面";
            int nextId = _config.Desktops.Count > 0
                ? _config.Desktops.Max(d => d.Id) + 1
                : 1;

            string newName = baseName + "_" + nextId;
            int counter = 1;
            while (_config.Desktops.Any(d => d.Name == newName))
            {
                counter++;
                newName = baseName + "_" + counter;
            }

            var newDesktop = new DesktopInfo
            {
                Id = nextId,
                Name = newName,
                Path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                IsDefault = false
            };

            _config.Desktops.Add(newDesktop);
            _config.FirstRun = false;
            JsonConfigManager.Save(AppCommon.ConfigPath, _config);

            var item = new ListViewItem(newDesktop.Name);
            item.SubItems.Add(newDesktop.Path);
            item.Tag = newDesktop;
            lvDesktops.Items.Add(item);

            item.Selected = true;
            item.EnsureVisible();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnDeleteCurrent_Click(object sender, EventArgs e)
        {
            if (_selectedDesktop == null)
            {
                MessageBox.Show("请先在左侧列表中选择一个桌面。", "提示",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (_selectedDesktop.IsDefault)
            {
                MessageBox.Show("当前桌面不可删除。", "提示",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show(
                "确定要删除桌面 \"" + _selectedDesktop.Name + "\" 吗？此操作不可恢复。",
                "确认删除", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result != DialogResult.Yes) return;

            _config.Desktops.Remove(_selectedDesktop);
            for (int i = 0; i < _config.Desktops.Count; i++)
                _config.Desktops[i].Id = i;

            JsonConfigManager.Save(AppCommon.ConfigPath, _config);
            _selectedDesktop = null;
            RefreshDesktopList();
        }

        #endregion
    }
}

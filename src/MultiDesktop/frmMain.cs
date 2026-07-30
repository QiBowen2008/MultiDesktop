using System.Data;
using System.Diagnostics;

namespace MultiDesktop
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            if (File.Exists("DesktopList.xml"))
            {
                DesktopManager.DesktopList.ReadXml("DesktopList.xml");
                DesktopManager.EnsureDesktopListColumns(DesktopManager.DesktopList);
            }
            else
            {
                DesktopManager.DesktopList.TableName = ("DesktopList");
                DesktopManager.DesktopList.Columns.Add("桌面名称");
                DesktopManager.DesktopList.Columns.Add("桌面路径");
                DesktopManager.DesktopList.Columns.Add("是否开启自定义壁纸");
                DesktopManager.DesktopList.Columns.Add("自定义壁纸地址");
                DesktopManager.DesktopList.Columns.Add("壁纸显示方式");
            }
            tblDesktopList.DataSource = DesktopManager.DesktopList;
        }

        private void btnAddDesktop_Click(object sender, EventArgs e)
        {
            frmAddDesktop frmAddDesktop = new();
            frmAddDesktop.ShowDialog();
            tblDesktopList.Refresh();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            tblDesktopList.DataSource = DesktopManager.DesktopList;
            tblDesktopList.Refresh();
            notifyIcon1.Visible = true;
            int DesktopIndex = 0;
            foreach (DataRow desktopnames in DesktopManager.DesktopList.Rows)
            {
                string? desktopname = desktopnames[0].ToString();
                ToolStripMenuItem menuItem = new ToolStripMenuItem(desktopname);
                menuItem.Tag = DesktopIndex;
                itmDesktopList.DropDownItems.Add(menuItem);
                DesktopIndex++;// 存储索引
            }
        }

        private void btnDeleteDesktop_Click(object sender, EventArgs e)
        {
            if (tblDesktopList.SelectedIndexs.Length != 0)
            {
                foreach (int i in tblDesktopList.SelectedIndexs.OrderByDescending(x => x))
                {
                    DesktopManager.DesktopList.Rows[i - 1].Delete();
                }
                DesktopManager.DesktopList.AcceptChanges();
                tblDesktopList.Refresh();
                DesktopManager.DesktopList.WriteXml("DesktopList.xml", XmlWriteMode.WriteSchema);
            }


        }

        private void btnEditDesktop_Click(object sender, EventArgs e)
        {
            DesktopManager.t_DesktopName = DesktopManager.DesktopList.Rows[tblDesktopList.SelectedIndex - 1][0].ToString();
            DesktopManager.t_DesktopPath = DesktopManager.DesktopList.Rows[tblDesktopList.SelectedIndex - 1][1].ToString();
            DesktopManager.IsEdit = true;
            DesktopManager.IndexToChange = tblDesktopList.SelectedIndex - 1;
            frmAddDesktop frmAddDesktop = new();
            frmAddDesktop.ShowDialog();
            tblDesktopList.Refresh();
        }

        private void tblDesktopList_CellFocused(object sender, AntdUI.TableCellFocusedEventArgs e)
        {

        }

        private void tblDesktopList_Enter(object sender, EventArgs e)
        {

        }

        private void tblDesktopList_CellClick(object sender, AntdUI.TableClickEventArgs e)
        {
            if (tblDesktopList.SelectedIndexs.Length > 0)
            {
                btnDeleteDesktop.Enabled = true;
            }
            else
            {
                btnDeleteDesktop.Enabled = false;

            }
            if (tblDesktopList.SelectedIndexs.Length == 1)
            {
                btnChangeDesktop.Enabled = true;
                btnEditDesktop.Enabled = true;
            }
            else
            {
                btnChangeDesktop.Enabled = false;
                btnEditDesktop.Enabled = false;
            }
        }

        private void btnChangeDesktop_Click(object sender, EventArgs e)
        {
            int idx = tblDesktopList.SelectedIndex - 1;
            var row = DesktopManager.DesktopList.Rows[idx];
            string desktopPath = row[1].ToString()!;
            bool enableWallpaper = Convert.ToBoolean(row[2]);
            string? wallpaperPath = row[3]?.ToString();
            string? wallpaperStyle = row.ItemArray.Length > 4 ? row[4]?.ToString() : null;

            if (enableWallpaper && !string.IsNullOrEmpty(wallpaperPath))
                DesktopManager.ChangeDesktopPath(desktopPath, wallpaperPath, wallpaperStyle);
            else
                DesktopManager.ChangeDesktopPath(desktopPath);
        }

        private void btnSet_Click(object sender, EventArgs e)
        {
            frmSet set = new frmSet();
            set.ShowDialog();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            if (Convert.ToInt16(AppSettingsManager.AppSettings.Rows.Find("ExitMode")?["Value"]) == 0)
            {
                frmClose close = new frmClose();
                close.ShowDialog();
            }
            if (Program.IsMinWindow || Convert.ToInt16(AppSettingsManager.AppSettings.Rows.Find("ExitMode")?["Value"]) == 1)
            {
                Hide();
            }
            else
            {
                Process.GetCurrentProcess().Kill();
            }

        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
        }

        private void itmExit_Click(object sender, EventArgs e)
        {
            Process.GetCurrentProcess().Kill();
        }

        private void itmDesktopList_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            var clickedItem = e.ClickedItem as ToolStripMenuItem;

            if (clickedItem is not null && clickedItem.Tag is int index)
            {
                var row = DesktopManager.DesktopList.Rows[index];
                string desktopPath = row[1].ToString()!;
                bool enableWallpaper = Convert.ToBoolean(row[2]);
                string? wallpaperPath = row[3]?.ToString();
                string? wallpaperStyle = row.ItemArray.Length > 4 ? row[4]?.ToString() : null;

                if (enableWallpaper && !string.IsNullOrEmpty(wallpaperPath))
                    DesktopManager.ChangeDesktopPath(desktopPath, wallpaperPath, wallpaperStyle);
                else
                    DesktopManager.ChangeDesktopPath(desktopPath);
            }

        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            frmAbout about = new frmAbout();
            about.Show();
        }

        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (itmDesktopList.DropDownItems.Count == 0) { itmDesktopList.Enabled = false; }
            else { itmDesktopList.Enabled = true;}
            itmDesktopList.DropDownItems.Clear();
            int DesktopIndex = 0;
            foreach (DataRow desktopnames in DesktopManager.DesktopList.Rows)
            {
                string? desktopname = desktopnames[0].ToString();
                ToolStripMenuItem menuItem = new ToolStripMenuItem(desktopname);
                menuItem.Tag = DesktopIndex;
                itmDesktopList.DropDownItems.Add(menuItem);
                DesktopIndex++;// 存储索引
            }
        }
    }
}



namespace MultiDesktop
{
    public partial class frmAddDesktop : Form
    {
        public frmAddDesktop()
        {
            InitializeComponent();
        }

        private void btnAddDesktop_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtDesktopName.Text) && !string.IsNullOrWhiteSpace(txtDesktopPath.Text))
            {
                if (Directory.Exists(txtDesktopPath.Text))
                {
                    if (DesktopManager.IsEdit == false)
                    {
                        DesktopManager.DesktopList.Rows.Add(txtDesktopName.Text, txtDesktopPath.Text);
                        Close();
                    }
                    else
                    {
                        DesktopManager.DesktopList.Rows[DesktopManager.IndexToChange][0] = txtDesktopName.Text;
                        DesktopManager.DesktopList.Rows[DesktopManager.IndexToChange][1] = txtDesktopPath.Text;
                        Close();
                    }
                    DesktopManager.DesktopList.WriteXml("DesktopList.xml", System.Data.XmlWriteMode.WriteSchema);

                }
                else
                {
                    MessageBox.Show("你输入的桌面路径不存在" );

                }
            }
            else
            {
                MessageBox.Show("请完整填写信息" );
            }

        }

        private void btnShowFolderBrowseDialog_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                txtDesktopPath.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmAddDesktop_Load(object sender, EventArgs e)
        {
            txtDesktopName.Text = DesktopManager.t_DesktopName;
            txtDesktopPath.Text = DesktopManager.t_DesktopPath;
        }

        private void frmAddDesktop_FormClosing(object sender, FormClosingEventArgs e)
        {
            DesktopManager.ReSetDesktopManager();
        }
    }
}

namespace MultiDesktop
{
    public partial class frmPassword : Form
    {
        public frmPassword()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if(txtNewPassword.Text == txtNewPasswordAgain.Text)
            {
                if (string.IsNullOrEmpty(txtOldPassword.Text))
                {
                    if(EncryptManager.IsEncrypted == false)
                    {
                        EncryptManager.GetZipFile(EncryptManager.DesktopFolder, DesktopManager.IndexToChange, txtNewPassword.Text);
                        EncryptManager.IsEncrypted = true;
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("请输入原密码");
                    }

                }
                else
                {
                    try
                    {
                        EncryptManager.UnZipFile(EncryptManager.DesktopFolder, DesktopManager.IndexToChange, txtOldPassword.Text);
                        EncryptManager.GetZipFile(EncryptManager.DesktopFolder, DesktopManager.IndexToChange, txtNewPassword.Text);
                        Close();
                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message); }
                }
                if(string.IsNullOrWhiteSpace(txtNewPassword.Text))
                {
                    MessageBox.Show("你的桌面将失去加密保护");
                }
            }
            else
            {
                MessageBox.Show("两次输入的密码不一致");
            }
        }
    }
}

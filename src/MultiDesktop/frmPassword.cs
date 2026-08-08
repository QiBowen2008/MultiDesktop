using PostQuantum.FileEncryption;

namespace MultiDesktop
{
    public partial class frmPassword : Form
    {
        public frmPassword()
        {
            InitializeComponent();
            this.AcceptButton = btnOK;
            this.KeyPreview = true;
            this.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Escape)
                    Close();
            };
        }

        private void frmPassword_Load(object sender, EventArgs e)
        {
            // 首次设置密码时不显示“原密码”一栏，其余控件整体上移
            bool hasOld = EncryptManager.HasEncryptedFile(EncryptManager.DesktopID);
            label1.Visible = hasOld;
            txtOldPassword.Visible = hasOld;
            if (!hasOld)
            {
                int shift = txtOldPassword.Height + 34;
                txtNewPassword.Location = new Point(txtNewPassword.Location.X, txtNewPassword.Location.Y - shift);
                txtNewPasswordAgain.Location = new Point(txtNewPasswordAgain.Location.X, txtNewPasswordAgain.Location.Y - shift);
                label2.Location = new Point(label2.Location.X, label2.Location.Y - shift);
                label3.Location = new Point(label3.Location.X, label3.Location.Y - shift);
            }
        }

        private async void btnOK_Click(object sender, EventArgs e)
        {
            string oldPw = txtOldPassword.Text;
            string newPw = txtNewPassword.Text;
            string newPwAgain = txtNewPasswordAgain.Text;

            if (string.IsNullOrWhiteSpace(EncryptManager.DesktopFolder))
            {
                MessageBox.Show("缺少桌面信息，请返回重新设置", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (newPw != newPwAgain)
            {
                MessageBox.Show("两次输入的密码不一致", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            bool hasOld = EncryptManager.HasEncryptedFile(EncryptManager.DesktopID);
            string folder = EncryptManager.DesktopFolder;
            int id = EncryptManager.DesktopID;
            string? name = EncryptManager.DesktopName;

            try
            {
                if (string.IsNullOrEmpty(newPw))
                {
                    // ===== 移除加密 =====
                    if (!hasOld)
                    {
                        MessageBox.Show("该桌面尚未加密，无需操作", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if (string.IsNullOrWhiteSpace(oldPw))
                    {
                        MessageBox.Show("请输入原密码", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    // 通过尝试解密解压验证原密码（密码错误会抛出 PqDecryptionException）
                    try
                    {
                        await EncryptManager.RemoveEncryption(folder, id, oldPw);
                    }
                    catch (PqDecryptionException)
                    {
                        MessageBox.Show("原密码错误", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    EncryptManager.IsEncrypted = false;
                    EncryptManager.Password = null;
                    MessageBox.Show("桌面已取消加密保护", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                    return;
                }

                if (!hasOld)
                {
                    // ===== 首次设置密码（原密码留空） =====
                    if (!string.IsNullOrWhiteSpace(oldPw))
                    {
                        MessageBox.Show("首次设置密码无需输入原密码", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    await EncryptManager.GetZipFile(folder, id, newPw);
                    EncryptManager.IsEncrypted = true;
                    EncryptManager.Password = newPw;
                    EncryptManager.SetSessionPassword(name, newPw);
                    MessageBox.Show("桌面加密成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
                else
                {
                    // ===== 修改密码：验证旧密码，还原文件夹后用新密码重新加密 =====
                    if (string.IsNullOrWhiteSpace(oldPw))
                    {
                        MessageBox.Show("请输入原密码", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    // 通过尝试解密解压来验证旧密码（密码错误会抛出 PqDecryptionException）
                    try
                    {
                        if (Directory.Exists(folder))
                        {
                            // 文件夹已存在（明文）：解密到临时目录校验旧密码，避免旧压缩包覆盖新文件
                            await EncryptManager.VerifyPasswordByDecryptAsync(id, oldPw);
                        }
                        else
                        {
                            // 文件夹不存在（仍加密）：用旧密码真实解密还原，既是验证也是还原
                            await EncryptManager.UnZipFile(folder, id, oldPw);
                        }
                    }
                    catch (PqDecryptionException)
                    {
                        MessageBox.Show("原密码错误", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    // 用新密码重新加密（原加密包会被覆盖）
                    await EncryptManager.GetZipFile(folder, id, newPw);
                    EncryptManager.IsEncrypted = true;
                    EncryptManager.Password = newPw;
                    EncryptManager.SetSessionPassword(name, newPw);
                    MessageBox.Show("密码修改成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"操作失败：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

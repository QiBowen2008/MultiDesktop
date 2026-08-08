using System;
using System.Windows.Forms;

namespace MultiDesktop
{
    public partial class frmInputPassword : Form
    {
        public frmInputPassword()
        {
            InitializeComponent();
            this.AcceptButton = btnOK;
            this.KeyPreview = true;
            this.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Escape)
                {
                    this.DialogResult = DialogResult.Cancel;
                    Close();
                }
            };
        }

        /// <summary>提示文案（默认“密码”）。</summary>
        [System.ComponentModel.Browsable(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public string? PromptText
        {
            set => label1.Text = string.IsNullOrEmpty(value) ? "密码" : value;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string pw = input1.Text;
            if (string.IsNullOrWhiteSpace(pw))
            {
                MessageBox.Show("请输入密码", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            // 密码是否正确由调用方通过实际解密来校验（密码错误时重新弹窗）
            EncryptManager.Password = pw;
            this.DialogResult = DialogResult.OK;
            Close();
        }
    }
}

namespace MultiDesktop
{
    partial class frmPassword
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtOldPassword = new AntdUI.Input();
            txtNewPassword = new AntdUI.Input();
            txtNewPasswordAgain = new AntdUI.Input();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            btnOK = new AntdUI.Button();
            SuspendLayout();
            // 
            // txtOldPassword
            // 
            txtOldPassword.Font = new Font("Microsoft YaHei UI", 15F);
            txtOldPassword.Location = new Point(372, 50);
            txtOldPassword.Name = "txtOldPassword";
            txtOldPassword.PasswordChar = '*';
            txtOldPassword.Size = new Size(276, 73);
            txtOldPassword.TabIndex = 0;
            // 
            // txtNewPassword
            // 
            txtNewPassword.Font = new Font("Microsoft YaHei UI", 15F);
            txtNewPassword.Location = new Point(372, 157);
            txtNewPassword.Name = "txtNewPassword";
            txtNewPassword.Size = new Size(276, 73);
            txtNewPassword.TabIndex = 1;
            // 
            // txtNewPasswordAgain
            // 
            txtNewPasswordAgain.Font = new Font("Microsoft YaHei UI", 15F);
            txtNewPasswordAgain.Location = new Point(372, 274);
            txtNewPasswordAgain.Name = "txtNewPasswordAgain";
            txtNewPasswordAgain.Size = new Size(276, 73);
            txtNewPasswordAgain.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft YaHei UI", 15F);
            label1.Location = new Point(69, 65);
            label1.Name = "label1";
            label1.Size = new Size(257, 39);
            label1.TabIndex = 3;
            label1.Text = "请输入原来的密码";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft YaHei UI", 15F);
            label2.Location = new Point(69, 179);
            label2.Name = "label2";
            label2.Size = new Size(197, 39);
            label2.TabIndex = 4;
            label2.Text = "请输入新密码";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft YaHei UI", 15F);
            label3.Location = new Point(38, 295);
            label3.Name = "label3";
            label3.Size = new Size(317, 39);
            label3.TabIndex = 5;
            label3.Text = "请输入再次输入新密码";
            // 
            // btnOK
            // 
            btnOK.DefaultBack = Color.Green;
            btnOK.Font = new Font("Microsoft YaHei UI", 15F);
            btnOK.Location = new Point(255, 380);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(190, 70);
            btnOK.TabIndex = 6;
            btnOK.Text = "确定";
            btnOK.Click += btnOK_Click;
            // 
            // frmPassword
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(698, 478);
            Controls.Add(btnOK);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtNewPasswordAgain);
            Controls.Add(txtNewPassword);
            Controls.Add(txtOldPassword);
            Name = "frmPassword";
            Text = "桌面加密设置";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private AntdUI.Input txtOldPassword;
        private AntdUI.Input txtNewPassword;
        private AntdUI.Input txtNewPasswordAgain;
        private Label label1;
        private Label label2;
        private Label label3;
        private AntdUI.Button btnOK;
    }
}
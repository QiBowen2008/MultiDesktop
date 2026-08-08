namespace MultiDesktop
{
    partial class frmInputPassword
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
            label1 = new Label();
            input1 = new AntdUI.Input();
            btnOK = new AntdUI.Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft YaHei UI", 15F);
            label1.Location = new Point(66, 70);
            label1.Name = "label1";
            label1.Size = new Size(77, 39);
            label1.TabIndex = 0;
            label1.Text = "密码";
            // 
            // input1
            // 
            input1.Font = new Font("Microsoft YaHei UI", 15F);
            input1.Location = new Point(172, 54);
            input1.Name = "input1";
            input1.PasswordChar = '*';
            input1.Size = new Size(388, 70);
            input1.TabIndex = 1;
            // 
            // btnOK
            // 
            btnOK.Font = new Font("Microsoft YaHei UI", 15F);
            btnOK.Location = new Point(213, 143);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(156, 69);
            btnOK.TabIndex = 2;
            btnOK.Text = "确定";
            btnOK.Click += btnOK_Click;
            // 
            // frmInputPassword
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(582, 239);
            Controls.Add(btnOK);
            Controls.Add(input1);
            Controls.Add(label1);
            Name = "frmInputPassword";
            Text = "请输入密码";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private AntdUI.Input input1;
        private AntdUI.Button btnOK;
    }
}
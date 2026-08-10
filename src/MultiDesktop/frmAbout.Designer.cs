namespace MultiDesktop
{
    partial class frmAbout
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
            label2 = new Label();
            label3 = new Label();
            lnkHomePage = new LinkLabel();
            label4 = new Label();
            lnkAntdUI = new LinkLabel();
            lnkAntdUILicense = new LinkLabel();
            label5 = new Label();
            btnOK = new AntdUI.Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft YaHei UI", 18F, FontStyle.Bold);
            label1.Location = new Point(51, 48);
            label1.Name = "label1";
            label1.Size = new Size(200, 47);
            label1.TabIndex = 0;
            label1.Text = "多桌面切换";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(60, 127);
            label2.Name = "label2";
            label2.Size = new Size(102, 24);
            label2.TabIndex = 1;
            label2.Text = "版本1.3.6.0";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(60, 171);
            label3.Name = "label3";
            label3.Size = new Size(82, 24);
            label3.TabIndex = 2;
            label3.Text = "项目主页";
            // 
            // lnkHomePage
            // 
            lnkHomePage.AutoSize = true;
            lnkHomePage.Location = new Point(148, 171);
            lnkHomePage.Name = "lnkHomePage";
            lnkHomePage.Size = new Size(430, 24);
            lnkHomePage.TabIndex = 3;
            lnkHomePage.TabStop = true;
            lnkHomePage.Text = "https://github.com/Qibowen2008/MultiDesktop";
            lnkHomePage.LinkClicked += lnkHomePage_LinkClicked;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft YaHei UI", 15F);
            label4.Location = new Point(60, 262);
            label4.Name = "label4";
            label4.Size = new Size(257, 39);
            label4.TabIndex = 4;
            label4.Text = "感谢以下开源项目";
            // 
            // lnkAntdUI
            // 
            lnkAntdUI.AutoSize = true;
            lnkAntdUI.Location = new Point(60, 312);
            lnkAntdUI.Name = "lnkAntdUI";
            lnkAntdUI.Size = new Size(75, 24);
            lnkAntdUI.TabIndex = 5;
            lnkAntdUI.TabStop = true;
            lnkAntdUI.Text = "Antd.UI";
            lnkAntdUI.LinkClicked += lnkAntdUI_LinkClicked;
            // 
            // lnkAntdUILicense
            // 
            lnkAntdUILicense.AutoSize = true;
            lnkAntdUILicense.Location = new Point(167, 312);
            lnkAntdUILicense.Name = "lnkAntdUILicense";
            lnkAntdUILicense.Size = new Size(64, 24);
            lnkAntdUILicense.TabIndex = 6;
            lnkAntdUILicense.TabStop = true;
            lnkAntdUILicense.Text = "许可证";
            lnkAntdUILicense.LinkClicked += lnkAntdUILicense_LinkClicked;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(60, 224);
            label5.Name = "label5";
            label5.Size = new Size(115, 24);
            label5.TabIndex = 7;
            label5.Text = "许可证：MIT";
            // 
            // btnOK
            // 
            btnOK.DefaultBack = Color.Green;
            btnOK.Font = new Font("Microsoft YaHei UI", 15F);
            btnOK.Location = new Point(478, 335);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(140, 64);
            btnOK.TabIndex = 8;
            btnOK.Text = "确定";
            btnOK.Click += btnOK_Click;
            // 
            // frmAbout
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(671, 437);
            Controls.Add(btnOK);
            Controls.Add(label5);
            Controls.Add(lnkAntdUILicense);
            Controls.Add(lnkAntdUI);
            Controls.Add(label4);
            Controls.Add(lnkHomePage);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "frmAbout";
            Text = "关于";
            Load += frmAbout_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private LinkLabel lnkHomePage;
        private Label label4;
        private LinkLabel lnkAntdUI;
        private LinkLabel lnkAntdUILicense;
        private Label label5;
        private AntdUI.Button btnOK;
    }
}

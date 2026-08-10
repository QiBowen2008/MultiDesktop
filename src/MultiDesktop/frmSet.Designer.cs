namespace MultiDesktop
{
    partial class frmSet
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
            drpColorMode = new AntdUI.Dropdown();
            label1 = new Label();
            label2 = new Label();
            drpExitMode = new AntdUI.Dropdown();
            btnSaveSettings = new AntdUI.Button();
            btnClose = new AntdUI.Button();
            label3 = new Label();
            button1 = new AntdUI.Button();
            SuspendLayout();
            // 
            // drpColorMode
            // 
            drpColorMode.Font = new Font("Microsoft YaHei UI", 15F);
            drpColorMode.Items.AddRange(new object[] { "跟随系统", "浅色", "深色" });
            drpColorMode.Location = new Point(257, 24);
            drpColorMode.Name = "drpColorMode";
            drpColorMode.Size = new Size(204, 68);
            drpColorMode.TabIndex = 0;
            drpColorMode.SelectedValueChanged += drpColorMode_SelectedValueChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft YaHei UI", 15F);
            label1.Location = new Point(114, 36);
            label1.Name = "label1";
            label1.Size = new Size(137, 39);
            label1.TabIndex = 1;
            label1.Text = "颜色模式";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft YaHei UI", 15F);
            label2.Location = new Point(114, 123);
            label2.Name = "label2";
            label2.Size = new Size(107, 39);
            label2.TabIndex = 2;
            label2.Text = "退出时";
            // 
            // drpExitMode
            // 
            drpExitMode.Font = new Font("Microsoft YaHei UI", 15F);
            drpExitMode.Items.AddRange(new object[] { "询问", "最小化到后台", "退出程序" });
            drpExitMode.Location = new Point(257, 112);
            drpExitMode.Name = "drpExitMode";
            drpExitMode.Size = new Size(204, 60);
            drpExitMode.TabIndex = 3;
            drpExitMode.SelectedValueChanged += drpExitMode_SelectedValueChanged;
            // 
            // btnSaveSettings
            // 
            btnSaveSettings.DefaultBack = Color.Green;
            btnSaveSettings.Font = new Font("Microsoft YaHei UI", 15F);
            btnSaveSettings.Location = new Point(116, 281);
            btnSaveSettings.Name = "btnSaveSettings";
            btnSaveSettings.Size = new Size(166, 79);
            btnSaveSettings.TabIndex = 6;
            btnSaveSettings.Text = "确定";
            btnSaveSettings.Click += btnSaveSettings_Click;
            // 
            // btnClose
            // 
            btnClose.DefaultBack = Color.Red;
            btnClose.Font = new Font("Microsoft YaHei UI", 15F);
            btnClose.Location = new Point(311, 281);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(166, 79);
            btnClose.TabIndex = 7;
            btnClose.Text = "取消";
            btnClose.Click += btnClose_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft YaHei UI", 15F);
            label3.ImeMode = ImeMode.NoControl;
            label3.Location = new Point(139, 391);
            label3.Name = "label3";
            label3.Size = new Size(287, 39);
            label3.TabIndex = 8;
            label3.Text = "设置重启软件时生效";
            // 
            // button1
            // 
            button1.DefaultBack = Color.LightBlue;
            button1.Font = new Font("Microsoft YaHei UI", 15F);
            button1.Location = new Point(114, 198);
            button1.Name = "button1";
            button1.Size = new Size(363, 66);
            button1.TabIndex = 9;
            button1.Text = "安装 Skills";
            button1.Click += btnInstallSkills_Click;
            // 
            // frmSet
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(584, 459);
            Controls.Add(button1);
            Controls.Add(label3);
            Controls.Add(btnClose);
            Controls.Add(btnSaveSettings);
            Controls.Add(drpExitMode);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(drpColorMode);
            Name = "frmSet";
            Text = "设置";
            Load += frmSet_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private AntdUI.Dropdown drpColorMode;
        private Label label1;
        private Label label2;
        private AntdUI.Dropdown drpExitMode;
        private AntdUI.Button btnSaveSettings;
        private AntdUI.Button btnClose;
        private Label label3;
        private AntdUI.Button button1;
    }
}

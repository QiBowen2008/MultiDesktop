namespace MultiDesktop
{
    partial class frmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            tblDesktopList = new AntdUI.Table();
            label1 = new Label();
            btnAddDesktop = new AntdUI.Button();
            btnDeleteDesktop = new AntdUI.Button();
            btnChangeDesktop = new AntdUI.Button();
            btnEditDesktop = new AntdUI.Button();
            notifyIcon1 = new NotifyIcon(components);
            contextMenuStrip1 = new ContextMenuStrip(components);
            itmDesktopList = new ToolStripMenuItem();
            itmSettingsMenu = new ToolStripMenuItem();
            itmAboutMenu = new ToolStripMenuItem();
            toolStripMenuItem2 = new ToolStripSeparator();
            itmExit = new ToolStripMenuItem();
            btnSet = new AntdUI.Button();
            btnAbout = new AntdUI.Button();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // tblDesktopList
            // 
            tblDesktopList.AutoSizeColumnsMode = AntdUI.ColumnsMode.Fill;
            tblDesktopList.BackColor = SystemColors.ControlDark;
            tblDesktopList.EmptyText = "还没有桌面";
            tblDesktopList.Gap = 12;
            tblDesktopList.Location = new Point(85, 81);
            tblDesktopList.MultipleRows = true;
            tblDesktopList.Name = "tblDesktopList";
            tblDesktopList.Size = new Size(829, 480);
            tblDesktopList.TabIndex = 0;
            tblDesktopList.CellClick += tblDesktopList_CellClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft YaHei UI", 15F);
            label1.Location = new Point(85, 30);
            label1.Name = "label1";
            label1.Size = new Size(167, 39);
            label1.TabIndex = 1;
            label1.Text = "桌面管理器";
            // 
            // btnAddDesktop
            // 
            btnAddDesktop.DefaultBack = Color.Green;
            btnAddDesktop.Font = new Font("微软雅黑", 15F);
            btnAddDesktop.Location = new Point(30, 582);
            btnAddDesktop.Name = "btnAddDesktop";
            btnAddDesktop.Size = new Size(143, 57);
            btnAddDesktop.TabIndex = 2;
            btnAddDesktop.Text = "添加桌面";
            btnAddDesktop.Click += btnAddDesktop_Click;
            // 
            // btnDeleteDesktop
            // 
            btnDeleteDesktop.DefaultBack = Color.Red;
            btnDeleteDesktop.Enabled = false;
            btnDeleteDesktop.Font = new Font("微软雅黑", 15F);
            btnDeleteDesktop.Location = new Point(198, 582);
            btnDeleteDesktop.Name = "btnDeleteDesktop";
            btnDeleteDesktop.Size = new Size(143, 57);
            btnDeleteDesktop.TabIndex = 3;
            btnDeleteDesktop.Text = "删除";
            btnDeleteDesktop.Click += btnDeleteDesktop_Click;
            // 
            // btnChangeDesktop
            // 
            btnChangeDesktop.DefaultBack = Color.Yellow;
            btnChangeDesktop.Enabled = false;
            btnChangeDesktop.Font = new Font("微软雅黑", 15F);
            btnChangeDesktop.Location = new Point(347, 582);
            btnChangeDesktop.Name = "btnChangeDesktop";
            btnChangeDesktop.Size = new Size(238, 57);
            btnChangeDesktop.TabIndex = 4;
            btnChangeDesktop.Text = "切换到选中桌面";
            btnChangeDesktop.Click += btnChangeDesktop_Click;
            // 
            // btnEditDesktop
            // 
            btnEditDesktop.DefaultBack = Color.LightBlue;
            btnEditDesktop.Enabled = false;
            btnEditDesktop.Font = new Font("微软雅黑", 15F);
            btnEditDesktop.Location = new Point(591, 582);
            btnEditDesktop.Name = "btnEditDesktop";
            btnEditDesktop.Size = new Size(208, 57);
            btnEditDesktop.TabIndex = 5;
            btnEditDesktop.Text = "编辑选中桌面";
            btnEditDesktop.Click += btnEditDesktop_Click;
            // 
            // notifyIcon1
            // 
            notifyIcon1.ContextMenuStrip = contextMenuStrip1;
            notifyIcon1.Icon = new Icon(System.IO.Path.Combine(System.AppContext.BaseDirectory, "Desktop.ico"));
            notifyIcon1.Text = "多桌面切换";
            notifyIcon1.Visible = true;
            notifyIcon1.MouseDoubleClick += notifyIcon1_MouseDoubleClick;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(24, 24);
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { itmDesktopList, itmSettingsMenu, itmAboutMenu, toolStripMenuItem2, itmExit });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(135, 130);
            contextMenuStrip1.Opening += contextMenuStrip1_Opening;
            // 
            // itmDesktopList
            // 
            itmDesktopList.Name = "itmDesktopList";
            itmDesktopList.Size = new Size(134, 30);
            itmDesktopList.Text = "切换到";
            itmDesktopList.DropDownItemClicked += itmDesktopList_DropDownItemClicked;
            // 
            // itmSettingsMenu
            // 
            itmSettingsMenu.Name = "itmSettingsMenu";
            itmSettingsMenu.Size = new Size(134, 30);
            itmSettingsMenu.Text = "设置";
            itmSettingsMenu.Click += btnSet_Click;
            // 
            // itmAboutMenu
            // 
            itmAboutMenu.Name = "itmAboutMenu";
            itmAboutMenu.Size = new Size(134, 30);
            itmAboutMenu.Text = "关于";
            itmAboutMenu.Click += btnAbout_Click;
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.Size = new Size(131, 6);
            // 
            // itmExit
            // 
            itmExit.Name = "itmExit";
            itmExit.Size = new Size(134, 30);
            itmExit.Text = "退出";
            itmExit.Click += itmExit_Click;
            // 
            // btnSet
            // 
            btnSet.DefaultBack = Color.LightBlue;
            btnSet.Font = new Font("微软雅黑", 15F);
            btnSet.Location = new Point(805, 582);
            btnSet.Name = "btnSet";
            btnSet.Size = new Size(159, 57);
            btnSet.TabIndex = 6;
            btnSet.Text = "设置";
            btnSet.Click += btnSet_Click;
            // 
            // btnAbout
            // 
            btnAbout.DefaultBack = Color.LightBlue;
            btnAbout.Font = new Font("微软雅黑", 15F);
            btnAbout.Location = new Point(391, 653);
            btnAbout.Name = "btnAbout";
            btnAbout.Size = new Size(159, 57);
            btnAbout.TabIndex = 7;
            btnAbout.Text = "关于软件";
            btnAbout.Click += btnAbout_Click;
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(993, 726);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Controls.Add(btnAbout);
            Controls.Add(btnSet);
            Controls.Add(btnEditDesktop);
            Controls.Add(btnChangeDesktop);
            Controls.Add(btnDeleteDesktop);
            Controls.Add(btnAddDesktop);
            Controls.Add(label1);
            Controls.Add(tblDesktopList);
            Name = "frmMain";
            Text = "多桌面切换";
            FormClosing += frmMain_FormClosing;
            Load += frmMain_Load;
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private AntdUI.Table tblDesktopList;
        private Label label1;
        private AntdUI.Button btnAddDesktop;
        private AntdUI.Button btnDeleteDesktop;
        private AntdUI.Button btnChangeDesktop;
        private AntdUI.Button btnEditDesktop;
        private NotifyIcon notifyIcon1;
        private AntdUI.Button btnSet;
        private AntdUI.Button btnAbout;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem itmSettingsMenu;
        private ToolStripMenuItem itmAboutMenu;
        private ToolStripSeparator toolStripMenuItem2;
        private ToolStripMenuItem itmExit;
        private ToolStripMenuItem itmDesktopList;
    }
}

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            tblDesktopList = new AntdUI.Table();
            label1 = new Label();
            btnAddDesktop = new AntdUI.Button();
            btnDeleteDesktop = new AntdUI.Button();
            btnChangeDesktop = new AntdUI.Button();
            btnEditDesktop = new AntdUI.Button();
            notifyIcon1 = new NotifyIcon(components);
            contextMenuStrip1 = new ContextMenuStrip(components);
            itmDesktopList = new ToolStripMenuItem();
            设置ToolStripMenuItem = new ToolStripMenuItem();
            关于ToolStripMenuItem = new ToolStripMenuItem();
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
            resources.ApplyResources(tblDesktopList, "tblDesktopList");
            tblDesktopList.Gap = 12;
            tblDesktopList.MultipleRows = true;
            tblDesktopList.Name = "tblDesktopList";
            tblDesktopList.CellClick += tblDesktopList_CellClick;
            tblDesktopList.CellFocused += tblDesktopList_CellFocused;
            tblDesktopList.Enter += tblDesktopList_Enter;
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.Name = "label1";
            // 
            // btnAddDesktop
            // 
            btnAddDesktop.DefaultBack = Color.Green;
            resources.ApplyResources(btnAddDesktop, "btnAddDesktop");
            btnAddDesktop.Name = "btnAddDesktop";
            btnAddDesktop.Click += btnAddDesktop_Click;
            // 
            // btnDeleteDesktop
            // 
            btnDeleteDesktop.DefaultBack = Color.Red;
            resources.ApplyResources(btnDeleteDesktop, "btnDeleteDesktop");
            btnDeleteDesktop.Name = "btnDeleteDesktop";
            btnDeleteDesktop.Click += btnDeleteDesktop_Click;
            // 
            // btnChangeDesktop
            // 
            btnChangeDesktop.DefaultBack = Color.Yellow;
            resources.ApplyResources(btnChangeDesktop, "btnChangeDesktop");
            btnChangeDesktop.Name = "btnChangeDesktop";
            btnChangeDesktop.Click += btnChangeDesktop_Click;
            // 
            // btnEditDesktop
            // 
            btnEditDesktop.DefaultBack = Color.LightBlue;
            resources.ApplyResources(btnEditDesktop, "btnEditDesktop");
            btnEditDesktop.Name = "btnEditDesktop";
            btnEditDesktop.Click += btnEditDesktop_Click;
            // 
            // notifyIcon1
            // 
            notifyIcon1.ContextMenuStrip = contextMenuStrip1;
            resources.ApplyResources(notifyIcon1, "notifyIcon1");
            notifyIcon1.MouseDoubleClick += notifyIcon1_MouseDoubleClick;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(24, 24);
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { itmDesktopList, 设置ToolStripMenuItem, 关于ToolStripMenuItem, toolStripMenuItem2, itmExit });
            contextMenuStrip1.Name = "contextMenuStrip1";
            resources.ApplyResources(contextMenuStrip1, "contextMenuStrip1");
            // 
            // itmDesktopList
            // 
            itmDesktopList.Name = "itmDesktopList";
            resources.ApplyResources(itmDesktopList, "itmDesktopList");
            itmDesktopList.DropDownItemClicked += itmDesktopList_DropDownItemClicked;
            // 
            // 设置ToolStripMenuItem
            // 
            设置ToolStripMenuItem.Name = "设置ToolStripMenuItem";
            resources.ApplyResources(设置ToolStripMenuItem, "设置ToolStripMenuItem");
            设置ToolStripMenuItem.Click += btnSet_Click;
            // 
            // 关于ToolStripMenuItem
            // 
            关于ToolStripMenuItem.Name = "关于ToolStripMenuItem";
            resources.ApplyResources(关于ToolStripMenuItem, "关于ToolStripMenuItem");
            关于ToolStripMenuItem.Click += btnAbout_Click;
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            resources.ApplyResources(toolStripMenuItem2, "toolStripMenuItem2");
            // 
            // itmExit
            // 
            itmExit.Name = "itmExit";
            resources.ApplyResources(itmExit, "itmExit");
            itmExit.Click += itmExit_Click;
            // 
            // btnSet
            // 
            btnSet.DefaultBack = Color.LightBlue;
            resources.ApplyResources(btnSet, "btnSet");
            btnSet.Name = "btnSet";
            btnSet.Click += btnSet_Click;
            // 
            // btnAbout
            // 
            btnAbout.DefaultBack = Color.LightBlue;
            resources.ApplyResources(btnAbout, "btnAbout");
            btnAbout.Name = "btnAbout";
            btnAbout.Click += btnAbout_Click;
            // 
            // frmMain
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnAbout);
            Controls.Add(btnSet);
            Controls.Add(btnEditDesktop);
            Controls.Add(btnChangeDesktop);
            Controls.Add(btnDeleteDesktop);
            Controls.Add(btnAddDesktop);
            Controls.Add(label1);
            Controls.Add(tblDesktopList);
            Name = "frmMain";
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
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem 设置ToolStripMenuItem;
        private ToolStripMenuItem 关于ToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem2;
        private ToolStripMenuItem itmExit;
        private ToolStripMenuItem itmDesktopList;
        private AntdUI.Button btnAbout;
    }
}

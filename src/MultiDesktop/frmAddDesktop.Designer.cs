namespace MultiDesktop
{
    partial class frmAddDesktop
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddDesktop));
            btnAddDesktop = new AntdUI.Button();
            btnClose = new AntdUI.Button();
            label1 = new Label();
            label2 = new Label();
            txtDesktopName = new AntdUI.Input();
            txtDesktopPath = new AntdUI.Input();
            btnShowFolderBrowseDialog = new AntdUI.Button();
            folderBrowserDialog1 = new FolderBrowserDialog();
            resources.ApplyResources(this.folderBrowserDialog1, "folderBrowserDialog1");
            SuspendLayout();
            // 
            // btnAddDesktop
            // 
            btnAddDesktop.DefaultBack = Color.Green;
            btnAddDesktop.Font = new Font("Microsoft YaHei UI", 15F);
            btnAddDesktop.Location = new Point(172, 287);
            btnAddDesktop.Name = "btnAddDesktop";
            btnAddDesktop.Size = new Size(166, 79);
            btnAddDesktop.TabIndex = 0;
            btnAddDesktop.Text = resources.GetString("btnAddDesktop.Text");
            btnAddDesktop.Click += btnAddDesktop_Click;
            resources.ApplyResources(this.btnAddDesktop, "btnAddDesktop");
            // 
            // btnClose
            // 
            btnClose.DefaultBack = Color.Red;
            btnClose.Font = new Font("Microsoft YaHei UI", 15F);
            btnClose.Location = new Point(453, 287);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(166, 79);
            btnClose.TabIndex = 1;
            btnClose.Text = resources.GetString("btnClose.Text");
            btnClose.Click += btnClose_Click;
            resources.ApplyResources(this.btnClose, "btnClose");
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft YaHei UI", 15F);
            label1.Location = new Point(64, 93);
            label1.Name = "label1";
            label1.Size = new Size(137, 39);
            label1.TabIndex = 2;
            label1.Text = resources.GetString("label1.Text");
            resources.ApplyResources(this.label1, "label1");
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft YaHei UI", 15F);
            label2.Location = new Point(64, 197);
            label2.Name = "label2";
            label2.Size = new Size(137, 39);
            label2.TabIndex = 3;
            label2.Text = resources.GetString("label2.Text");
            resources.ApplyResources(this.label2, "label2");
            // 
            // txtDesktopName
            // 
            txtDesktopName.Font = new Font("Microsoft YaHei UI", 15F);
            txtDesktopName.Location = new Point(231, 77);
            txtDesktopName.Name = "txtDesktopName";
            txtDesktopName.Size = new Size(442, 84);
            txtDesktopName.TabIndex = 4;
            resources.ApplyResources(this.txtDesktopName, "txtDesktopName");
            // 
            // txtDesktopPath
            // 
            txtDesktopPath.Font = new Font("Microsoft YaHei UI", 15F);
            txtDesktopPath.Location = new Point(231, 176);
            txtDesktopPath.Name = "txtDesktopPath";
            txtDesktopPath.Size = new Size(442, 79);
            txtDesktopPath.TabIndex = 5;
            resources.ApplyResources(this.txtDesktopPath, "txtDesktopPath");
            // 
            // btnShowFolderBrowseDialog
            // 
            btnShowFolderBrowseDialog.Font = new Font("Microsoft YaHei UI", 15F);
            btnShowFolderBrowseDialog.Location = new Point(679, 176);
            btnShowFolderBrowseDialog.Name = "btnShowFolderBrowseDialog";
            btnShowFolderBrowseDialog.Size = new Size(78, 79);
            btnShowFolderBrowseDialog.TabIndex = 6;
            btnShowFolderBrowseDialog.Text = "...";
            btnShowFolderBrowseDialog.Click += btnShowFolderBrowseDialog_Click;
            resources.ApplyResources(this.btnShowFolderBrowseDialog, "btnShowFolderBrowseDialog");
            // 
            // frmAddDesktop
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(806, 423);
            Controls.Add(btnShowFolderBrowseDialog);
            Controls.Add(txtDesktopPath);
            Controls.Add(txtDesktopName);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnClose);
            Controls.Add(btnAddDesktop);
            Name = "frmAddDesktop";
            Text = "添加桌面";
            FormClosing += frmAddDesktop_FormClosing;
            Load += frmAddDesktop_Load;
            resources.ApplyResources(this, "$this");
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private AntdUI.Button btnAddDesktop;
        private AntdUI.Button btnClose;
        private Label label1;
        private Label label2;
        private AntdUI.Input txtDesktopName;
        private AntdUI.Input txtDesktopPath;
        private AntdUI.Button btnShowFolderBrowseDialog;
        private FolderBrowserDialog folderBrowserDialog1;
    }
}
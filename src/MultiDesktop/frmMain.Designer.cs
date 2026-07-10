namespace MultiDesktop
{
    partial class frmMain
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.lvDesktops = new System.Windows.Forms.ListView();
            this.grpDetail = new System.Windows.Forms.GroupBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSaveDetail = new System.Windows.Forms.Button();
            this.lblPath = new System.Windows.Forms.Label();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.btnBrowsePath = new System.Windows.Forms.Button();
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.btnAddDesktop = new System.Windows.Forms.Button();
            this.btnDeleteCurrent = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.grpDetail.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // colName
            // 
            this.colName.Text = "名称";
            this.colName.Width = 200;
            // 
            // colPath
            // 
            this.colPath.Text = "路径";
            this.colPath.Width = 270;
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.lvDesktops);
            this.splitContainer.Panel1.Padding = new System.Windows.Forms.Padding(15, 15, 15, 15);
            this.splitContainer.Panel1MinSize = 300;
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.grpDetail);
            this.splitContainer.Panel2.Padding = new System.Windows.Forms.Padding(0, 15, 15, 15);
            this.splitContainer.Panel2MinSize = 340;
            this.splitContainer.Size = new System.Drawing.Size(1196, 630);
            this.splitContainer.SplitterDistance = 500;
            this.splitContainer.SplitterWidth = 2;
            this.splitContainer.TabIndex = 0;
            // 
            // lvDesktops
            // 
            this.lvDesktops.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colName,
            this.colPath});
            this.lvDesktops.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvDesktops.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lvDesktops.FullRowSelect = true;
            this.lvDesktops.GridLines = true;
            this.lvDesktops.HideSelection = false;
            this.lvDesktops.Location = new System.Drawing.Point(15, 15);
            this.lvDesktops.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lvDesktops.MultiSelect = false;
            this.lvDesktops.Name = "lvDesktops";
            this.lvDesktops.Size = new System.Drawing.Size(470, 600);
            this.lvDesktops.TabIndex = 0;
            this.lvDesktops.UseCompatibleStateImageBehavior = false;
            this.lvDesktops.View = System.Windows.Forms.View.Details;
            this.lvDesktops.SelectedIndexChanged += new System.EventHandler(this.lvDesktops_SelectedIndexChanged);
            this.lvDesktops.Resize += new System.EventHandler(this.lvDesktops_Resize);
            // 
            // grpDetail
            // 
            this.grpDetail.Controls.Add(this.btnDelete);
            this.grpDetail.Controls.Add(this.btnSaveDetail);
            this.grpDetail.Controls.Add(this.lblPath);
            this.grpDetail.Controls.Add(this.txtPath);
            this.grpDetail.Controls.Add(this.btnBrowsePath);
            this.grpDetail.Controls.Add(this.lblName);
            this.grpDetail.Controls.Add(this.txtName);
            this.grpDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpDetail.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.grpDetail.Location = new System.Drawing.Point(0, 15);
            this.grpDetail.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpDetail.Name = "grpDetail";
            this.grpDetail.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpDetail.Size = new System.Drawing.Size(679, 600);
            this.grpDetail.TabIndex = 0;
            this.grpDetail.TabStop = false;
            this.grpDetail.Text = "桌面属性";
            this.grpDetail.Resize += new System.EventHandler(this.grpDetail_Resize);
            // 
            // btnDelete
            // 
            this.btnDelete.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnDelete.Location = new System.Drawing.Point(292, 240);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(240, 54);
            this.btnDelete.TabIndex = 9;
            this.btnDelete.Text = "删除";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSaveDetail
            // 
            this.btnSaveDetail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnSaveDetail.FlatAppearance.BorderSize = 0;
            this.btnSaveDetail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveDetail.ForeColor = System.Drawing.Color.White;
            this.btnSaveDetail.Location = new System.Drawing.Point(27, 240);
            this.btnSaveDetail.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSaveDetail.Name = "btnSaveDetail";
            this.btnSaveDetail.Size = new System.Drawing.Size(240, 54);
            this.btnSaveDetail.TabIndex = 8;
            this.btnSaveDetail.Text = "保存";
            this.btnSaveDetail.UseVisualStyleBackColor = false;
            this.btnSaveDetail.Click += new System.EventHandler(this.btnSaveDetail_Click);
            // 
            // lblPath
            // 
            this.lblPath.AutoSize = true;
            this.lblPath.Location = new System.Drawing.Point(22, 135);
            this.lblPath.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPath.Name = "lblPath";
            this.lblPath.Size = new System.Drawing.Size(82, 24);
            this.lblPath.TabIndex = 2;
            this.lblPath.Text = "桌面位置";
            // 
            // txtPath
            // 
            this.txtPath.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtPath.Location = new System.Drawing.Point(27, 165);
            this.txtPath.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(538, 32);
            this.txtPath.TabIndex = 3;
            // 
            // btnBrowsePath
            // 
            this.btnBrowsePath.Location = new System.Drawing.Point(578, 164);
            this.btnBrowsePath.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnBrowsePath.Name = "btnBrowsePath";
            this.btnBrowsePath.Size = new System.Drawing.Size(63, 39);
            this.btnBrowsePath.TabIndex = 4;
            this.btnBrowsePath.Text = "...";
            this.btnBrowsePath.UseVisualStyleBackColor = true;
            this.btnBrowsePath.Click += new System.EventHandler(this.btnBrowsePath_Click);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(22, 45);
            this.lblName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(82, 24);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "桌面名称";
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtName.Location = new System.Drawing.Point(27, 75);
            this.txtName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(598, 32);
            this.txtName.TabIndex = 1;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnAddDesktop);
            this.pnlBottom.Controls.Add(this.btnDeleteCurrent);
            this.pnlBottom.Controls.Add(this.btnClose);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 630);
            this.pnlBottom.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Padding = new System.Windows.Forms.Padding(15, 12, 15, 12);
            this.pnlBottom.Size = new System.Drawing.Size(1196, 75);
            this.pnlBottom.TabIndex = 1;
            // 
            // btnAddDesktop
            // 
            this.btnAddDesktop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnAddDesktop.FlatAppearance.BorderSize = 0;
            this.btnAddDesktop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddDesktop.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAddDesktop.ForeColor = System.Drawing.Color.White;
            this.btnAddDesktop.Location = new System.Drawing.Point(15, 12);
            this.btnAddDesktop.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAddDesktop.Name = "btnAddDesktop";
            this.btnAddDesktop.Size = new System.Drawing.Size(180, 51);
            this.btnAddDesktop.TabIndex = 0;
            this.btnAddDesktop.Text = "+ 新建桌面";
            this.btnAddDesktop.UseVisualStyleBackColor = false;
            this.btnAddDesktop.Click += new System.EventHandler(this.btnAddDesktop_Click);
            // 
            // btnDeleteCurrent
            // 
            this.btnDeleteCurrent.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDeleteCurrent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnDeleteCurrent.Location = new System.Drawing.Point(210, 12);
            this.btnDeleteCurrent.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDeleteCurrent.Name = "btnDeleteCurrent";
            this.btnDeleteCurrent.Size = new System.Drawing.Size(180, 51);
            this.btnDeleteCurrent.TabIndex = 2;
            this.btnDeleteCurrent.Text = "删除当前桌面";
            this.btnDeleteCurrent.UseVisualStyleBackColor = true;
            this.btnDeleteCurrent.Click += new System.EventHandler(this.btnDeleteCurrent_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(1061, 12);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(120, 51);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // folderBrowserDialog
            // 
            this.folderBrowserDialog.Description = "选择桌面文件夹";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1196, 705);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.pnlBottom);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "桌面管理";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.grpDetail.ResumeLayout(false);
            this.grpDetail.PerformLayout();
            this.pnlBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.ListView lvDesktops;
        private System.Windows.Forms.GroupBox grpDetail;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblPath;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Button btnBrowsePath;
        private System.Windows.Forms.Button btnSaveDetail;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Button btnAddDesktop;
        private System.Windows.Forms.Button btnDeleteCurrent;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colPath;
    }
}

namespace MultiDesktop
{
    partial class frmLauncher
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
            this.lvDesktops = new System.Windows.Forms.ListView();
            this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnSwitch = new System.Windows.Forms.Button();
            this.btnManage = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();

            // lvDesktops
            this.lvDesktops.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
                this.colName,
                this.colPath
            });
            this.lvDesktops.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lvDesktops.FullRowSelect = true;
            this.lvDesktops.GridLines = true;
            this.lvDesktops.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvDesktops.HideSelection = false;
            this.lvDesktops.Location = new System.Drawing.Point(24, 55);
            this.lvDesktops.MultiSelect = false;
            this.lvDesktops.Name = "lvDesktops";
            this.lvDesktops.Size = new System.Drawing.Size(432, 200);
            this.lvDesktops.TabIndex = 0;
            this.lvDesktops.UseCompatibleStateImageBehavior = false;
            this.lvDesktops.View = System.Windows.Forms.View.Details;
            this.lvDesktops.DoubleClick += new System.EventHandler(this.lvDesktops_DoubleClick);

            // colName
            this.colName.Text = "桌面名称";
            this.colName.Width = 180;

            // colPath
            this.colPath.Text = "桌面路径";
            this.colPath.Width = 248;

            // btnSwitch
            this.btnSwitch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnSwitch.FlatAppearance.BorderSize = 0;
            this.btnSwitch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSwitch.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSwitch.ForeColor = System.Drawing.Color.White;
            this.btnSwitch.Location = new System.Drawing.Point(24, 275);
            this.btnSwitch.Name = "btnSwitch";
            this.btnSwitch.Size = new System.Drawing.Size(220, 40);
            this.btnSwitch.TabIndex = 1;
            this.btnSwitch.Text = "切换桌面";
            this.btnSwitch.UseVisualStyleBackColor = false;
            this.btnSwitch.Click += new System.EventHandler(this.btnSwitch_Click);

            // btnManage
            this.btnManage.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnManage.Location = new System.Drawing.Point(256, 275);
            this.btnManage.Name = "btnManage";
            this.btnManage.Size = new System.Drawing.Size(204, 40);
            this.btnManage.TabIndex = 3;
            this.btnManage.Text = "管理桌面...";
            this.btnManage.UseVisualStyleBackColor = true;
            this.btnManage.Click += new System.EventHandler(this.btnManage_Click);

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTitle.Location = new System.Drawing.Point(20, 18);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(90, 21);
            this.lblTitle.TabIndex = 4;
            this.lblTitle.Text = "选择桌面";

            // frmLauncher
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 338);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnManage);
            this.Controls.Add(this.btnSwitch);
            this.Controls.Add(this.lvDesktops);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmLauncher";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "多桌面助手";
            this.Load += new System.EventHandler(this.frmLauncher_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.ListView lvDesktops;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colPath;
        private System.Windows.Forms.Button btnSwitch;
        private System.Windows.Forms.Button btnManage;
        private System.Windows.Forms.Label lblTitle;
    }
}

namespace MultiDesktop
{
    partial class frmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.cobDesktopList = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDesktopBackground = new Sunny.UI.UITextBox();
            this.txtDesktopLocation = new Sunny.UI.UITextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.btnSetDesktopLocation = new Sunny.UI.UIButton();
            this.button2 = new Sunny.UI.UIButton();
            this.btnAddDesktop = new Sunny.UI.UIButton();
            this.btnChangeDesktop = new Sunny.UI.UIButton();
            this.btnSave = new Sunny.UI.UIButton();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.txtDesktopName = new Sunny.UI.UITextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnDeleteDesktop = new Sunny.UI.UIButton();
            this.SuspendLayout();
            // 
            // cobDesktopList
            // 
            this.cobDesktopList.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cobDesktopList.FormattingEnabled = true;
            this.cobDesktopList.Items.AddRange(new object[] {
            "默认桌面"});
            this.cobDesktopList.Location = new System.Drawing.Point(163, 46);
            this.cobDesktopList.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cobDesktopList.MinimumSize = new System.Drawing.Size(63, 0);
            this.cobDesktopList.Name = "cobDesktopList";
            this.cobDesktopList.Size = new System.Drawing.Size(294, 28);
            this.cobDesktopList.TabIndex = 0;
            this.cobDesktopList.Text = "默认桌面";
            this.cobDesktopList.SelectedIndexChanged += new System.EventHandler(this.cobDesktopList_SelectedIndexChanged);
            this.cobDesktopList.Leave += new System.EventHandler(this.btnSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "选择桌面";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(47, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "桌面位置";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(46, 164);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "桌面壁纸";
            // 
            // txtDesktopBackground
            // 
            this.txtDesktopBackground.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDesktopBackground.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtDesktopBackground.Location = new System.Drawing.Point(163, 161);
            this.txtDesktopBackground.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtDesktopBackground.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtDesktopBackground.Name = "txtDesktopBackground";
            this.txtDesktopBackground.Padding = new System.Windows.Forms.Padding(5);
            this.txtDesktopBackground.ShowText = false;
            this.txtDesktopBackground.Size = new System.Drawing.Size(294, 30);
            this.txtDesktopBackground.TabIndex = 4;
            this.txtDesktopBackground.Text = "默认壁纸";
            this.txtDesktopBackground.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtDesktopBackground.Watermark = "";
            this.txtDesktopBackground.Leave += new System.EventHandler(this.btnSave_Click);
            // 
            // txtDesktopLocation
            // 
            this.txtDesktopLocation.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDesktopLocation.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtDesktopLocation.Location = new System.Drawing.Point(163, 116);
            this.txtDesktopLocation.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtDesktopLocation.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtDesktopLocation.Name = "txtDesktopLocation";
            this.txtDesktopLocation.Padding = new System.Windows.Forms.Padding(5);
            this.txtDesktopLocation.ShowText = false;
            this.txtDesktopLocation.Size = new System.Drawing.Size(294, 30);
            this.txtDesktopLocation.TabIndex = 5;
            this.txtDesktopLocation.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtDesktopLocation.Watermark = "";
            this.txtDesktopLocation.Leave += new System.EventHandler(this.btnSave_Click);
            // 
            // btnSetDesktopLocation
            // 
            this.btnSetDesktopLocation.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSetDesktopLocation.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSetDesktopLocation.Location = new System.Drawing.Point(482, 113);
            this.btnSetDesktopLocation.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnSetDesktopLocation.Name = "btnSetDesktopLocation";
            this.btnSetDesktopLocation.Size = new System.Drawing.Size(99, 33);
            this.btnSetDesktopLocation.TabIndex = 6;
            this.btnSetDesktopLocation.Text = "...";
            this.btnSetDesktopLocation.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSetDesktopLocation.Click += new System.EventHandler(this.btnSetDesktopLocation_Click);
            // 
            // button2
            // 
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button2.Location = new System.Drawing.Point(482, 161);
            this.button2.MinimumSize = new System.Drawing.Size(1, 1);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(99, 30);
            this.button2.TabIndex = 7;
            this.button2.Text = "...";
            this.button2.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnAddDesktop
            // 
            this.btnAddDesktop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddDesktop.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAddDesktop.Location = new System.Drawing.Point(482, 45);
            this.btnAddDesktop.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnAddDesktop.Name = "btnAddDesktop";
            this.btnAddDesktop.Size = new System.Drawing.Size(99, 29);
            this.btnAddDesktop.TabIndex = 8;
            this.btnAddDesktop.Text = "新建桌面";
            this.btnAddDesktop.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAddDesktop.Click += new System.EventHandler(this.btnAddDesktop_Click);
            // 
            // btnChangeDesktop
            // 
            this.btnChangeDesktop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnChangeDesktop.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnChangeDesktop.Location = new System.Drawing.Point(50, 229);
            this.btnChangeDesktop.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnChangeDesktop.Name = "btnChangeDesktop";
            this.btnChangeDesktop.Size = new System.Drawing.Size(151, 61);
            this.btnChangeDesktop.TabIndex = 9;
            this.btnChangeDesktop.Text = "切换至选中桌面";
            this.btnChangeDesktop.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnChangeDesktop.Click += new System.EventHandler(this.btnChangeDesktop_Click);
            // 
            // btnSave
            // 
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSave.Location = new System.Drawing.Point(223, 229);
            this.btnSave.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(177, 61);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "保存选定桌面设置";
            this.btnSave.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "图片|*.jpg|无损图片|*.png|图片|*.jpeg|位图|*.bmp";
            // 
            // txtDesktopName
            // 
            this.txtDesktopName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDesktopName.Enabled = false;
            this.txtDesktopName.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtDesktopName.Location = new System.Drawing.Point(163, 80);
            this.txtDesktopName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtDesktopName.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtDesktopName.Name = "txtDesktopName";
            this.txtDesktopName.Padding = new System.Windows.Forms.Padding(5);
            this.txtDesktopName.ShowText = false;
            this.txtDesktopName.Size = new System.Drawing.Size(294, 30);
            this.txtDesktopName.TabIndex = 13;
            this.txtDesktopName.Text = "默认桌面";
            this.txtDesktopName.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtDesktopName.Watermark = "";
            this.txtDesktopName.TextChanged += new System.EventHandler(this.txtDesktopName_TextChanged);
            this.txtDesktopName.Leave += new System.EventHandler(this.btnSave_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(47, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 20);
            this.label4.TabIndex = 12;
            this.label4.Text = "桌面名称";
            // 
            // btnDeleteDesktop
            // 
            this.btnDeleteDesktop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeleteDesktop.Enabled = false;
            this.btnDeleteDesktop.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDeleteDesktop.Location = new System.Drawing.Point(442, 229);
            this.btnDeleteDesktop.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnDeleteDesktop.Name = "btnDeleteDesktop";
            this.btnDeleteDesktop.Size = new System.Drawing.Size(164, 61);
            this.btnDeleteDesktop.TabIndex = 14;
            this.btnDeleteDesktop.Text = "删除选定桌面";
            this.btnDeleteDesktop.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDeleteDesktop.Click += new System.EventHandler(this.btnDeleteDesktop_Click);
            // 
            // frmMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(656, 342);
            this.Controls.Add(this.btnDeleteDesktop);
            this.Controls.Add(this.txtDesktopName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnChangeDesktop);
            this.Controls.Add(this.btnAddDesktop);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnSetDesktopLocation);
            this.Controls.Add(this.txtDesktopLocation);
            this.Controls.Add(this.txtDesktopBackground);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cobDesktopList);
            this.Name = "frmMain";
            this.Text = "多桌面助手";
            this.ZoomScaleRect = new System.Drawing.Rectangle(19, 19, 584, 315);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.Click += new System.EventHandler(this.btnSave_Click);
            this.Leave += new System.EventHandler(this.btnSave_Click);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cobDesktopList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        
        private Sunny.UI.UITextBox txtDesktopBackground;
        private Sunny.UI.UITextBox txtDesktopLocation;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private Sunny.UI.UIButton btnSetDesktopLocation;
        private Sunny.UI.UIButton button2;
        private Sunny.UI.UIButton btnAddDesktop;
        private Sunny.UI.UIButton btnChangeDesktop;
        private Sunny.UI.UIButton btnSave;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private Sunny.UI.UITextBox txtDesktopName;
        private System.Windows.Forms.Label label4;
        private Sunny.UI.UIButton btnDeleteDesktop;
    }
}


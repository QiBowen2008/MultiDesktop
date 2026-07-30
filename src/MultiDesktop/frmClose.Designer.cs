namespace MultiDesktop
{
    partial class frmClose
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
            btnExit = new AntdUI.Button();
            btnMin = new AntdUI.Button();
            checkbox1 = new AntdUI.Checkbox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft YaHei UI", 15F);
            label1.Location = new Point(55, 33);
            label1.Name = "label1";
            label1.Size = new Size(197, 39);
            label1.TabIndex = 0;
            label1.Text = "确定退出吗？";
            // 
            // btnExit
            // 
            btnExit.DefaultBack = Color.Red;
            btnExit.Font = new Font("Microsoft YaHei UI", 15F);
            btnExit.Location = new Point(34, 159);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(191, 89);
            btnExit.TabIndex = 1;
            btnExit.Text = "退出";
            btnExit.Click += btnExit_Click;
            // 
            // btnMin
            // 
            btnMin.DefaultBack = Color.Green;
            btnMin.Font = new Font("Microsoft YaHei UI", 15F);
            btnMin.Location = new Point(266, 159);
            btnMin.Name = "btnMin";
            btnMin.Size = new Size(187, 89);
            btnMin.TabIndex = 2;
            btnMin.Text = "最小化";
            btnMin.Click += btnMin_Click;
            // 
            // checkbox1
            // 
            checkbox1.Font = new Font("Microsoft YaHei UI", 15F);
            checkbox1.Location = new Point(55, 102);
            checkbox1.Name = "checkbox1";
            checkbox1.Size = new Size(384, 51);
            checkbox1.TabIndex = 3;
            checkbox1.Text = "不再询问";
            // 
            // frmClose
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(477, 294);
            Controls.Add(checkbox1);
            Controls.Add(btnMin);
            Controls.Add(btnExit);
            Controls.Add(label1);
            Font = new Font("Microsoft YaHei UI", 9F);
            Name = "frmClose";
            Text = "确认退出吗";
            FormClosing += frmClose_FormClosing;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private AntdUI.Button btnExit;
        private AntdUI.Button btnMin;
        private AntdUI.Checkbox checkbox1;
    }
}

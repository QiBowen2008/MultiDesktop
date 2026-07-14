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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmClose));
            label1 = new Label();
            btnExit = new AntdUI.Button();
            btnMin = new AntdUI.Button();
            checkbox1 = new AntdUI.Checkbox();
            SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.Name = "label1";
            // 
            // btnExit
            // 
            btnExit.DefaultBack = Color.Red;
            resources.ApplyResources(btnExit, "btnExit");
            btnExit.Name = "btnExit";
            btnExit.Click += btnExit_Click;
            // 
            // btnMin
            // 
            btnMin.DefaultBack = Color.Green;
            resources.ApplyResources(btnMin, "btnMin");
            btnMin.Name = "btnMin";
            btnMin.Click += btnMin_Click;
            // 
            // checkbox1
            // 
            resources.ApplyResources(checkbox1, "checkbox1");
            checkbox1.Name = "checkbox1";
            // 
            // frmClose
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(checkbox1);
            Controls.Add(btnMin);
            Controls.Add(btnExit);
            Controls.Add(label1);
            Name = "frmClose";
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
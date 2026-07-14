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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSet));
            drpColorMode = new AntdUI.Dropdown();
            label1 = new Label();
            label2 = new Label();
            drpExitAction = new AntdUI.Dropdown();
            btnSaveSettings = new AntdUI.Button();
            btnClose = new AntdUI.Button();
            label3 = new Label();
            SuspendLayout();
            // 
            // drpColorMode
            // 
            resources.ApplyResources(drpColorMode, "drpColorMode");
            drpColorMode.Items.AddRange(new object[] { "跟随系统", "浅色", "深色" });
            drpColorMode.Name = "drpColorMode";
            drpColorMode.SelectedValueChanged += drpColorMode_SelectedValueChanged;
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(label2, "label2");
            label2.Name = "label2";
            // 
            // drpExitAction
            // 
            resources.ApplyResources(drpExitAction, "drpExitAction");
            drpExitAction.Items.AddRange(new object[] { "最小化到后台", "退出程序", "询问" });
            drpExitAction.Name = "drpExitAction";
            drpExitAction.SelectedValueChanged += drpExitAction_SelectedValueChanged;
            // 
            // btnSaveSettings
            // 
            btnSaveSettings.DefaultBack = Color.Green;
            resources.ApplyResources(btnSaveSettings, "btnSaveSettings");
            btnSaveSettings.Name = "btnSaveSettings";
            btnSaveSettings.Click += btnSaveSettings_Click;
            // 
            // btnClose
            // 
            btnClose.DefaultBack = Color.Red;
            resources.ApplyResources(btnClose, "btnClose");
            btnClose.Name = "btnClose";
            btnClose.Click += btnClose_Click;
            // 
            // label3
            // 
            resources.ApplyResources(label3, "label3");
            label3.Name = "label3";
            // 
            // frmSet
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label3);
            Controls.Add(btnClose);
            Controls.Add(btnSaveSettings);
            Controls.Add(drpExitAction);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(drpColorMode);
            Name = "frmSet";
            Load += frmSet_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private AntdUI.Dropdown drpColorMode;
        private Label label1;
        private Label label2;
        private AntdUI.Dropdown drpExitAction;
        private AntdUI.Button btnSaveSettings;
        private AntdUI.Button btnClose;
        private Label label3;
    }
}
using I18N.DotNet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static I18N.DotNet.Localizer;

namespace MultiDesktop
{
    public partial class frmAbout : Form
    {
        public frmAbout()
        {
            InitializeComponent();
        }

        private void lnkHomePage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                Process.Start("https://github.com/Qibowen2008/MultiDesktop");
            }
            catch
            {
            }
        }

        private void lnkAntdUI_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                Process.Start("https://gitee.com/AntdUI/AntdUI");
            }
            catch
            {
                MessageBox.Show("https://gitee.com/AntdUI/AntdUI");
            }
        }

        private void lnkAntdUILicense_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                Process.Start("https://gitee.com/AntdUI/AntdUI/LICENSE");
            }
            catch
            {
                MessageBox.Show("Apache-2.0");
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmAbout_Load(object sender, EventArgs e)
        {
            // I18N 国际化
            this.Text = GlobalLocalizer.Localize(this.Text);
            label1.Text = GlobalLocalizer.Localize(label1.Text);
            label3.Text = GlobalLocalizer.Localize(label3.Text);
            label4.Text = GlobalLocalizer.Localize(label4.Text);
            label5.Text = GlobalLocalizer.Localize(label5.Text);
            lnkAntdUILicense.Text = GlobalLocalizer.Localize(lnkAntdUILicense.Text);
            btnOK.Text = GlobalLocalizer.Localize(btnOK.Text);
        }
    }
}

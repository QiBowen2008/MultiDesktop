using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

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
    }
}

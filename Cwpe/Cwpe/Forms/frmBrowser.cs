using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Cwpe.Forms
{
    public partial class frmBrowser : Form
    {
        public frmBrowser()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            webbrowserMain.Navigate(txtUrl.Text.Trim());
        }

        private void frmBrowser_Load(object sender, EventArgs e)
        {
            webbrowserMain.ScriptErrorsSuppressed = true;  
            webbrowserMain.Navigate("http://www.baidu.com");
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Cwpe.Forms
{
    public partial class frmProcessList : Form
    {
        public frmProcessList()
        {
            InitializeComponent();
        }

        public void GetProcess()
        {
            Process[] procesArr = Process.GetProcesses();  //得到所有进程

            int pcount = procesArr.Length;       //进程总数
            foreach (Process p in procesArr)
            {
                ListViewItem obj = new ListViewItem();
                obj.Text = p.ProcessName;
                obj.SubItems.Add(p.Id.ToString());
                //obj.SubItems.Add(p.StartTime.ToString());  //获取进程启动时间 一般禁止访问
                obj.SubItems.Add("");
                obj.SubItems.Add(p.PrivateMemorySize64.ToString());
                listView1.Items.Add(obj);

            }
            label1.Text = "进程数:" + pcount.ToString();
        }

        //选中进程PID
        private void butSelected_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 1)
            {
                Program.PID = listView1.SelectedItems[0].SubItems[1].Text.ToString();
                this.Close();

            }
            else
            {
                MessageBox.Show("您未选择进程或者选择的进程多于一个");
            }
        }


        //刷新进程列表
        private void butRefresh_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            GetProcess();
        }

        private void ProcessListForm_Load(object sender, EventArgs e)
        {
            GetProcess();
        }
    }
}

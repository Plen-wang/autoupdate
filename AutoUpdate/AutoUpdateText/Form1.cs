using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;

namespace AutoUpdateText
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ////自动更新
            //Process isupdate = new Process();
            //isupdate.StartInfo.FileName = Application.StartupPath + "\\AutoUpdate.exe";
            //isupdate.StartInfo.Arguments = "1";
            //isupdate.Start();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //手动更新
            Process isupdate = new Process();
            isupdate.StartInfo.FileName = Application.StartupPath + "\\AutoUpdate.exe";
            isupdate.Start();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using System.Threading;
using AutoUpdateFileWork;

namespace AutoUpdateMaker
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }
        private void FrmMain_Load(object sender, EventArgs e)
        {
            Tb_webpath.Text = Properties.Settings.Default.ServicePath;
            Tb_version.Text = Properties.Settings.Default.AppVersion;
        }
        private void Bt_browser_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                Tb_path.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void Bt_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Bt_execution_Click(object sender, EventArgs e)
        {
            if (Tb_path.Text.Length > 0)
            {
                try
                {
                    progressBar1.Visible = true;
                    //制作升级包
                    progressBar1.Value += 10;
                    ReduceToUnReduceFile.ZipFilenew(Tb_path.Text, Tb_path.Text.Substring(0, Tb_path.Text.LastIndexOf("\\")) + "\\down.zip");
                    //制作升级文件信息
                    progressBar1.Value += 10;
                    string dostring = "<?xml version='1.0' encoding='UTF-8'?><RootServer><Version no='' remark='服务器端版本号'></Version><ServerDownUrl url='' remark='升级地址'></ServerDownUrl><FileZip filename='' hash='' remark='服务器端升级压缩包名称及哈希值'></FileZip></RootServer>";
                    XmlDocument document = new XmlDocument();
                    document.LoadXml(dostring);
                    progressBar1.Value += 10;
                    document.DocumentElement.ChildNodes[0].Attributes["no"].Value = Tb_version.Text;
                    progressBar1.Value += 10;
                    document.DocumentElement.ChildNodes[1].Attributes["url"].Value = Tb_webpath.Text;
                    progressBar1.Value += 10;
                    document.DocumentElement.ChildNodes[2].Attributes["filename"].Value = "down.zip";
                    progressBar1.Value += 10;
                    string hashfilepath = Tb_path.Text.Substring(0, Tb_path.Text.LastIndexOf("\\")) + "\\down.zip";
                    progressBar1.Value += 10;
                    document.DocumentElement.ChildNodes[2].Attributes["hash"].Value = new Hash().GetHash(hashfilepath);
                    progressBar1.Value += 10;
                    progressBar1.Value += 10;
                    document.Save(Tb_path.Text.Substring(0, Tb_path.Text.LastIndexOf("\\")) + "\\ServerUpdateFiles.xml");
                    progressBar1.Value += 10;
                    Properties.Settings.Default.ServicePath = Tb_webpath.Text;
                    Properties.Settings.Default.AppVersion = Tb_version.Text;
                    Properties.Settings.Default.Save();
                    MessageBox.Show("制作成功!");
                    this.Close();
                }
                catch (Exception err) { MessageBox.Show("不能指定空文件夹"); }
            }
        }
    }
}

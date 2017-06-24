using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Net;
using AutoUpdateFileWork;
using System.Threading;
using System.Diagnostics;
using System.IO;
using System.Security.Permissions;

namespace AutoUpdate
{
    public partial class FrmMain : Form
    {
        #region 窗体变量及构造函数
        /// <summary>
        /// 远程下载对象
        /// </summary>
        WebClient downclient = null;
        /// <summary>
        /// 是否已经升级成功
        /// </summary>
        bool isupdate = false;
        /// <summary>
        /// 默认构造函数
        /// </summary>
        public FrmMain()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
        }
        #endregion
        /// <summary>
        /// 开始执行升级
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_update_Click(object sender, EventArgs e)
        {
            Btn_update.Enabled = false;
            Btn_close.Enabled = false;
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.ShowBalloonTip(5000);

            #region 下载远程更新说明xml
            if (DownXml())
            {
                //下载完成后检查是否需要下载更新包
                if (FileWork.IsUpdate())
                {
                    if (Util.GetProcessName())
                    {

                        if (MessageBox.Show(this, "为了更新的顺利完成，请退出应用程序!", "信息提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        {
                            Util.KillProcess();
                        }
                        else
                        {
                            File.Delete(Util.GetDictiory() + "\\ServerUpdateFiles.xml");
                            this.Close();
                            Back_thread.CancelAsync();//取消线程
                        }
                    }
                    //创建事件日志文件
                    LookEventLog();
                    Back_thread.RunWorkerAsync();//开始辅助线程
                }
                else
                {
                    //无需更新
                    MessageBox.Show(this, "您当前是最新版本无需更新!", "信息提示");
                    File.Delete(Util.GetDictiory() + "\\ServerUpdateFiles.xml");
                    this.Close();
                }
            }
            #endregion
        }
        /// <summary>
        /// 关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        /// <summary>
        /// 开始辅助线程操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Back_thread_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                //实例化下载对象
                downclient = new WebClient();
                downclient.Credentials = System.Net.CredentialCache.DefaultNetworkCredentials;//获取发送给远程主机的验证凭据
                downclient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(downclient_DownloadProgressChanged);
                downclient.DownloadFileCompleted += new AsyncCompletedEventHandler(downclient_DownloadFileCompleted);
                //下载远程更新包down.zip压缩文件|放在应用程序目录下|相应界面事件
                downclient.DownloadFileAsync(new Uri(Util.GetUpdateUrl() + "down.zip"), Util.GetDictiory() + "\\down.zip");
            }
            catch (Exception err) { System.Diagnostics.Debug.WriteLine(err); }
            finally { downclient.Dispose(); }
        }
        /// <summary>
        /// 在异步下载结束时触发该事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void downclient_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            try
            {

                if (e.Error != null)
                {
                    Util.WritePrivateProfileString(System.Reflection.MethodInfo.GetCurrentMethod().Name, "下载错误", e.Error.ToString(), "errlog.ini");
                    MessageBox.Show(this, "在进行远程更新时,发生错误", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    Util.KillProcess();//关闭主进程
                    //验证哈希值
                    if (Util.IsHash(Util.GetHash(Util.GetDictiory() + "\\down.zip"), FileWork.GetDownHash()))
                    {
                        //删除无用压缩文件
                        File.Delete(Util.GetDictiory() + "\\down.zip");
                        //删除无用版本文件
                        File.Delete(Util.GetDictiory() + "\\ServerUpdateFiles.xml");
                        MessageBox.Show(this, "远程服务器更新包已发生变化,无法更新", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Util.WritePrivateProfileString("注入提示", "下载错误",
                            "远程服务器中的更新包在制作和下载时间段中数据包发生变化，为了安全期间不给予下载！", "errlog.ini");
                        this.Close();
                    }
                    else
                    {
                        //解压压缩包文件
                        ReduceToUnReduceFile.unZipFile(Util.GetDictiory() + "\\down.zip", Util.GetDictiory());
                        //删除压缩包文件
                        File.Delete(Util.GetDictiory() + "\\down.zip");
                        //检查文件夹层次结构
                        FileWork.LookFiles(Util.GetDictiory() + "\\down", Util.GetDictiory());
                        //订阅复制文件事件
                        FileWork.CopyFileEvent += new FileWork.CopyFileDelegate(FileWork_CopyFileEvent);
                        //递归复制文件
                        FileWork.CopyFiles(Util.GetDictiory() + "\\down", Util.GetDictiory());
                        //删除临时文件夹
                        FileWork.DeleteFiles(Util.GetDictiory() + "\\down");
                        //更新本地版本号信息
                        Util.UpdateLocalXml();
                        File.Delete(Util.GetDictiory() + "\\ServerUpdateFiles.xml");
                        MessageBox.Show(this, "升级成功!", "信息提示");
                        Util.StartProcess();
                        isupdate = true;
                    }
                }
            }
            catch (Exception err)
            {
                Util.WritePrivateProfileString("注入提示", "下载错误", err.ToString(), "errlog.ini");
            }
            finally { downclient.Dispose(); }
            Application.Exit();
        }
        /// <summary>
        /// 拷贝文件
        /// </summary>
        /// <param name="filename">拷贝文件的名称</param>
        void FileWork_CopyFileEvent(string filename)
        {
            Lb_downfile.Items.Add("成功更新文件:" + filename);
        }
        /// <summary>
        /// 在异步下载并成功转换时触发该事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void downclient_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            try
            {
                Lb_count.Text = ((float)e.TotalBytesToReceive / 1024 / 1024).ToString() + " MB";//下载总数
                Lb_rlready.Text = ((float)e.BytesReceived / 1024 / 1024).ToString() + " MB";//已下载总数
                pB.Value = e.ProgressPercentage;
            }
            catch (Exception err)
            {

                Util.WritePrivateProfileString(System.Reflection.MethodInfo.GetCurrentMethod().Name, "下载错误", err.ToString(), "errlog.ini");
            }
            finally { downclient.Dispose(); }
        }
        /// <summary>
        /// 下载远程服务器上的更新xml说明
        /// </summary>
        private bool DownXml()
        {
            try
            {
                downclient = new WebClient();
                downclient.Credentials = System.Net.CredentialCache.DefaultNetworkCredentials;//获取发送给远程主机的验证凭据
                string s = Util.GetUpdateUrl() + "ServerUpdateFiles.xml";
                //先下载远程服务器端的版本文件进行本地比对是否需要进行下载更新包|不触发任何界面事件
                downclient.DownloadFile(new Uri(Util.GetUpdateUrl() + "ServerUpdateFiles.xml"), Util.GetDictiory() + "\\ServerUpdateFiles.xml");
                return true;
            }
            catch (Exception err)
            {
                Util.WritePrivateProfileString(System.Reflection.MethodInfo.GetCurrentMethod().Name, "下载错误", err.ToString(), "errlog.ini");
                MessageBox.Show(this, "服务器连接出错,远程服务器地址错误或没有可更新的文件!", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally { downclient.Dispose(); }
        }
        /// <summary>
        /// 创建事件日志文件|保存所有更新时所发生的错误不便于暴露
        /// </summary>
        [PrincipalPermission(SecurityAction.Assert)]
        private void LookEventLog()
        {
            //远程服务器中的更新包在制作时和更新时的哈希值不同，已被替换过，为了安全不给予更新
            //将写入事件日志
            if (!EventLog.Exists("HZEventLog"))
            {
                EventSourceCreationData eventsource = new EventSourceCreationData("HZ.BidSystem.Manage", "HZEventLog");
                EventLog.CreateEventSource(eventsource);
            }
        }
        /// <summary>
        /// 托盘
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.Visible)
            {
                this.Visible = false;
            }
            else
            {
                this.Visible = true;
            }
            this.WindowState = FormWindowState.Normal;
        }
    }
}

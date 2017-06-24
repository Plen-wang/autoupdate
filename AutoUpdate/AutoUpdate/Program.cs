#define Debug//调试标志
#undef Debug

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Net;
using AutoUpdateFileWork;

namespace AutoUpdate
{
    static class Program
    {
        /// <summary>
        /// 远程下载对象
        /// </summary>
        static WebClient downclient = null;
        /// <summary>
        /// 应用程序入口点
        /// </summary>
        /// <param name="args">1:自动更新</param>
        [STAThread]
        static void Main(string[] args)
        {
            Application.SetCompatibleTextRenderingDefault(false);
            //设置全局代理设置
            FileWork.SetProxyServerValidate();
            if (args.Length > 0)
            {
                #region 判断是否是自动更新
                if (args[0] == "1" || args[0] == "2")
                {
                    if (LookUpdate())
                    {
                        if (FileWork.IsUpdate())
                        {
                            //开启更新页面
                            if (new FrmAlertUpdate().ShowDialog() == DialogResult.Yes)
                            {
                                Application.EnableVisualStyles();
                                Application.Run(new FrmMain());
                            }
                            else
                            {
                                //必须进行强制性的升级
                                File.Delete(Util.GetDictiory() + "\\ServerUpdateFiles.xml");//删除本地更新文件
                                Util.KillProcess();
                            }
                        }
                        else
                        {
                            File.Delete(Util.GetDictiory() + "\\ServerUpdateFiles.xml");//删除本地更新文件
                            if (args[0] == "1")
                                MessageBox.Show("当前系统为最新版本，不需要进行更新。", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
                #endregion

            #region 正常启动更新界面 手动更新
            else
            {
#if Debug //调试输出
                foreach (string i in args)
                {
                    MessageBox.Show(i);
                }
#endif
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new FrmMain());
            }
            #endregion
        }
        /// <summary>
        /// 检查远程服务器上的配置文件是否是最新的更新文件
        /// </summary>
        static bool LookUpdate()
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
#if Debug //调试输出
                MessageBox.Show(err.ToString());

#endif
                return false;
            }
            finally
            {
                downclient.Dispose();
            }

        }
    }
}

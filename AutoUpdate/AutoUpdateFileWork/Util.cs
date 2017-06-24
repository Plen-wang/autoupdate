using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Threading;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Runtime.InteropServices;

namespace AutoUpdateFileWork
{
    /// <summary>
    /// 该类提供下载上下文辅助方法
    /// </summary>
    public static class Util
    {
        /// <summary>
        /// API写ini文件
        /// </summary>
        /// <param name="section">节点</param>
        /// <param name="key">键</param>
        /// <param name="val">值</param>
        /// <param name="filePath">路径</param>
        /// <returns></returns>
        [DllImport("kernel32")]
        public static extern long WritePrivateProfileString(string section, string key, string val, string filePath);

        private static XmlDocument document;
        /// <summary>
        /// 加载升级xml
        /// </summary>
        static Util()
        {
            document = new XmlDocument();
            document.Load(Environment.CurrentDirectory + "\\LocalVersion.xml");
        }
        /// <summary>
        /// 清除进程
        /// </summary>
        public static void KillProcess()
        {
            string appname = document.DocumentElement.ChildNodes[2].Attributes["name"].Value;//本地应用程序名称
            Process[] proce = Process.GetProcessesByName(appname);//获取跟应用程所有关联的系统进程信息
            foreach (Process i in proce)
            {
                if (i.ProcessName == appname)
                {
                    i.CloseMainWindow();
                }
            }
        }
        /// <summary>
        /// 获取应用程序是否已经启动
        /// </summary>
        /// <returns></returns>
        public static bool GetProcessName()
        {
            string appname = document.DocumentElement.ChildNodes[2].Attributes["name"].Value;//本地应用程序名称
            Process[] proce = Process.GetProcessesByName(appname);//获取跟应用程所有关联的系统进程信息
            foreach (Process i in proce)
            {
                if (i.ProcessName == appname)
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// 启动进程
        /// </summary>
        public static void StartProcess()
        {
            try
            {
                string applicationname = document.DocumentElement.ChildNodes[2].Attributes["name"].Value;
                Debug.WriteLine("Run:" + applicationname);//调试输出是否启动应用程序
                Process startproce = new Process();
                startproce.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
                startproce.StartInfo.CreateNoWindow = true;
                startproce.StartInfo.FileName = Environment.CurrentDirectory + "\\" + applicationname + ".exe";
                startproce.Start();
            }
            catch (Exception err)
            {
                System.Windows.Forms.MessageBox.Show(err.ToString());
            }

        }
        /// <summary>
        /// 获取文件的哈希值
        /// </summary>
        /// <param name="filename">文件完整路径名</param>
        /// <remarks>文件效验的哈希值(string)</remarks>
        public static string GetHash(string filename)
        {
            try
            {
                using (FileStream getfile = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    MD5CryptoServiceProvider gethash = new MD5CryptoServiceProvider();//使用MD5环境来生成哈希值
                    byte[] hashbyte = gethash.ComputeHash(getfile);//获取哈希值字节数组
                    string returnbytestrin = BitConverter.ToString(hashbyte);
                    returnbytestrin = returnbytestrin.Replace("-", "");
                    return returnbytestrin;
                }
            }
            catch (Exception err)
            {
                Debug.WriteLine(err);
                return "";
            }
        }
        /// <summary>
        /// 比较远程文件
        /// </summary>
        /// <param name="newhash">更新包制作时的哈希值</param>
        /// <param name="oldhash">下载后的的更新包哈希值</param>
        /// <returns>是否被替换过true:替换过 false:没有</returns>
        public static bool IsHash(string newhash, string oldhash)
        {
            if (newhash != oldhash)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 更新本地文件版本号
        /// </summary>
        /// <param name="newversion">新版本号</param>
        public static void UpdateNewVersion(string newversion)
        {
            XmlAttribute attribute = document.DocumentElement.ChildNodes[0].Attributes["no"];//获取版本号节点
            attribute.Value = newversion;
            document.Save(Environment.CurrentDirectory + "\\LocalVersion.xml");
        }
        /// <summary>
        /// 获取远程更新地址URL
        /// </summary>
        /// <returns>远程更行地址</returns>
        public static string GetUpdateUrl()
        {
            string url = document.DocumentElement.ChildNodes[1].Attributes["url"].Value;
            return url;
        }
        /// <summary>
        /// 文件下载的临时存放目录
        /// </summary>
        /// <returns>临时存放目录</returns>
        public static string GetDictiory()
        {
            return Environment.CurrentDirectory;
        }
        /// <summary>
        /// 更新本地版本号|和下载路径便于以后的下载路径发生变化
        /// </summary>
        public static void UpdateLocalXml()
        {
            document.DocumentElement.ChildNodes[0].Attributes["no"].Value = FileWork.GetDownVersion();
            document.DocumentElement.ChildNodes[1].Attributes["url"].Value = FileWork.GetDownUrl();
            document.Save(GetDictiory() + "\\LocalVersion.xml");
        }

    }
}

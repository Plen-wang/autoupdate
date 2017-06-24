using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;
using System;
using System.Configuration;
using System.Net;

namespace AutoUpdateFileWork
{
    /// <summary>
    /// 该类负责更新检查文件的方法
    /// </summary>
    public static class FileWork
    {
        /// <summary>
        /// 封装拷贝文件的名称
        /// </summary>
        /// <param name="filename"></param>
        public delegate void CopyFileDelegate(string filename);
        /// <summary>
        /// 拷贝文件事件
        /// </summary>
        public static event CopyFileDelegate CopyFileEvent;
        /// <summary>
        /// 复制单个文件
        /// </summary>
        /// <param name="frompath">源地址</param>
        /// <param name="topath">目标地址</param>
        public static void CopyFile(string frompath, string topath)
        {
            FileWork.CopyFile(frompath, topath);
        }
        /// <summary>
        /// 检验是否需要更新
        /// </summary>
        /// <returns>true:需要 false:不需要</returns>
        public static bool IsUpdate()
        {
            XmlDocument document = new XmlDocument();
            document.Load(Util.GetDictiory() + "\\ServerUpdateFiles.xml");
            string newversion = document.DocumentElement.ChildNodes[0].Attributes["no"].Value;
            document.Load(Util.GetDictiory() + "\\LocalVersion.xml");
            string oldversion = document.DocumentElement.ChildNodes[0].Attributes["no"].Value;
            return IsNewVersion(newversion, oldversion);
        }
        /// <summary>
        /// 获取更新包制作时哈希值
        /// </summary>
        /// <returns>哈希值</returns>
        public static string GetDownHash()
        {
            XmlDocument document = new XmlDocument();
            document.Load(Util.GetDictiory() + "\\ServerUpdateFiles.xml");
            return document.DocumentElement.ChildNodes[2].Attributes["hash"].Value;
        }
        /// <summary>
        /// 获取更新包的版本号
        /// </summary>
        /// <returns></returns>
        public static string GetDownVersion()
        {
            XmlDocument document = new XmlDocument();
            document.Load(Util.GetDictiory() + "\\ServerUpdateFiles.xml");
            return document.DocumentElement.ChildNodes[0].Attributes["no"].Value;
        }
        /// <summary>
        /// 获取有可能下次使用的更新地址
        /// </summary>
        /// <returns></returns>
        public static string GetDownUrl()
        {
            XmlDocument document = new XmlDocument();
            document.Load(Util.GetDictiory() + "\\ServerUpdateFiles.xml");
            return document.DocumentElement.ChildNodes[1].Attributes["url"].Value;
        }
        /// <summary>
        /// 比较两个版本号
        /// </summary>
        /// <param name="strNewVersion">新版本号</param>
        /// <param name="strOldVersion">老版本号</param>
        /// <returns>true:新版本号大于老版本号 false相反</returns>
        private static bool IsNewVersion(string strNewVersion, string strOldVersion)
        {
            Version newversion = new Version(strNewVersion);
            Version oldversion = new Version(strOldVersion);
            if (newversion > oldversion)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 递归复制文件
        /// </summary>
        /// <param name="formDirectory">待复制目录</param>
        /// <param name="toDirectory">复制目的地</param>
        public static void CopyFiles(string formDirectory, string toDirectory)
        {
            try
            {
                Directory.CreateDirectory(toDirectory);
                if (Directory.Exists(toDirectory))
                {
                    string[] directory = Directory.GetDirectories(formDirectory);
                    if (directory.Length >= 0)
                    {
                        foreach (string path in directory)
                        {
                            CopyFiles(path, toDirectory + "\\" + path.Substring(path.LastIndexOf("\\")));
                        }
                        string[] fiels = Directory.GetFiles(formDirectory);//最后目录开始复制文件
                        if (fiels.Length >= 0)
                        {
                            foreach (string s in fiels)
                            {
                                File.Copy(s, toDirectory + "\\" + s.Substring(s.LastIndexOf("\\")));
                                CopyFileEvent(s.Substring(s.LastIndexOf("\\")));//触发文件拷贝事件
                            }
                        }
                    }
                }

            }
            catch (Exception err) { }
        }
        /// <summary>
        /// 检查文件|检查远程的更新包中是否包含跟本地相同的文件夹及文件如果有则删除
        /// </summary>
        /// <param name="formdirectory">更新包目录</param>
        /// <param name="todirectory">本地更新目录</param>
        public static void LookFiles(string formdirectory, string todirectory)
        {
            try
            {
                //目录删除
                string[] formdir = Directory.GetDirectories(formdirectory);//获取更新包中文件夹层次
                string[] todir = Directory.GetDirectories(todirectory);//获取将更新的文件夹层次
                for (int j = 0; j < formdir.Length; j++)
                {
                    string filewebbook = formdir[j].Substring(formdir[j].LastIndexOf("\\"));
                    for (int i = 0; i < todir.Length; i++)
                    {
                        string filelocbook = todir[i].Substring(todir[i].LastIndexOf("\\"));
                        if (filewebbook == filelocbook)//有相同的文件夹层次结构则删除
                        {
                            DeleteFiles(todirectory + filelocbook);
                            break;
                        }
                    }

                }
                //文件删除
                string[] formfile = Directory.GetFiles(formdirectory);//获取更新包中的文件列表
                string[] tofile = Directory.GetFiles(todirectory);//获取将更新的文件列表
                for (int j = 0; j < formfile.Length; j++)
                {
                    string newbook = formfile[j].Substring(formfile[j].LastIndexOf("\\")).ToUpper();
                    for (int i = 0; i < tofile.Length; i++)
                    {
                        string locbook = tofile[i].Substring(tofile[i].LastIndexOf("\\")).ToUpper();
                        if (newbook == locbook)
                        {
                            File.Delete(todirectory + locbook);
                            break;
                        }
                    }

                }

            }
            catch (Exception err) { }
        }
        /// <summary>
        /// 递归删除文件
        /// </summary>
        /// <param name="Directorystring">待删除的文件目录</param>
        public static void DeleteFiles(string toDirectory)
        {
            try
            {
                if (Directory.Exists(toDirectory))
                {
                    string[] directory = Directory.GetDirectories(toDirectory);
                    if (directory.Length >= 0)
                    {
                        foreach (string path in directory)
                        {
                            DeleteFiles(path);
                        }
                        string[] fiels = Directory.GetFiles(toDirectory);//最后目录开始删除文件
                        if (fiels.Length >= 0)
                        {
                            foreach (string s in fiels)
                            {
                                File.Delete(toDirectory + "\\" + s.Substring(s.LastIndexOf("\\")));
                            }
                        }
                        Directory.Delete(toDirectory);
                    }
                }
            }
            catch (Exception ex) { }
        }
        /// <summary>
        /// 全局HTTP代理服务器验证凭据初始化
        /// </summary>
        public static void SetProxyServerValidate()
        {
            System.Net.GlobalProxySelection.Select.Credentials = System.Net.CredentialCache.DefaultNetworkCredentials;//获取发送给远程主机的验证凭据
        }
    }
}

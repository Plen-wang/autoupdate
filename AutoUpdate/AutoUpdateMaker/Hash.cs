using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Security.Cryptography;
using System.Diagnostics;

namespace AutoUpdateMaker
{
    public class Hash
    {
        public string GetHash(string filename)
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
    }
}

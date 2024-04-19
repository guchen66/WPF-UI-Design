using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Sample2.Providers
{
    public class MD5Provider
    {
        public static string GetMD5String(string str)
        {
            MD5 md5 = MD5.Create();//把MD5当成一种哈希算法
            byte[] pws = md5.ComputeHash(Encoding.UTF8.GetBytes(str));//它重新排列了str的哈希数
            string pwd = "";
            foreach (var item in pws) //然后把排列的哈希数打印出来
            {
                pwd += item.ToString("X2");//转16进制，前面不足2位的补齐
            }
            return pwd;
        }
    }
}

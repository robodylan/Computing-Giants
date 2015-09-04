using System;
using System.Security.Cryptography;
using System.Text;

namespace Computing_Giants
{
    class Utils
    {
        public static string GetMD5(string source)
        {
            using (MD5 md5 = MD5.Create())
            {
                return BitConverter.ToString(md5.ComputeHash(Encoding.UTF8.GetBytes(source))).Replace("-", string.Empty).ToLower();
            }
        }
    }
}

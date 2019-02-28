using System;
using System.IO;
using System.Security.Cryptography;

namespace Exodus.Version.Checker.Compare.Cryptography
{
    public class MD5Crypto
    {
        public static string GetMD5(string FileName)
        {
            using (MD5 md = MD5.Create())
            {
                using (var Stream = new BufferedStream(File.OpenRead(FileName), 1200000))
                {
                    var bytes = md.ComputeHash(Stream);
                    var Hash = BitConverter.ToString(bytes).Replace("-", String.Empty);
                    return Hash;
                }
            }
        }
    }
}

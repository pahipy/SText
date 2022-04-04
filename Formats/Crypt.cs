using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace SText.Formats
{
    static class Crypt
    {

        private static readonly byte[] Salt = new byte[] { 0x8b, 0x3c, 0x52, 0xa6, 0x32, 0xc2, 0xbe, 0xf3 };
        private static readonly int Iterations = 300;
        private static readonly int KeyBytes = 32;

        public static byte[] EncryptStringToBytes(string enc, string key)
        {
            Aes aes = Aes.Create();
            Rfc2898DeriveBytes keyGen = new Rfc2898DeriveBytes(key, Salt, Iterations);
            aes.Key = keyGen.GetBytes(KeyBytes);
            aes.IV = GetIV(aes.Key);
            byte[] encrypted;
            
            ICryptoTransform encryptor = aes.CreateEncryptor();

            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                {
                    using (StreamWriter sw = new StreamWriter(cs))
                    {
                        sw.Write(enc);
                        sw.Close();
                    }
                }
                encrypted = ms.ToArray();
            }
            return encrypted;
        }

        public static string DecryptStringFromBytes(byte[] dec, string key)
        {
            string text = null;

            using (Aes aes = Aes.Create())
            {
                Rfc2898DeriveBytes keyGen = new Rfc2898DeriveBytes(key, Salt, Iterations);
                aes.Key = keyGen.GetBytes(KeyBytes);
                aes.IV = GetIV(aes.Key);

                ICryptoTransform decryptor = aes.CreateDecryptor();

                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader sr = new StreamReader(cs))
                        {
                            text = sr.ReadToEnd();
                        }
                    }
                }
            }

            return text;
        }

        private static byte[] GetIV(byte[] key)
        {
            byte[] iv = new byte[key.Length / 2];
            for (int i = 0; i < key.Length / 2; i++)
                iv[i] = (byte)key[i].GetHashCode();
            return iv;
        }

    }
}

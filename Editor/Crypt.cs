using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace SText.Editor
{
    static class Crypt
    {
        
        public static byte[] EncryptStringToBytes(string enc, string key)
        {
            Aes aes = Aes.Create();
            byte[] keyBytes = Encoding.UTF8.GetBytes(key);
            aes.Key = keyBytes;
            aes.IV = GetIV(keyBytes);
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
            byte[] keyBytes = Encoding.UTF8.GetBytes(key);

            using (Aes aes = Aes.Create())
            {
                aes.Key = keyBytes;
                aes.IV = GetIV(keyBytes);

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
            byte[] iv = new byte[key.Length];
            for (int i = 0; i < key.Length; i++)
                iv[i] = (byte)key[i].GetHashCode();
            return iv;
        }

    }
}

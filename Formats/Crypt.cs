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

        public static byte[] EncryptStringToBytes(string enc, string key, Encoding encoding)
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
                    using (BinaryWriter bw = new BinaryWriter(cs))
                    {
                        bw.Write(encoding.GetBytes(enc));
                    }
                }
                encrypted = ms.ToArray();
            }
            return encrypted;
        }

        public static string DecryptStringFromBytes(byte[] dec, string key, Encoding encoding)
        {
            string text = "";

            using (Aes aes = Aes.Create())
            {
                Rfc2898DeriveBytes keyGen = new Rfc2898DeriveBytes(key, Salt, Iterations);
                aes.Key = keyGen.GetBytes(KeyBytes);
                aes.IV = GetIV(aes.Key);

                ICryptoTransform decryptor = aes.CreateDecryptor();

                try
                {
                    using (MemoryStream ms = new MemoryStream(dec))
                    {
                        using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                        {
                            using (BinaryReader br = new BinaryReader(cs))
                            {
                                byte[] allData = ReadAllBytesFromBinaryReader(br);
                                text = encoding.GetString(allData);
                            }
                        }
                    }
                }
                catch
                {
                    text = "";
                }

            }

            return text;
        }

        private static byte[] GetIV(byte[] key)
        {
            byte[] iv = new byte[KeyBytes / 2];

            SHA256 sha256 = SHA256.Create();
            byte[] hash = sha256.ComputeHash(key);

            for (int i = 0; i < iv.Length; i++)
                iv[i] = hash[i];

            return iv;
        }

        private static byte[] ReadAllBytesFromBinaryReader(BinaryReader br)
        {
            const int bufferSize = 4096;
            using (MemoryStream ms = new MemoryStream())
            {
                byte[] buff = new byte[bufferSize];
                int count;
                while ((count = br.Read(buff, 0, bufferSize)) != 0)
                    ms.Write(buff, 0, count);

                return ms.ToArray();
            }
        }

        public static byte[] GetSHA256Hash(string str)
        {
            SHA256 sha256 = SHA256.Create();
            return sha256.ComputeHash(Encoding.UTF8.GetBytes(str));
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SText.Formats
{
    public class STXTFormat : IFormat
    {
        #region FileStruct

        private const string HEAD = "STXT";

        private byte[] hash;
        private int dataSize;
        private byte[] data;

        #endregion



        private const int HASH_SIZE = 32; //sha256

        public STXTFormat(string path, string key)
        {
            this.path = path;
            if (File.Exists(path))
                fileStream = new FileStream(path, FileMode.Open, FileAccess.ReadWrite);
            else
                fileStream = File.Create(path);

            this.key = key;
        }

        private string key;

        private int code = 0; //0 - success, 1 hash sum is not equivalent, 2 - bad header, 3 file not exists
        public int Code
        {
            get => code;
        }

        private string path;
        public string Path
        {
            get => path;
        }

        private FileStream fileStream;


        public void WriteFile(string text)
        {
            if (!File.Exists(path))
                fileStream = File.Create(path);

            fileStream.Position = 0;

            data = Crypt.EncryptStringToBytes(text, key);
            hash = Crypt.GetSHA256Hash(text);
            dataSize = data.Length;

            using (BinaryWriter bw = new BinaryWriter(fileStream))
            {
                bw.Write(HEAD);
                bw.Write(hash);
                bw.Write(dataSize);
                bw.Write(data);
            }

            ReopenStream();

            code = 0;
        }

        public string ReadFile()
        {
            if (!File.Exists(path))
            {
                code = 3;
                return null;
            }

            fileStream.Position = 0;

            using (BinaryReader br = new BinaryReader(fileStream))
            {
                string head = br.ReadString();

                if (head != HEAD)
                {
                    code = 2;
                    return null;
                }
                    
                hash = br.ReadBytes(HASH_SIZE);
                dataSize = br.ReadInt32();
                data = br.ReadBytes(dataSize);
            }

            string text = Crypt.DecryptStringFromBytes(data, key);
            if (!hash.SequenceEqual(Crypt.GetSHA256Hash(text)))
            {
                code = 1;
                return null;
            }
                
            code = 0;
            ReopenStream();
            return text;
        }

        public void CloseFile()
        {
            if (File.Exists(path))
                fileStream.Close();
        }

        public int OpenAgain()
        {
            if (File.Exists(path))
            {
                ReopenStream();
                return 0;
            }

            return 1;
        }

        public static bool IsStxtFile(string path)
        {
            if (!File.Exists(path))
                return false;

            try
            {
                string head = "";

                using (BinaryReader br = new BinaryReader(File.OpenRead(path)))
                {
                    head = br.ReadString();
                }

                return head == HEAD;
            }
            catch
            {
                return false;
            }

        }

        private void ReopenStream()
        {
            fileStream = new FileStream(path, FileMode.Open, FileAccess.ReadWrite);
        }

    }
}

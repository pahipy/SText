using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SText.Editor
{
    public class STXTFormat
    {
        #region FileStruct

        private const string HEAD = "STXT";

        private int hash;
        private int size;
        private byte[] data;

        #endregion

        private string path;
        private string key;
        private int code = 0; //0 - success, 1 hash sum is not equivalent, 2 - bad header, 3 file not exists
        public int Code
        {
            get => code;
        }

        private FileStream fileStream;

        public STXTFormat(string path, string key)
        {
            this.path = path;
            if (File.Exists(path))
                fileStream = new FileStream(path, FileMode.Open, FileAccess.ReadWrite);
            else
                fileStream = File.Create(path);

            this.key = key;
        }

        public void WriteFile(string text)
        {
            if (!File.Exists(path))
                fileStream = File.Create(path);

            fileStream.Position = 0;

            data = Crypt.EncryptStringToBytes(text, key);
            hash = text.GetHashCode();
            size = data.Length;

            using (BinaryWriter bw = new BinaryWriter(fileStream))
            {
                bw.Write(HEAD);
                bw.Write(hash);
                bw.Write(size);
                bw.Write(data);
            }

            fileStream.Position = 0;
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
                    
                hash = br.ReadInt32();
                size = br.ReadInt32();
                data = br.ReadBytes(size);
            }

            string text = Crypt.DecryptStringFromBytes(data, key);

            if (text.GetHashCode() != hash)
            {
                code = 1;
                return null;
            }
                
            code = 0;
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
                fileStream = new FileStream(path, FileMode.Open, FileAccess.ReadWrite);
                return 0;
            }

            return 1;
        }

        public static bool IsStxtFile(string path)
        {
            if (!File.Exists(path))
                return false;

            BinaryReader br = new BinaryReader(File.OpenRead(path));

            string head = br.ReadString();

            br.Close();

            return head == HEAD;

        }

    }
}

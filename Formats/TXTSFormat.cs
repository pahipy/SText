using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SText.Formats
{
    public class TXTSFormat : IFormat
    {
        #region FileStruct

        private const string HEAD = "TXTS";

        private byte[] hash;
        private int encodingCode; //std codepage number
        private int dataSize;
        private byte[] data;

        #endregion



        private const int HASH_SIZE = 32; //sha256

        public TXTSFormat(string path, string key)
        {
            this.path = path;

            if (File.Exists(path))
            {
                ReopenStream();
            }
            else
            {
                fileStream = File.Create(path);
                isReadOnly = false;
            }

            this.key = key;

            this.Encoding = Encoding.UTF8;
        }

        public TXTSFormat(string path, string key, Encoding encoding) : this(path, key)
        {
            this.Encoding = encoding;
        }

        private string key;
        private Encoding enc;
        public Encoding Encoding
        {
            get => enc;
            set
            {
                if (value is not null)
                {
                    enc = value;
                    encodingCode = value.CodePage;
                }
            }
        }

        private int code = 0; //0 - success, 1 hash sum is not equivalent, 2 - bad header, 3 file not exists
        public int Code
        {
            get => code;
        }

        public string Password
        {
            get => key;
        }

        private string path;
        public string Path
        {
            get => path;
        }

        private bool isReadOnly;
        public bool IsReadOnly
        {
            get => isReadOnly;
        }

        private FileStream fileStream;


        public void WriteFile(string text)
        {
            if (!File.Exists(path))
                fileStream = File.Create(path);

            fileStream.Position = 0;

            data = Crypt.EncryptStringToBytes(text, key, Encoding);
            hash = Crypt.GetSHA256Hash(text, Encoding);
            dataSize = data.Length;

            using (BinaryWriter bw = new BinaryWriter(fileStream))
            {
                bw.Write(HEAD);
                bw.Write(hash);
                bw.Write(encodingCode);
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
                this.Encoding = Encoding.GetEncoding(br.ReadInt32());
                dataSize = br.ReadInt32();
                data = br.ReadBytes(dataSize);
            }

            string text = Crypt.DecryptStringFromBytes(data, key, this.Encoding);
            if (!hash.SequenceEqual(Crypt.GetSHA256Hash(text, Encoding)))
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

        public static bool IsTXTSFile(string path)
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
            try
            {
                fileStream = new FileStream(path, FileMode.Open, FileAccess.ReadWrite);
                isReadOnly = false;
            }
            catch
            {
                fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
                isReadOnly = true;
            }
        }

    }
}

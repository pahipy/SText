using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Pipes;

namespace SText.Formats
{
    public class TXTSFormat : Format
    {
        #region FileStruct

        private const string HEAD = "TXTS";

        private byte[] hash;
        private int encodingCode; //std codepage number
        private uint dataSize;
        private byte[] data;

        #endregion



        private const int HASH_SIZE = 32; //sha256

        public TXTSFormat(string path, string key) : base(path)
        {
            this.path = path;
            this.key = key;

            using (MemoryStream ms = new MemoryStream(_content))
            {
                using (BinaryReader br = new BinaryReader(ms))
                {
                    string head = br.ReadString();

                    if (head != HEAD)
                    {
                        code = 2;
                        return;
                    }

                    hash = br.ReadBytes(HASH_SIZE);
                    this.FileEncoding = Encoding.GetEncoding(br.ReadInt32());
                    dataSize = br.ReadUInt32();
                    data = br.ReadBytes((int)dataSize);
                }
            }

            decryptedContent = Crypt.DecryptStringFromBytes(data, key, this.FileEncoding);

            if (!hash.SequenceEqual(Crypt.GetSHA256Hash(decryptedContent, FileEncoding)))
            {
                code = 1;
                return;
            }

            code = 0;

        }

        public TXTSFormat(string path, string key, Encoding encoding) : this(path, key)
        {
            this.FileEncoding = encoding;
        }

        private string key;
        public new Encoding FileEncoding
        {
            get => fileEncoding;
            set
            {
                if (value is not null)
                {
                    fileEncoding = value;
                    encodingCode = value.CodePage;
                }
            }
        }

        private int code = 0; //0 - success, 1 hash sum is not equivalent, 2 - bad header
        public int Code
        {
            get => code;
        }

        public string Password
        {
            get => key;
        }

        private string decryptedContent;

        public override string Content
        {
            get => decryptedContent;
        }

        public override bool WriteFile(string content)
        {
            if (isReadOnly)
                return false;
            
            data = Crypt.EncryptStringToBytes(content, key, FileEncoding);
            hash = Crypt.GetSHA256Hash(content, FileEncoding);
            dataSize = (uint)data.Length;

            using (MemoryStream ms = new MemoryStream())
            {
                using (BinaryWriter bw = new BinaryWriter(ms))
                {
                    bw.Write(HEAD);
                    bw.Write(hash);
                    bw.Write(encodingCode);
                    bw.Write(dataSize);
                    bw.Write(data);

                    _content = ms.ToArray();
                }
            }

            code = 0;

            base.WriteFile();

            decryptedContent = content;

            return true;
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


    }
}

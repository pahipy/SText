using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.Sockets;

namespace SText.Formats
{
    public class TXTFormat : IFormat
    {
        public TXTFormat(string path)
        {
            this.path = path;

            if (path is not null)
            {
                if (File.Exists(path))
                {
                    ReopenStream();
                }
                else
                {
                    fs = File.Create(path);
                    isReadOnly = false;
                }

                    fileEncoding = Encoding.UTF8;
            }
            else
            {
                throw new Exception("path should't null here");
            }                
        }

        public TXTFormat(string path, Encoding fileEncoding) : this(path)
        {
            this.fileEncoding = fileEncoding;
        }

        private FileStream fs;

        private Encoding fileEncoding;
        public Encoding FileEncoding
        {
            get => fileEncoding;
            set => fileEncoding = value;
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

        public string ReadFile()
        {
            fs.Position = 0;

            string content;

            using (TextReader tr = new StreamReader(fs, fileEncoding))
            {
                content = tr.ReadToEnd();
            }

            ReopenStream();

            return content;
        }

        public void WriteFile(string content)
        {
            if (isReadOnly)
                return;

            fs.Position = 0;

            fs.SetLength(0);

            using (BinaryWriter bw = new BinaryWriter(fs))
            {
                bw.Write(fileEncoding.GetBytes(content));
            }

            ReopenStream();
        }

        public static Encoding GetEncoding(string path)
        {
            using (FileStream fileStream = File.OpenRead(path))
            {
                Ude.CharsetDetector charsetDetector = new Ude.CharsetDetector();
                charsetDetector.Feed(fileStream);
                charsetDetector.DataEnd();
                
                if (charsetDetector.Charset != null)
                {
                    return Encoding.GetEncoding(charsetDetector.Charset);
                }
       
            }
            return Encoding.UTF8;
        }

        public void CloseFile()
        {
            if (fs is not null)
                fs.Close();

            fs = null;
        }

        private void ReopenStream()
        {
            try
            {
                fs = new FileStream(path, FileMode.Open, FileAccess.ReadWrite);
                isReadOnly = false;
            }
            catch
            {
                fs = new FileStream(path, FileMode.Open, FileAccess.Read);
                isReadOnly = true;
            }
        }

    }
}

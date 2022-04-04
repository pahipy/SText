using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SText.Formats
{
    public class TXTFormat : IFormat
    {
        public TXTFormat(string path)
        {
            if (path is not null)
            {
                if (File.Exists(path))
                {
                    fs = new FileStream(path, FileMode.Open, FileAccess.ReadWrite);
                }
                else
                {
                    fs = File.Create(path);
                }
                this.path = path;
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
            fs.Position = 0;

            fs.SetLength(0);

            using (BinaryWriter bw = new BinaryWriter(fs))
            {
                bw.Write(fileEncoding.GetBytes(content));
            }

            ReopenStream();
        }

        private void ReopenStream()
        {
            fs = new FileStream(path, FileMode.Open, FileAccess.ReadWrite);
        }

    }
}

using System.IO;
using System.Text;

namespace SText.Formats
{
    public abstract class Format
    {
        protected string path;
        public string Path
        {
            get => path;
        }
        
        public bool IsReadOnly
        {
            get => isReadOnly;
        }
        protected bool isReadOnly;

        public virtual string Content 
        { 
            get => fileEncoding.GetString(_content);
        }

        protected Encoding fileEncoding = null;
        public Encoding FileEncoding
        {
            get => fileEncoding;
            set => fileEncoding = value;
        }

        protected byte[] _content = new byte[16];

        public Format(string path)
        {
            this.path = path;

            if (path is not null)
            {
                if (!File.Exists(path))
                {
                    File.Create(path).Close();
                    isReadOnly = false;
                }
                else
                {
                    _content = File.ReadAllBytes(path);
                    isReadOnly = new FileInfo(path).IsReadOnly;

                    if (fileEncoding is null)
                    {
                        Ude.CharsetDetector charsetDetector = new Ude.CharsetDetector();
                        charsetDetector.Feed(_content, 0, _content.Length);
                        charsetDetector.DataEnd();

                        if (charsetDetector.Charset is not null)
                        {
                            fileEncoding = Encoding.GetEncoding(charsetDetector.Charset == "ASCII" ? "UTF-8" : charsetDetector.Charset);
                        }
                        else
                        {
                            fileEncoding = Encoding.UTF8;
                        }
                        
                    }
                }

            }
            else
            {
                throw new Exception("Path should't null there");
            }
        }

        public Format(string path, Encoding fileEncoding) : this(path)
        {
            this.fileEncoding = fileEncoding;
        }

        public virtual bool WriteFile(string content)
        {
            if (isReadOnly)
                return false;

            _content = fileEncoding.GetBytes(content);

            WriteFile();

            return true;
        }
        protected void WriteFile()
        {
            var fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);

            fs.Position = 0;

            fs.SetLength(0);

            using (BinaryWriter bw = new BinaryWriter(fs))
            {
                bw.Write(_content);
            }

            fs.Close();
        }

    }
}
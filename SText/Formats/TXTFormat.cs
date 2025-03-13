using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.Sockets;

namespace SText.Formats
{
    public class TXTFormat : Format
    {
        public TXTFormat(string path) : base(path)
        {
        }

        public TXTFormat(string path, Encoding fileEncoding) : base(path, fileEncoding)
        {
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SText
{
    static class EncodingHelper
    {
        public static Encoding GetFileEncoding(string srcFile)

        {

            // *** Use Default of Encoding.Default (Ansi CodePage)

            Encoding enc = Encoding.Default;



            // *** Detect byte order mark if any - otherwise assume default

            byte[] buffer = new byte[5];

            FileStream file = new FileStream(srcFile, FileMode.Open);

            file.Read(buffer, 0, 5);

            file.Close();



            if (buffer[0] == 0xef && buffer[1] == 0xbb && buffer[2] == 0xbf)

                enc = Encoding.UTF8;

            else if (buffer[0] == 0xfe && buffer[1] == 0xff)

                enc = Encoding.Unicode;

            else if (buffer[0] == 0 && buffer[1] == 0 && buffer[2] == 0xfe && buffer[3] == 0xff)

                enc = Encoding.UTF32;

            else if (buffer[0] == 0x2b && buffer[1] == 0x2f && buffer[2] == 0x76)

                enc = Encoding.UTF7;



            return enc;

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SText.Conf;

namespace SText.Editor
{
    class TemporaryFileManager
    {
        private static FileStream fileStream;
        private static string pathToFile = $"{GlobalSettingsManager.DirectoryConf}/{ProgramSets.TemporaryFileName}";

        public static string PathToFile { get => pathToFile; }

        public static void WriteToFile(string content)
        {
            if (File.Exists(pathToFile)) 
                File.Delete(pathToFile);

            fileStream = new FileStream(pathToFile, FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fileStream);
            sw.Write(content);
            sw.Close();
            fileStream.Close();
        }

        public static string ReadFromFile()
        {
            fileStream = new FileStream(pathToFile, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fileStream);
            string res = sr.ReadToEnd();
            sr.Close();
            fileStream.Close();
            return res;
        }

    }
}

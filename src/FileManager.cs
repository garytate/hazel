using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Hazel
{
    class FileManager
    {
        public List<string> getAllLogs(string directory)
        {
            List<string> logFiles = new List<string>();
            if (!Directory.Exists(directory + "\\logs"))
            {
                Directory.CreateDirectory(directory + "\\logs");
                Console.WriteLine("Copy your log files into the /logs folder then press any key.");
                Console.ReadKey();
            }
            foreach (string file in Directory.EnumerateFiles((directory + "\\logs"), "*.txt"))
            {
                logFiles.Add(file);
            }
            return logFiles;

        }
    }
}

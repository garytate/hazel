using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Hazel
{
    class FileManager
    {
        public List<string> GetAllLogs(string directory)
        {
            List<string> logFiles = new List<string>();
            string logDirectory = $@"{directory}\logs";
            
            // Create log folder if not existant.
            if (!Directory.Exists(logDirectory))
            {
                Directory.CreateDirectory(logDirectory);
                Console.WriteLine("Copy your log files into the /logs folder then press any key.");
                Console.ReadKey();
            }

            // Collect all log files into a List<string>
            foreach (string file in Directory.EnumerateFiles((logDirectory), "*.txt"))
            {
                logFiles.Add(file);
            }

            // List<string> - file paths of all log files.
            return logFiles;

        }
    }
}

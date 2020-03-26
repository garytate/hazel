using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Diagnostics;

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
            }

            // Collect all log files into a List<string>
            foreach (string file in Directory.GetFiles((logDirectory), "*.txt"))
            {
                logFiles.Add(file);
            }

            // List<string> - file paths of all log files.
            return logFiles;

        }
    }
}
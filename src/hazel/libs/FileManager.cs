using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Globalization;

namespace Hazel
{
    class FileManager
    {
        public Dictionary<string, DateTime> GetAllLogs(string directory)
        {
            Dictionary<string, DateTime> LogFiles = new Dictionary<string, DateTime>();
            string logDirectory = $@"{directory}\logs";

            // Create log folder if no existant
            if (!Directory.Exists(logDirectory))
                Directory.CreateDirectory(logDirectory);

            // Collect all logs and place them into the dictionary
            foreach (var log in Directory.GetFiles((logDirectory), "*.txt"))
            {
                string file = Path.GetFileNameWithoutExtension(Path.GetFileName(log));
                DateTime date = DateTime.ParseExact(file, "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None);
                LogFiles.Add(log, date);
            }

            return LogFiles;
        }

        /*
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
        */
    }
}
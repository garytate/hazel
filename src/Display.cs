using System;
using System.Collections.Generic;
using Octokit;

namespace Hazel
{
    public class Display
    {
        public void DisplayMenu(string[] options, List<string> logs, List<string> chars)
        {

            Console.WriteLine("Files Loaded: {0} || Characters Loaded: {1}", logs.Count, chars.Count);
            for (int i = 0; i < options.Length; i++)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("[{0}] ", i + 1);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(options[i]);
            }
            Console.ResetColor();

        }

        public async void NotifyRelease(string appVersion)
        {
            // Github Release Check
            var client = new GitHubClient(new ProductHeaderValue("hazel"));
            var releases = await client.Repository.Release.GetAll("garytate", "hazel");
            var latest = releases[0];

            if (appVersion != latest.TagName)
            {
                Console.WriteLine("There is a new update at https://github.com/garytate/hazel/releases");
            }

        }

    }
}

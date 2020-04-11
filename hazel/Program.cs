using System;
using System.Collections.Generic;
using Octokit;

namespace Hazel
{
    class Program
    {

        private static Random _random = new Random();
        private static ConsoleColor GetRandomConsoleColor()
        {
            var consoleColors = Enum.GetValues(typeof(ConsoleColor));
            return (ConsoleColor)consoleColors.GetValue(_random.Next(consoleColors.Length));
        }

        static void Main(string[] args)
        {

            // Class imports
            Display displayObj = new Display();
            FileManager fileManagerObj = new FileManager();
            Character characterObj = new Character();
            Activity activityObj = new Activity();
            Keywords keywordObj = new Keywords();
            Container ContainerObj = new Container();
            Transfer TransferObj = new Transfer();

            // Initialising the program
            string appTitle = "hazel";
            string appVersion = "20.03f";
            string appAuthor = "Gary Tate";
            string appDirectory = System.Environment.CurrentDirectory;
            bool active = true;

            string[] options = {
                "Reload Files",
                "Select Timerange [WIP]",
                "Check Activity",
                "Search for Keywords",
                "Get Log Files",
                "Get Characters",
                "Get Containers",
                "Check Transfers",
                "Quit Program"
            };

            // Check for latest release
            displayObj.NotifyRelease(appVersion);

            // Welcome Message
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("{0}: Version {1} maintained by {2}.\n", appTitle, appVersion, appAuthor);
            Console.ResetColor();

            List<string> logFiles = fileManagerObj.GetAllLogs(appDirectory);
            List<string> characters = characterObj.GetAllCharacters(appDirectory);

            while (active)
            {
                displayObj.DisplayMenu(options, logFiles, characters);
                Console.Write("> ");
                string keyInput = Console.ReadKey().Key.ToString();
                char input = keyInput[keyInput.Length - 1];
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("{0}: Version {1} maintained by {2}.\n", appTitle, appVersion, appAuthor);
                Console.ResetColor();
                switch (input)
                {
                    case '1':
                        //Reload Characters
                        logFiles = fileManagerObj.GetAllLogs(appDirectory);
                        Console.WriteLine("Files reloaded.");
                        break;
                    case '2':
                        // Select log timerange
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("{0} not yet supported.", options[1]);
                        Console.ResetColor();
                        break;
                    case '3':
                        // Check Activity
                        activityObj.DisplayActivity(appDirectory, characters, logFiles);
                        break;
                    case '4':
                        // Check for Keywords
                        List<string> keywords = keywordObj.GetKeywords();
                        keywordObj.DisplayKeywords(appDirectory, characters, logFiles, keywords);
                        break;
                    case '5':
                        // Get Log Files
                        foreach (string logFile in logFiles)
                        {
                            Console.WriteLine(logFile);
                        }
                        break;
                    case '6':
                        // Get Characters
                        foreach (string character in characters)
                        {
                            Console.WriteLine(character);
                        }
                        break;
                    case '7':
                        // containers
                        ContainerObj.ReturnAllContainers(logFiles);
                        break;
                    case '8':
                        List<TokenTransfer> transfers = TransferObj.GetTokenTransfers(logFiles);
                        List<TokenTransfer> potential = TransferObj.GetPotentialTransfers(transfers);

                        Int32 colorMatcher = 0;

                        foreach (TokenTransfer log in potential)
                        {
                            if (colorMatcher % 2 == 0) Console.ForegroundColor = ConsoleColor.Yellow;
                            else Console.ForegroundColor = ConsoleColor.Yellow;

                            Console.WriteLine($" {log.container} :: {log.character} - {log.steam} - {log.steamID}");
                            Console.ResetColor();
                            Console.WriteLine(log.log);

                            if (colorMatcher % 2 != 0) Console.Write("\n");
                            colorMatcher++;
                        }

                        Console.ReadKey();
                        break;
                    case '9':
                        // Exit program
                        System.Environment.Exit(1);
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Incorrect option.");
                        Console.ResetColor();
                        break;
                }
                Console.WriteLine();

            }
        }
    }
}
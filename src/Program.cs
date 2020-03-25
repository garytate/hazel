using System;
using System.Collections.Generic;

namespace Hazel
{
    class Program
    {
        static void Main(string[] args)
        {

            // Class imports
            Display displayObj = new Display();
            FileManager fileManagerObj = new FileManager();
            Character characterObj = new Character();
            Activity activityObj = new Activity();
            Keywords keywordObj = new Keywords();
            Container ContainerObj = new Container();
            
            // Initialising the program
            string appTitle = "Hazel";
            string appVersion = "20.3c";
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
                "Quit Program"
            };

            // Welcome Message
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("{0}: Version {1} maintained by {2}.\n", appTitle, appVersion, appAuthor);
            Console.ResetColor();

            List<string> logFiles = fileManagerObj.GetAllLogs(appDirectory);
            List<string> characters = characterObj.GetAllCharacters(appDirectory);

            while (active) {
                displayObj.DisplayMenu(options, logFiles, characters);
                Console.Write("> ");
                string keyInput = Console.ReadKey().Key.ToString();
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("{0}: Version {1} maintained by {2}.\n", appTitle, appVersion, appAuthor);
                Console.ResetColor();
                switch (keyInput)
                {
                    case "D1":
                        //Reload Characters
                        logFiles = fileManagerObj.GetAllLogs(appDirectory);
                        Console.WriteLine("Files reloaded.");
                        break;
                    case "D2":
                        // Select log timerange
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("{0} not yet supported.", options[1]);
                        Console.ResetColor();
                        break;
                    case "D3":
                        // Check Activity
                        activityObj.DisplayActivity(appDirectory, characters, logFiles);
                        break;
                    case "D4":
                        // Check for Keywords
                        List<string> keywords = keywordObj.GetKeywords();
                        keywordObj.DisplayKeywords(appDirectory, characters, logFiles, keywords);
                        break;
                    case "D5":
                        // Get Log Files
                        foreach (string logFile in logFiles)
                        {
                            Console.WriteLine(logFile);
                        }
                        break;
                    case "D6":
                        // Get Characters
                        foreach (string character in characters)
                        {
                            Console.WriteLine(character);
                        }
                        break;
                    case "D7":
                        // containers
                        ContainerObj.ReturnAllContainers(logFiles);
                        break;
                    case "D8":
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

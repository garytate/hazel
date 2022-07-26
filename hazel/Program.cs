using Hazel.Modules;

namespace Hazel;

public class Program
{
    private static readonly Random _random = new();

    private static ConsoleColor GetRandomConsoleColor()
    {
        var consoleColors = Enum.GetValues(typeof(ConsoleColor));
        return (ConsoleColor)consoleColors.GetValue(_random.Next(consoleColors.Length));
    }

    private static void Main(string[] args)
    {
        try
        {
            // Class imports
            var displayObj = new Display();
            var fileManagerObj = new FileManager();
            var characterObj = new Character();
            var activityObj = new Activity();
            var keywordObj = new Keywords();
            var containerObj = new Container();
            var transferObj = new Transfer();

            // Initialising the program
            var appTitle = "hazel";
            var appVersion = "22.07";
            var appAuthor = "garytate";
            var appDirectory = Environment.CurrentDirectory;
            var active = true;

            // Generates menu from array
            string[] options =
            {
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

            var logFiles = fileManagerObj.GetAllLogs(appDirectory);
            var characters = characterObj.GetAllCharacters(appDirectory);

            while (active)
            {
                displayObj.DisplayMenu(options, logFiles, characters);

                Console.Write("> ");
                var keyInput = Console.ReadKey().Key.ToString();
                var input = keyInput[keyInput.Length - 1];
                Console.Clear();

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("{0}: Version {1} maintained by {2}.\n", appTitle, appVersion, appAuthor);
                Console.ResetColor();

                switch (input)
                {
                    case '1':
                        // Reload Characters
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
                        var keywords = keywordObj.GetKeywords();
                        keywordObj.DisplayKeywords(appDirectory, characters, logFiles, keywords);
                        break;
                    case '5':
                        // Get Log Files
                        foreach (var logFile in logFiles) Console.WriteLine(logFile);
                        break;
                    case '6':
                        // Get Characters
                        foreach (var character in characters) Console.WriteLine(character);
                        break;
                    case '7':
                        // containers
                        containerObj.ReturnAllContainers(logFiles);
                        break;
                    case '8':
                        var transfers = transferObj.GetTokenTransfers(logFiles);
                        var potential = transferObj.GetPotentialTransfers(transfers);

                        var colorMatcher = 0;

                        foreach (var log in potential)
                        {
                            if (colorMatcher % 2 == 0) Console.ForegroundColor = ConsoleColor.Yellow;
                            else Console.ForegroundColor = ConsoleColor.Yellow;

                            Console.WriteLine($" {log.container} :: {log.character} - {log.steam} - {log.steamID}");
                            Console.ResetColor();
                            Console.WriteLine(log.log);

                            if (colorMatcher % 2 != 0) Console.Write("\n");
                            colorMatcher++;
                        }

                        if (potential.Count == 0)
                            Console.WriteLine("No transfers found.\n");

                        Console.ReadKey();
                        break;
                    case '9':
                        // Exit program
                        active = false;

                        Environment.Exit(1);
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Incorrect option.");
                        Console.ResetColor();
                        break;
                }

                Console.WriteLine();
            }
        } catch (Exception e)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Error: {0}", e.Message);
            Console.ResetColor();
        }
        
    }
}
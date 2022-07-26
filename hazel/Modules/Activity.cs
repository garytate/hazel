using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Hazel.Modules;

public class Activity
{
    public void DisplayActivity(string directory, List<string> characters, List<string> logs)
    {
        bool isOutputDecided = false;
        bool isOutput = false;
        Int32 charResults, charDaysActive;
        bool isCharActive;
        List<string> results = new List<string>();
        string outputFile = string.Empty;

        while (!isOutputDecided)
        {
            Console.Write("Output to text file? [Y/N]: ");
            string keyInput = Console.ReadKey().Key.ToString();
            Console.WriteLine();
            if (keyInput == "Y")
            {
                isOutput = true;
                isOutputDecided = true;
            }
            else if (keyInput == "N")
            {
                isOutput = false;
                isOutputDecided = true;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nIncorrect value.");
                Console.ResetColor();
            }
        }

        if (isOutput)
        {
            string outputDir = Path.Combine(directory, "output");

            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            Console.Write("\nOutput file name: ");
            string outputFileName = Console.ReadLine();

            if (outputFileName == string.Empty)
            {
                outputFileName = "output";
            }

            outputFile = outputDir + "\\" + outputFileName + ".txt";
            FileStream fs = File.Create(outputFile);
            fs.Close();
        }

        foreach (string character in characters)
        {
            charResults = 0;
            charDaysActive = 0;
            isCharActive = false;
            foreach (string logFile in logs)
            {
                string line;
                System.IO.StreamReader log = new System.IO.StreamReader(logFile);

                while ((line = log.ReadLine()) != null)
                {
                    if (line.Contains(character))
                    {
                        charResults += 1;
                        isCharActive = true;
                    }
                }

                if (isCharActive)
                {
                    charDaysActive += 1;
                    isCharActive = false;
                }
            }

            results.Add(String.Format("{0}: {1} | {2}", character, charResults, charDaysActive));
        }

        if (isOutput)
        {
            System.IO.File.WriteAllLines(outputFile, results);
        }

        foreach (string result in results)
        {
            Console.WriteLine(result);
        }

    }
}
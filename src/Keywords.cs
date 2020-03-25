using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO;

namespace Hazel
{
    class Keywords
    {
        public List<string> GetKeywords()
        {
            Console.WriteLine("Insert keywords seperated by commas.  Example: red, blue, blonde, fist");
            string keywords = Console.ReadLine();
            List<string> keywordList = keywords.Split(", ").ToList<string>();
            return keywordList;
        }

        public void DisplayKeywords(string directory, List<string> characters, List<string> logs, List<string> keywords)
        {
            bool isOutputDecided = false;
            bool isOutput = false;
            bool isOnlyCharacters = false;
            bool isOnlyCharactersDecided = false;
            string outputFile = "";
            List<string> results = new List<string>();

            while (!isOnlyCharactersDecided)
            {
                Console.Write("Search only characters from characters.txt [Y/N]: ");
                string keyInput = Console.ReadKey().Key.ToString();
                Console.WriteLine();
                if (keyInput == "Y")
                {
                    isOnlyCharacters = true;
                    isOnlyCharactersDecided = true;
                }
                else if (keyInput == "N")
                {
                    isOnlyCharacters = false;
                    isOnlyCharactersDecided = true;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nIncorrect value.");
                    Console.ResetColor();
                }
            }
            
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
                string outputDir = directory + "\\output";
                if (!Directory.Exists(outputDir))
                {
                    Directory.CreateDirectory(outputDir);
                }

                Console.Write("\nOutput file name: ");
                string outputFileName = Console.ReadLine();
                outputFile = outputDir + "\\" + outputFileName + ".txt";
                if (outputFile == "")
                {
                    outputFile = "output";
                }
                FileStream fs = File.Create(outputFile);
                fs.Close();
            }

            if (isOnlyCharacters)
            {
                foreach (string character in characters)
                {
                    foreach (string logFile in logs)
                    {
                        string line;
                        System.IO.StreamReader log = new System.IO.StreamReader(logFile);

                        while ((line = log.ReadLine()) != null)
                        {
                            string lowerLine = line.ToLower();
                            string lowerCharacter = character.ToLower();
                            if (line.Contains(character))
                            {
                                foreach (string keyword in keywords)
                                {
                                    if (line.Contains(keyword.ToLower()))
                                    {
                                        List<string> printKeyword = line.Split(keyword.ToLower()).ToList();
                                        for (int i = 0; i < printKeyword.Count; i++)
                                        {
                                            Console.Write(printKeyword[i]);
                                            if (i != printKeyword.Count - 1)
                                            {
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.Write(keyword);
                                                Console.ResetColor();
                                            }
                                        }
                                        Console.WriteLine();
                                        results.Add(String.Format("{0}: {1}", Path.GetFileName(logFile), line));
                                    }
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                foreach (string logFile in logs)
                {
                    string line;
                    System.IO.StreamReader log = new System.IO.StreamReader(logFile);

                    while ((line = log.ReadLine()) != null)
                    {
                        string lowerLine = line.ToLower();
                        foreach (string keyword in keywords)
                        {
                            if (line.Contains(keyword.ToLower()))
                            {
                                List<string> printKeyword = line.Split(keyword.ToLower()).ToList();
                                for (int i = 0; i < printKeyword.Count; i++)
                                {
                                    Console.Write(printKeyword[i]);
                                    if (i != printKeyword.Count - 1)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.Write(keyword);
                                        Console.ResetColor();
                                    }
                                }
                                Console.WriteLine();
                                results.Add(String.Format("{0}: {1}", Path.GetFileName(logFile), line));
                            }
                        }
                    }
                }
            }
            if (isOutput)
            {
                System.IO.File.WriteAllLines(outputFile, results);
            }
        }
    }
}

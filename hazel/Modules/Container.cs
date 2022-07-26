using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Hazel.Modules;

public class Container
{

    public void ReturnAllContainers(List<string> logs)
    {

        List<string> uniqueContainers = new List<string>();
        Int32 containerIDPattern;

        // Search from newest -> oldest logs, for up to date container names.
        logs.Reverse();

        foreach (string logFile in logs)
        {
            string currentLine;
            System.IO.StreamReader log = new System.IO.StreamReader(logFile);

            while ((currentLine = log.ReadLine()) != null)
            {
                if (currentLine.Contains("opened the '") && !(currentLine.Contains("vault.")))
                {
                    // Check to see if container is unique
                    containerIDPattern = currentLine.IndexOf("#");
                    string[] sectionedLog = currentLine.Split("' #");
                    string ContainerID = sectionedLog[1].Substring(0, 5);

                    if (uniqueContainers.Contains(ContainerID))
                    {
                        // check if name has been updated
                    }
                    else
                    {
                        string[] ContainerName = sectionedLog[0].Split("opened the '");
                        if (ContainerName[1].Length == 0 || ContainerName[1] == " ")
                        {
                            ContainerName[1] = "null";
                        }

                        Console.WriteLine("#{0} - {1}", ContainerID, ContainerName[1]);
                        uniqueContainers.Add(ContainerID);
                    }
                }
            }
        }
    }
}

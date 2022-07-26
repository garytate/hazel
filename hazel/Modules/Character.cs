﻿using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Hazel.Modules;

public class Character
{
    public List<string> GetAllCharacters(string directory)
    {
        List<string> characters = new List<string>();
        string currentLine = string.Empty;
        string charDirectory = Path.Combine(directory, "characters");
        string charTextFile = Path.Combine(charDirectory, "characters.txt");

        // We need to create the directory first if it doesn't exist.
        if (!Directory.Exists(charDirectory))
        {
            Directory.CreateDirectory(charDirectory);
        }

        // We'll do a separate check encase the .txt was deleted
        if (!File.Exists(charTextFile))
        {
            var characterFile = File.Create(charTextFile);
            characterFile.Close(); // Allows the user to edit the file
            Console.WriteLine("Enter characters (one per line) into /characters/characters.txt then press any key.");
            Console.ReadKey();
        }

        System.IO.StreamReader charFile = new System.IO.StreamReader(charTextFile);
        while ((currentLine = charFile.ReadLine()) != null)
        {
            characters.Add(currentLine);
        }

        return characters;
    }
}
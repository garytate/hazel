using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Hazel
{
    class Character
    {
        public List<string> getAllCharacters(string directory)
        {
            string currentLine;
            List<string> characters = new List<string>();
            if (!Directory.Exists(directory + "\\characters"))
            {
                Directory.CreateDirectory(directory + "\\characters");
                File.Create(directory + "\\characters\\characters.txt");
                Console.WriteLine("Please place characters into /characters/characters.txt then press any key.");
                Console.ReadKey();
            }

            System.IO.StreamReader charFile = new System.IO.StreamReader(directory + "\\characters\\characters.txt");
            while ((currentLine = charFile.ReadLine()) != null)
            {
                characters.Add(currentLine);
            }
            return characters;
        }
    }
}

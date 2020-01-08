using System;
using System.Collections.Generic;
using System.Text;

namespace Hazel
{
    class Character
    {
        public List<string> getAllCharacters(string directory)
        {
            string currentLine;
            List<string> characters = new List<string>();

            System.IO.StreamReader charFile = new System.IO.StreamReader(directory + "\\characters\\characters.txt");
            while ((currentLine = charFile.ReadLine()) != null)
            {
                characters.Add(currentLine);
            }
            return characters;
        }
    }
}

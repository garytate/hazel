using System;
using System.Collections.Generic;

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
                //Console.WriteLine("[{0}] {1}", i + 1, options[i]); // Output: [1] Load Characters
            }
            Console.ResetColor();

        }
    }
}

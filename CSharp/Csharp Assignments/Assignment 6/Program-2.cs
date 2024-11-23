using System;
using System.Collections.Generic;
namespace ProgRams
{
    class Program
    {
        static void Main()
        {
            List<string> words = new List<string>();

            Console.WriteLine("Enter words separated by spaces:");


            string input = Console.ReadLine();
            string[] parts = input.Split(' ');

            foreach (var part in parts)
            {
                words.Add(part);
            }

            Console.WriteLine("Words starting with 'a' and ending with 'm':");

            foreach (string word in words)
            {
                if (word.StartsWith("a") && word.EndsWith("m"))
                {
                    Console.WriteLine(word);
                }
                
            }
            Console.ReadLine();
        }
    }
}
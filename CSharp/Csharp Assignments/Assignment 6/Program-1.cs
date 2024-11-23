using System;
using System.Collections.Generic;
namespace ProgRams
{
    class Program
    {
        static void Main()
        {
            List<int> numbers = new List<int>();

            Console.WriteLine("Enter numbers separated by spaces:");


            string input = Console.ReadLine();
            string[] parts = input.Split(' ');

            foreach (var part in parts)
            {
                if (int.TryParse(part, out int number))
                {
                    numbers.Add(number);
                }
            }

            foreach (int number in numbers)
            {
                int square = number * number;
                if (square > 20)
                {
                    Console.WriteLine($"{number} - {square}");

                }
            }
            Console.ReadLine();
        }
    }
}
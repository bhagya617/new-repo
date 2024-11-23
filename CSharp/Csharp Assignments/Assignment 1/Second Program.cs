
using System;
namespace Programs
{
    class Program2
    {
        static void Main()
        {
            Console.Write("Enter a number: ");
            string input = Console.ReadLine();


            if (double.TryParse(input, out double number))
            {
                if (number > 0)
                {
                    Console.WriteLine("The number is positive.");
                    Console.Read();
                }
                else if (number < 0)
                {
                    Console.WriteLine("The number is negative.");
                    Console.Read();
                }
                else
                {
                    Console.WriteLine("The number is zero.");
                    Console.Read();
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
                Console.Read();
            }
        }
    }
}

using System;
namespace Programs
{
    class Program4
    {
        static void Main()
        {
            Console.Write("Enter a number to print its multiplication table: ");
            int number = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine($"Multiplication Table for {number}:");
            for (int i = 1; i <= 10; i++)
            {
                int result = number * i;
                Console.WriteLine($"{number} x {i} = {result}");
                
            }
            Console.Read();
        }
    }
}
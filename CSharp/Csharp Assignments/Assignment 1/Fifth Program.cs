
using System;
namespace Programs
{
    class Program5
    {
        static void Main()
        {
            Console.Write("Enter the first integer: ");
            int firstNumber = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter the second integer: ");
            int secondNumber = Convert.ToInt32(Console.ReadLine());

            int result;
            if (firstNumber == secondNumber)
            {
                result = (firstNumber + secondNumber) * 3; // Triple the sum
            }
            else
            {
                result = firstNumber + secondNumber; // Regular sum
            }

            Console.WriteLine($"The result is: {result}");
            Console.Read();
        }
    }
}
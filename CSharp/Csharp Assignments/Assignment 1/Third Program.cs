using System;

namespace Programs
{
    class Program3
    {
        static void Main()
        {
            Console.Write("Enter the first number: ");
            double firstNumber = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter the second number: ");
            double secondNumber = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Select an operation: +, -, *, /");
            char operation = Console.ReadKey().KeyChar;
            Console.WriteLine();

            switch (operation)
            {
                case '+':
                    Console.WriteLine($"Addition: {firstNumber} + {secondNumber} = {firstNumber + secondNumber}");
                    Console.Read();
                    break;

                case '-':
                    Console.WriteLine($"Subtraction: {firstNumber} - {secondNumber} = {firstNumber - secondNumber}");
                    Console.Read();
                    break;

                case '*':
                    Console.WriteLine($"Multiplication: {firstNumber} * {secondNumber} = {firstNumber * secondNumber}");
                    Console.Read();
                    break;

                case '/':
                    if (secondNumber != 0)
                    {
                        
                       Console.WriteLine($"Division: {firstNumber} / {secondNumber} = {firstNumber / secondNumber}");
                        Console.Read();
                    }
                    else
                    {
                        Console.WriteLine("Division: Cannot divide by zero.");
                        Console.Read();
                    }
                    break;

                default:
                    Console.WriteLine("Invalid operation. Please select +, -, *, or /.");
                    Console.Read();
                    break;
            }
        }
    }
}



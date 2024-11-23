using System;

class Program
{
    delegate int Calculator(int a, int b);

    static void Main()
    {
        Calculator add = (a, b) => a + b;
        Calculator subtract = (a, b) => a - b;
        Calculator multiply = (a, b) => a * b;

        Console.WriteLine("Enter two numbers:");
        int num1 = int.Parse(Console.ReadLine());
        int num2 = int.Parse(Console.ReadLine());

        Console.WriteLine("Addition: " + add(num1, num2));
        Console.WriteLine("Subtraction: " + subtract(num1, num2));
        Console.WriteLine("Multiplication: " + multiply(num1, num2));
        Console.ReadLine();
    }
}
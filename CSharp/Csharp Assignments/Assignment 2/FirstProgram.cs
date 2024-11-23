using System;
namespace SecondAssignment
{
    class SwapNumbers
    {
        static void Main()
        {

            int num1, num2, temp;


            Console.WriteLine("Enter the first number:");
            num1 = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter the second number:");
            num2 = Convert.ToInt32(Console.ReadLine());


            Console.WriteLine($"\nBefore swapping: \nFirst number: {num1} \nSecond number: {num2}");


            temp = num1;
            num1 = num2;
            num2 = temp;


            Console.WriteLine($"\nAfter swapping: \nFirst number: {num1} \nSecond number: {num2}");
            Console.Read();
        }
    }
}


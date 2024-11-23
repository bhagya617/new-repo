using System;
namespace Programs
{
    class Program1
    {
        static void Main()
        {

            Console.Write("Enter the first integer: ");
            int firstNumber = Convert.ToInt32(Console.ReadLine());


            Console.Write("Enter the second integer: ");
            int secondNumber = Convert.ToInt32(Console.ReadLine());


            if (firstNumber == secondNumber)
            {
                Console.WriteLine("The two integers are equal.");
                Console.Read();
            }
            else
            {
                Console.WriteLine("The two integers are not equal.");
                Console.Read();
            }
        }
    }
}


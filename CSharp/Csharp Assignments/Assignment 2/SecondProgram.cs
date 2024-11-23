
using System;

namespace SecondAssignment
{

    class Program
    {
        static void Main()
        {

            Console.Write("Enter a number: ");
            string input = Console.ReadLine();


            for (int j = 0; j < 2; j++)
            {
                DisplayNumber(input);
                Console.Read();
            }
        }

        static void DisplayNumber(string number)
        {

            for (int i = 0; i < 4; i++)
            {
                Console.Write(number);
                if (i < 3)
                {
                    Console.Write(" ");
                }
            }
            Console.WriteLine();


            for (int i = 0; i < 4; i++)
            {
                Console.Write(number);
            }
            Console.WriteLine();
        }
       

    }
}


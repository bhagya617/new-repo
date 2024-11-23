using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P1
{
    class Program
    {
        static string remov(string input, int pos)
        {
            if (pos < 0 || pos > =input.Length)
            {
                throw new ArgumentOutOfRangeException("out of range");
            }
            return input.Remove(pos, 1);
            
        }
        static void Main()

        {
            Console.WriteLine("Enter a string");
            string input = Console.ReadLine();
            Console.WriteLine("Enter the position");
            int pos = int.Parse(Console.ReadLine());


            string result=remov(input, pos);
            Console.WriteLine("Modified string = "+result);
            Console.ReadLine();
        }
    }
}

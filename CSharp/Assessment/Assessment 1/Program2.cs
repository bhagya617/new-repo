using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P1
{
    class Program
    {
        static string swapstrs(string input)
        {
            if (input.Length <= 1)
            {
                return input;
            }
            char firstchar = input[0];
            char lastchar = input[input.Length - 1];
            return lastchar + input.Substring(1, input.Length - 2) + firstchar;
        }
        static void Main()
        {
            Console.WriteLine("enter the input");
            string input = Console.ReadLine();
            string result = swapstrs(input);
            Console.WriteLine("Exchanged string:" +result );
            Console.ReadLine();

        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp38
{
    class Program
    {
        public static void Checkpositivenumber(int n)
        {
            if(n<0)
            {
                throw new ArgumentException("The number can't be negative");
            }
        }
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Enter a number");
                int n = int.Parse(Console.ReadLine());
                Checkpositivenumber(n);
                Console.WriteLine("The number is positive");
                Console.ReadLine();
            }
            catch(ArgumentException ex)
            {
                Console.WriteLine($"Error:{ex.Message}");
                Console.ReadLine();
            }
        }
    }
}

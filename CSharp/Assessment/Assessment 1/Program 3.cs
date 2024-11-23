using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P1
{
    class Program
    {
        static int findlargest(int n1, int n2, int n3)
        {
            return Math.Max(n1, Math.Max(n2, n3));
        }
        static void Main(string[] args)
        {
            Console.WriteLine("EnTER the first integer");
            int n1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the 2nd integer");
            int n2 = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the 3rd integer");
            int n3 = int.Parse(Console.ReadLine());
            int largest = findlargest(n1, n2, n3);
            Console.WriteLine("The largest number is=" + largest);
            Console.ReadLine();

        }
    }
}

using System;
using System.IO;
namespace ProgRams
{
    class Program
    {
        static void Main()
        {
            Console.Write("Enter the number of strings you want to write to the file: ");
            int count = int.Parse(Console.ReadLine());

            string[] lines = new string[count];

            for (int i = 0; i < count; i++)
            {
                Console.Write($"Enter string {i + 1}: ");
                lines[i] = Console.ReadLine();
            }

            Console.Write("Enter file name to save the data ");
            string fileName = Console.ReadLine();

            using (StreamWriter writer = new StreamWriter(fileName))
            {
                foreach (string line in lines)
                {
                    writer.WriteLine(line);
                }
            }

            Console.WriteLine("Data has been written to the file successfully.");
        }
    }
}
using System;


namespace P1
{
    class Program
    {
        static int CountOCC(string input, char letter)
        {
            int count = 0;
            foreach (char c in input)
            {
                if (c == char.ToLower(letter))
                {
                    count++;
                }
                
            }
            return count;
        }

       
    public static void Main()
    {
        Console.WriteLine("Enter a string");
        string input = Console.ReadLine();
        Console.WriteLine("Enetr the letter to count");
        char letter = Console.ReadKey().KeyChar;
        Console.WriteLine();
        int occ = CountOCC($"The letter { letter} apears{ count} times");

    }
    }
}

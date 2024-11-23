using System;

class Program
{
    static void Main()
    {
        
        Console.Write("Enter the first word: ");
        string word1 = Console.ReadLine();

        Console.Write("Enter the second word: ");
        string word2 = Console.ReadLine();

        
        if (word1.Equals(word2, StringComparison.OrdinalIgnoreCase))
        {
            Console.WriteLine("The words are the same.");
        }
        else
        {
            Console.WriteLine("The words are different.");
        }
    }
}



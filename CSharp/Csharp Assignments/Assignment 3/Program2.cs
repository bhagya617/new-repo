using System;
using System.Linq;

class Program
{
    static void Main()
    {
        
        Console.Write("Enter a word: ");
        string word = Console.ReadLine();

       
        string reversedWord = new string(word.Reverse().ToArray());

        Console.WriteLine("The reversed word is: " + reversedWord);
    }
}

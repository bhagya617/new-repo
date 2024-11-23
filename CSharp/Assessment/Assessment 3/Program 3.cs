using System;
using System.IO;

class FileAppender
{
    static void Main()
    {
        Console.WriteLine("Enter the file name ( e.g., example.txt):");
        string fileName = Console.ReadLine();

        string filePath = Path.Combine(Directory.GetCurrentDirectory(), fileName);

        if (!File.Exists(filePath))
        {
            Console.WriteLine("File does not exist. Creating a new file...");
            using (FileStream fs = File.Create(filePath))
            {
                Console.WriteLine($"New file created at: {filePath}");
                Console.ReadLine();
            }
        }

        Console.WriteLine("Enter the text you want to append to the file:");
        string textToAppend = Console.ReadLine();

        using (StreamWriter writer = File.AppendText(filePath))
        {
            writer.WriteLine(textToAppend);
        }

        Console.WriteLine("Text appended successfully. The file now contains:");

        using (StreamReader reader = new StreamReader(filePath))
        {
            string fileContent = reader.ReadToEnd();
            Console.WriteLine(fileContent);
            Console.ReadLine();
        }
    }
}
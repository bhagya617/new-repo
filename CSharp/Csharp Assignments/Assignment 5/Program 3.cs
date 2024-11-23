using System;
using System.IO;
namespace ProgRams
{
    class Program3
    {
        static void Main()
        {
            Console.WriteLine("Enter the file path");
            string fileName = Console.ReadLine();

            try
            {
                
                if (!File.Exists(fileName))
                {
                    Console.WriteLine("File not found.");
                    Console.ReadLine();
                    return;
                }

                
                int lineCount = 0;
                using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read))
                {
                    int byteValue;
                    bool isNewLine = true;

                    while ((byteValue = fs.ReadByte()) != -1)
                    {
                        if (byteValue == '\n')
                        {
                            lineCount++;
                            isNewLine = true;
                        }
                        else if (isNewLine)
                        {
                            isNewLine = false;
                        }
                    }

                    
                    if (!isNewLine)
                    {
                        lineCount++;
                    }
                }

                Console.WriteLine($"The number of lines in the file is: {lineCount}");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                Console.ReadLine();
            }
        }
    }
}





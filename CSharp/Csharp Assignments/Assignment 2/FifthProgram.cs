using System;

namespace SecondAssignment
{

    class MarksCalculator
    {
        static void Main()
        {
            int[] marks = new int[10];
            Console.WriteLine("Enter 10 marks:");


            for (int i = 0; i < marks.Length; i++)
            {
                marks[i] = Convert.ToInt32(Console.ReadLine());
            }


            int total = 0, min = marks[0], max = marks[0];
            for (int i = 0; i < marks.Length; i++)
            {
                total += marks[i];
                if (marks[i] < min) min = marks[i];
                if (marks[i] > max) max = marks[i];
            }

            double average = total / (double)marks.Length;


            for (int i = 0; i < marks.Length - 1; i++)
            {
                for (int j = i + 1; j < marks.Length; j++)
                {
                    if (marks[i] > marks[j])
                    {
                        // Swap marks[i] and marks[j]
                        int temp = marks[i];
                        marks[i] = marks[j];
                        marks[j] = temp;
                    }
                }
            }


            Console.WriteLine($"Total: {total}");
            Console.WriteLine($"Average: {average}");
            Console.WriteLine($"Minimum marks: {min}");
            Console.WriteLine($"Maximum marks: {max}");


            Console.WriteLine("Marks in ascending order: " + string.Join(", ", marks));


            Console.Write("Marks in descending order: ");
            for (int i = marks.Length - 1; i >= 0; i--)
            {
                Console.Write(marks[i]);
                if (i > 0) Console.Write(", ");
            }
            Console.WriteLine();
            Console.Read();
        }
    }
}


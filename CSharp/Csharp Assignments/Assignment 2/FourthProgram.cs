using System;

namespace SecondAssignment
{

    class ArrayStats
    {
        static void Main()
        {
            int[] numbers = { 5, 10, 15, 20, 25 };


            double average = 0;
            int min = numbers[0];
            int max = numbers[0];

            for (int i = 0; i < numbers.Length; i++)
            {
                average += numbers[i];
                if (numbers[i] < min) min = numbers[i];
                if (numbers[i] > max) max = numbers[i];
            }

            average /= numbers.Length; // Calculate average


            Console.WriteLine($"Average: {average}");
            Console.WriteLine($"Minimum: {min}");
            Console.WriteLine($"Maximum: {max}");
            Console.Read();
        }
       
    }

}

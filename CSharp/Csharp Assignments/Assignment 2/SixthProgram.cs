using System;

namespace SecondAssignment
{

    class ArrayCopy
    {
        static void Main()
        {
            int[] sourceArray = { 1, 2, 3, 4, 5 };
            int[] destinationArray = new int[sourceArray.Length];


            for (int i = 0; i < sourceArray.Length; i++)
            {
                destinationArray[i] = sourceArray[i];
            }


            Console.WriteLine("Copied array elements:");
            for (int i = 0; i < destinationArray.Length; i++)
            {
                Console.WriteLine(destinationArray[i]);
            }
            Console.Read();
        }
    }

}
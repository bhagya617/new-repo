using System;

namespace SecondAssignment
{

    class DayOfWeek
    {
        static void Main()
        {

            string[] days = { "Invalid", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
              Console.Write("Enter a day number (1-7): ");

            if (int.TryParse(Console.ReadLine(), out int dayNumber))
            {

                if (dayNumber >= 1 && dayNumber <= 7)
                {
                    Console.WriteLine(days[dayNumber]);
                    
                    
                }
                else
                {
                    Console.WriteLine("Invalid day number. Please enter a number between 1 and 7.");
                }
                
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid integer.");
            }
            Console.Read();
        }
    }

}

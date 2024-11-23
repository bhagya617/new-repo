using System;
namespace ProgRams
{
    class Program
    {
        const int TotalFare = 500;

        delegate int FareCalculationDelegate(int age, int totalFare);

        static void Main()
        {
            Console.Write("Enter Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Age: ");
            int age = GetValidAge();


            FareCalculationDelegate calculateFare;


            if (age <= 5)
            {
                calculateFare = CalculateFreeFare;
            }
            else if (age >= 60)
            {
                calculateFare = CalculateSeniorCitizenFare;
            }
            else
            {
                calculateFare = CalculateFullFare;
            }


            int finalFare = calculateFare(age, TotalFare);


            Console.WriteLine($"{name}, your final fare is: {finalFare}");


            Console.WriteLine("\nPress Enter to exit...");
            Console.ReadLine();
        }


        static int GetValidAge()
        {
            int age;
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out age) && age >= 0)
                {
                    return age;
                }
                else
                {
                    Console.WriteLine("Please enter a valid non-negative age.");
                }
            }
        }


        static int CalculateFreeFare(int age, int totalFare)
        {
            Console.WriteLine("Little Champs - Free Ticket");
            return 0;
        }


        static int CalculateSeniorCitizenFare(int age, int totalFare)
        {
            int discountedFare = totalFare - (totalFare * 30 / 100); // 30% discount
            Console.WriteLine($"Senior Citizen - Discounted Fare: {discountedFare}");
            return discountedFare;
        }


        static int CalculateFullFare(int age, int totalFare)
        {
            Console.WriteLine("Ticket Booked - Full Fare");
            return totalFare;
        }
    }
}
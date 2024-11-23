using System;
namespace Programs{


public class Scholarship
{
    public double Merit(int marks, double fees)
    {
        double scholarshipAmount = 0;

        
        if (marks >= 70 && marks <= 80)
        {
            scholarshipAmount = fees * 0.20;  
            
        }
        else if (marks > 80 && marks <= 90)
        {
            scholarshipAmount = fees * 0.30;  
            
        }
        else if (marks > 90)
        {
            scholarshipAmount = fees * 0.50;  
        }

        
        return scholarshipAmount;
    }
}

class Program
{
    static void Main()
    {
        Scholarship scholarship = new Scholarship();

       
        Console.Write("Enter marks: ");
        int marks = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter fees: ");
        double fees = Convert.ToDouble(Console.ReadLine());

        
        double scholarshipAmount = scholarship.Merit(marks, fees);

        
        Console.WriteLine($"The scholarship amount is: {scholarshipAmount}");

        
        
        Console.WriteLine("Press Enter to exit...");
        Console.ReadLine();
    }
}
}
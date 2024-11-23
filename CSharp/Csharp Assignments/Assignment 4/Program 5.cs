using System;

public interface IStudent
{
    
    int StudentId { get; set; }
    string Name { get; set; }

    
    void ShowDetails();
}


public class Dayscholar : IStudent
{
   
    public int StudentId { get; set; }
    public string Name { get; set; }

    
    public Dayscholar(int studentId, string name)
    {
        StudentId = studentId;
        Name = name;
    }

   
    public void ShowDetails()
    {
        Console.WriteLine($"Dayscholar Student ID: {StudentId}");
        Console.WriteLine($"Dayscholar Student Name: {Name}");
    }
}


public class Resident : IStudent
{
    
    public int StudentId { get; set; }
    public string Name { get; set; }

   
    public Resident(int studentId, string name)
    {
        StudentId = studentId;
        Name = name;
    }

    
    public void ShowDetails()
    {
        Console.WriteLine($"Resident Student ID: {StudentId}");
        Console.WriteLine($"Resident Student Name: {Name}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        
        Console.WriteLine("Enter details for Dayscholar Student:");

        Console.Write("Enter Student ID: ");
        int dayscholarId = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter Student Name: ");
        string dayscholarName = Console.ReadLine();

       
        IStudent dayscholar = new Dayscholar(dayscholarId, dayscholarName);

       
        Console.WriteLine("\nEnter details for Resident Student:");

        Console.Write("Enter Student ID: ");
        int residentId = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter Student Name: ");
        string residentName = Console.ReadLine();

        IStudent resident = new Resident(residentId, residentName);

        
        Console.WriteLine("\n--- Dayscholar Details ---");
        dayscholar.ShowDetails();

        Console.WriteLine("\n--- Resident Details ---");
        resident.ShowDetails();

        
        Console.WriteLine("\nPress Enter to exit...");
        Console.ReadLine();
    }
}

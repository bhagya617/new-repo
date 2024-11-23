using System;


class Employee
{
    public int Empid { get; set; }
    public string Empname { get; set; }
    public float Salary { get; set; }

    
    public Employee(int empid, string empname, float salary)
    {
        Empid = empid;
        Empname = empname;
        Salary = salary;
    }

    public void DisplayEmployeeDetails()
    {
        Console.WriteLine("Employee ID: " + Empid);
        Console.WriteLine("Employee Name: " + Empname);
        Console.WriteLine("Employee Salary: " + Salary);
    }
}

class ParttimeEmployee : Employee
{
    public float Wages { get; set; }

   
    public ParttimeEmployee(int empid, string empname, float salary, float wages)
        : base(empid, empname, salary)  // Calling the base class constructor
    {
        Wages = wages;
    }

    
    public void DisplayParttimeDetails()
    {
        
        DisplayEmployeeDetails();
        Console.WriteLine("Employee Wages: " + Wages);
    }
}

class Program
{
    static void Main(string[] args)
    {
        
        Console.WriteLine("Enter Employee ID:");
        int empid = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter Employee Name:");
        string empname = Console.ReadLine();

        Console.WriteLine("Enter Employee Salary:");
        float salary = float.Parse(Console.ReadLine());

        
        Console.WriteLine("Enter Wages for Part-time Employee:");
        float wages = float.Parse(Console.ReadLine());

       
        ParttimeEmployee parttimeEmp = new ParttimeEmployee(empid, empname, salary, wages);

        
        Console.WriteLine("\nPart-time Employee Details:");
        parttimeEmp.DisplayParttimeDetails();

        
        Console.WriteLine("\nPress Enter to exit...");
        Console.ReadLine();
    }
}

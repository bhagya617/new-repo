 
using System;
using System.Collections.Generic;
 
public class Employee
{
    public int EmployeeID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Title { get; set; }
    public DateTime DOB { get; set; }
    public DateTime DOJ { get; set; }
    public string City { get; set; }
}
 
class Program
{
    static void Main()
    {
        
        List<Employee> empList = new List<Employee>
        {
            new Employee { EmployeeID = 1001, FirstName = "Malcolm", LastName = "Daruwalla", Title = "Manager", DOB = new DateTime(1984, 11, 16), DOJ = new DateTime(2011, 6, 8), City = "Mumbai" },
            new Employee { EmployeeID = 1002, FirstName = "Asdin", LastName = "Dhalla", Title = "AsstManager", DOB = new DateTime(1987, 11, 14), DOJ = new DateTime(2015, 4, 12), City = "Pune" },
            new Employee { EmployeeID = 1003, FirstName = "Madhavi", LastName = "Oza", Title = "Consultant", DOB = new DateTime(1994, 8, 20), DOJ = new DateTime(2012, 7, 7), City = "Mumbai" },
            new Employee { EmployeeID = 1004, FirstName = "Saba", LastName = "Shaikh", Title = "SE", DOB = new DateTime(1990, 6, 3), DOJ = new DateTime(2016, 2, 2), City = "Pune" },
            new Employee { EmployeeID = 1005, FirstName = "Nazia", LastName = "Shaikh", Title = "SE", DOB = new DateTime(1991, 3, 8), DOJ = new DateTime(2016, 2, 2), City = "Mumbai" },
            new Employee { EmployeeID = 1006, FirstName = "Amit", LastName = "Pathak", Title = "Consultant", DOB = new DateTime(1989, 11, 7), DOJ = new DateTime(2014, 8, 8), City = "Chennai" },
            new Employee { EmployeeID = 1007, FirstName = "Vijay", LastName = "Natrajan", Title = "Consultant", DOB = new DateTime(1989, 12, 2), DOJ = new DateTime(2015, 6, 1), City = "Mumbai" },
            new Employee { EmployeeID = 1008, FirstName = "Rahul", LastName = "Dubey", Title = "Associate", DOB = new DateTime(1993, 11, 11), DOJ = new DateTime(2014, 11, 6), City = "Chennai" },
            new Employee { EmployeeID = 1009, FirstName = "Suresh", LastName = "Mistry", Title = "Associate", DOB = new DateTime(1992, 8, 12), DOJ = new DateTime(2014, 12, 3), City = "Chennai" },
            new Employee { EmployeeID = 1010, FirstName = "Sumit", LastName = "Shah", Title = "Manager", DOB = new DateTime(1991, 4, 12), DOJ = new DateTime(2016, 1, 2), City = "Pune" }
        };
 
        
        DisplayAllEmployees(empList);
        DisplayEmployeesNotInMumbai(empList);
        DisplayAsstManagers(empList);
        DisplayEmployeesLastNameStartsWithS(empList);
    }
 

    static void DisplayAllEmployees(List<Employee> empList)
    {
        Console.WriteLine("All Employees:");
        foreach (var emp in empList)
        {
            PrintEmployee(emp);
        }
        Console.WriteLine();
    }
 
   
    static void DisplayEmployeesNotInMumbai(List<Employee> empList)
    {
        Console.WriteLine("Employees Not in Mumbai:");
        foreach (var emp in empList)
        {
            if (emp.City != "Mumbai")
            {
                PrintEmployee(emp);
            }
        }
        Console.WriteLine();
    }
 
   
    static void DisplayAsstManagers(List<Employee> empList)
    {
        Console.WriteLine("Employees with Title 'AsstManager':");
        foreach (var emp in empList)
        {
            if (emp.Title == "AsstManager")
            {
                PrintEmployee(emp);
            }
        }
        Console.WriteLine();
    }
 
  
    static void DisplayEmployeesLastNameStartsWithS(List<Employee> empList)
    {
        Console.WriteLine("Employees with Last Name starting with 'S':");
        foreach (var emp in empList)
        {
            if (emp.LastName.Length > 0 && emp.LastName[0] == 'S') 
            {
                PrintEmployee(emp);
            }
        }
        Console.WriteLine();
    }
 
   
    static void PrintEmployee(Employee emp)
    {
        Console.WriteLine($"EmployeeID: {emp.EmployeeID}, Name: {emp.FirstName} {emp.LastName}, Title: {emp.Title}, DOB: {emp.DOB:dd-MM-yyyy}, DOJ: {emp.DOJ:dd-MM-yyyy}, City: {emp.City}");
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Linq_Sql_VS
{
    public class Empl
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
        static void Main(string[] args)
        {
            //  (First Question)==>>1. Create a console application and add class named Employee with following field.

            using (var db = new Mydbm1DataContext())
            {
                var employees = db.Employees.ToList();
                Console.WriteLine("Employee Details from Database:");
                foreach (var employee in employees)
                {
                    Console.WriteLine($"ID: {employee.EmployeeID}, Name: {employee.FirstName} {employee.LastName}, Title: {employee.Title}, DOB: {employee.BirthDate}, DOJ: {employee.HireDate}, City: {employee.City}");
                }
            }

            // 2: Generic List (Second Question)
            Console.WriteLine("\nGeneric List Queries:");

            List<Employee> empList = new List<Employee>
            {
                new Employee { EmployeeID = 1001, FirstName = "Malcolm", LastName = "Daruwalla", Title = "Manager", BirthDate = new DateTime(1984, 6, 11), HireDate = new DateTime(2011, 8, 6), City = "Mumbai" },
                new Employee { EmployeeID = 1002, FirstName = "Asdin", LastName = "Dhalla", Title = "AsstManager", BirthDate = new DateTime(1984, 8, 8), HireDate = new DateTime(2012, 7, 7), City = "Mumbai" },
                new Employee { EmployeeID = 1003, FirstName = "Madhavi", LastName = "Oza", Title = "Consultant", BirthDate = new DateTime(1987, 11, 4), HireDate = new DateTime(2015, 12, 4), City = "Pune" },
                new Employee { EmployeeID = 1004, FirstName = "Saba", LastName = "Shaikh", Title = "SE", BirthDate = new DateTime(1990, 6, 3), HireDate = new DateTime(2016, 2, 2), City = "Pune" },
                new Employee { EmployeeID = 1005, FirstName = "Nazia", LastName = "Shaikh", Title = "SE", BirthDate = new DateTime(1991, 3, 3), HireDate = new DateTime(2016, 2, 2), City = "Mumbai" },
                new Employee { EmployeeID = 1006, FirstName = "Amit", LastName = "Pathak", Title = "Consultant", BirthDate = new DateTime(1989, 11, 17), HireDate = new DateTime(2014, 8, 8), City = "Chennai" },
                new Employee { EmployeeID = 1007, FirstName = "Vijay", LastName = "Natrajan", Title = "Consultant", BirthDate = new DateTime(1989, 12, 5), HireDate = new DateTime(2015, 6, 16), City = "Mumbai" },
                new Employee { EmployeeID = 1008, FirstName = "Rahul", LastName = "Dubey", Title = "SE", BirthDate = new DateTime(1993, 11, 4), HireDate = new DateTime(2014, 6, 11), City = "Chennai" },
                new Employee { EmployeeID = 1009, FirstName = "Suresh", LastName = "Mistry", Title = "Associate", BirthDate = new DateTime(1992, 8, 28), HireDate = new DateTime(2014, 3, 12), City = "Chennai" },
                new Employee { EmployeeID = 1010, FirstName = "Sumit", LastName = "Shah", Title = "Manager", BirthDate = new DateTime(1991, 12, 4), HireDate = new DateTime(2016, 2, 1), City = "Pune" }
            };

            // List employees who joined before 1/1/2015
            var earlyJoiners = empList.Where(e => e.HireDate < new DateTime(2015, 1, 1)).ToList();
            Console.WriteLine("\nEmployees who joined before 1/1/2015:");
            foreach (var emp in earlyJoiners)
            {
                Console.WriteLine($"{emp.FirstName} {emp.LastName} joined on {emp.HireDate}");
            }

            // List employees born after 1/1/1990
            var youngEmployees = empList.Where(e => e.BirthDate > new DateTime(1990, 1, 1)).ToList();
            Console.WriteLine("\nEmployees born after 1/1/1990:");
            foreach (var emp in youngEmployees)
            {
                Console.WriteLine($"{emp.FirstName} {emp.LastName} was born on {emp.BirthDate}");
            }

            // Employees whose designation is "Consultant" or "Associate"
            var consultantsOrAssociates = empList.Where(e => e.Title == "Consultant" || e.Title == "Associate").ToList();
            Console.WriteLine("\nEmployees with the designation of Consultant or Associate:");
            foreach (var emp in consultantsOrAssociates)
            {
                Console.WriteLine($"ID: {emp.EmployeeID}, Name: {emp.FirstName} {emp.LastName}, Title: {emp.Title}");
            }

            //  Display total number of employees
            Console.WriteLine($"\nTotal number of employees: {empList.Count}");

            // Employees from Chennai
            var chennaiEmployees = empList.Where(e => e.City == "Chennai").ToList();
            Console.WriteLine($"\nTotal number of employees from Chennai: {chennaiEmployees.Count}");

            // Display highest employee ID
            var highestEmployeeID = empList.Max(e => e.EmployeeID);

            Console.WriteLine($"\nHighest Employee ID: {highestEmployeeID}");

            //  Total number of employees who joined after 1/1/2015
            var after2015Employees = empList.Where(e => e.HireDate > new DateTime(2015, 1, 1)).ToList();
            Console.WriteLine($"\nTotal number of employees who joined after 1/1/2015: {after2015Employees.Count}");

            //Total number of employees grouped by city
            var cityGroup = empList.GroupBy(e => e.City).Select(group => new { City = group.Key, Count = group.Count() }).ToList();
            Console.WriteLine("\nTotal number of employees grouped by city:");
            foreach (var group in cityGroup)
            {
                Console.WriteLine($"City: {group.City}, Count: {group.Count}");
            }

            // Employees not designated as Associate
            var nonAssociates = empList.Where(e => e.Title != "Associate").ToList();
            Console.WriteLine("\nEmployees not designated as Associate:");
            foreach (var emp in nonAssociates)
            {
                Console.WriteLine($"ID: {emp.EmployeeID}, Name: {emp.FirstName} {emp.LastName}, Title: {emp.Title}");
            }

            // Total number of employees by city and title
            var cityTitleGroup = empList.GroupBy(e => new { e.City, e.Title }).Select(group => new { group.Key.City, group.Key.Title, Count = group.Count() }).ToList();
            Console.WriteLine("\nTotal number of employees grouped by city and title:");
            foreach (var group in cityTitleGroup)
            {
                Console.WriteLine($"City: {group.City}, Title: {group.Title}, Count: {group.Count}");
            }

            // Employee who is the youngest in the list
            var youngestEmployee = empList.OrderByDescending(e => e.BirthDate).First();
            Console.WriteLine($"\nThe youngest employee is: {youngestEmployee.FirstName} {youngestEmployee.LastName}, Born on: {youngestEmployee.BirthDate}");
        }
    }
}
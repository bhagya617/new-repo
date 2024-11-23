using System;
using System.Collections.Generic;
using System.Linq;
namespace ProgRams
{
    class Employee
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public string EmpCity { get; set; }
        public int EmpSalary { get; set; }

        public Employee(int empId, string empName, string empCity, int empSalary)
        {
            EmpId = empId;
            EmpName = empName;
            EmpCity = empCity;
            EmpSalary = empSalary;
        }
    }

    class Program
    {
        static void Main()
        {
            List<Employee> employees = new List<Employee>();


            Console.Write("Enter the number of employees: ");
            int numOfEmployees;
            while (!int.TryParse(Console.ReadLine(), out numOfEmployees) || numOfEmployees <= 0)
            {
                Console.WriteLine("Please enter a valid number greater than 0.");
            }


            for (int i = 0; i < numOfEmployees; i++)
            {
                Console.WriteLine($"\nEnter details for Employee {i + 1}:");


                Console.Write("Employee ID: ");
                int empId;
                while (!int.TryParse(Console.ReadLine(), out empId) || empId <= 0)
                {
                    Console.WriteLine("Please enter a valid Employee ID.");
                }


                Console.Write("Employee Name: ");
                string empName = Console.ReadLine();


                Console.Write("Employee City: ");
                string empCity = Console.ReadLine();


                Console.Write("Employee Salary: ");
                int empSalary;
                while (!int.TryParse(Console.ReadLine(), out empSalary) || empSalary <= 0)
                {
                    Console.WriteLine("Please enter a valid Salary.");
                }


                employees.Add(new Employee(empId, empName, empCity, empSalary));
            }


            DisplayAllEmployees(employees);
            DisplayHighSalaryEmployees(employees);
            DisplayEmployeesFromBangalore(employees);
            DisplayEmployeesSortedByName(employees);
        }

        static void DisplayAllEmployees(List<Employee> employees)
        {
            Console.WriteLine("\nAll Employees:");
            employees.ForEach(emp => Console.WriteLine($"{emp.EmpId}, {emp.EmpName}, {emp.EmpCity}, {emp.EmpSalary}"));
        }

        static void DisplayHighSalaryEmployees(List<Employee> employees)
        {

            var highSalaryEmployees = employees.Where(emp => emp.EmpSalary > 45000).ToList();

            Console.WriteLine("\nEmployees with Salary > 45000:");
            highSalaryEmployees.ForEach(emp => Console.WriteLine($"{emp.EmpId}, {emp.EmpName}, {emp.EmpCity}, {emp.EmpSalary}"));
        }

        static void DisplayEmployeesFromBangalore(List<Employee> employees)
        {

            var bangaloreEmployees = employees.Where(emp => emp.EmpCity == "Bangalore").ToList();

            Console.WriteLine("\nEmployees from Bangalore:");
            bangaloreEmployees.ForEach(emp => Console.WriteLine($"{emp.EmpId}, {emp.EmpName}, {emp.EmpCity}, {emp.EmpSalary}"));
        }

        static void DisplayEmployeesSortedByName(List<Employee> employees)
        {

            var sortedEmployees = employees.OrderBy(emp => emp.EmpName).ToList();

            Console.WriteLine("\nEmployees Sorted by Name:");
            sortedEmployees.ForEach(emp => Console.WriteLine($"{emp.EmpId}, {emp.EmpName}, {emp.EmpCity}, {emp.EmpSalary}"));
            Console.ReadLine();
        }
    }
}

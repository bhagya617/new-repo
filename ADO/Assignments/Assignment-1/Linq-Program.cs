using System;
using System.Data;
using System.Linq;

namespace LINQQueries
{
    class Program
    {
        static void Main()
        {
            
            DataTable employeeTable = new DataTable();
            employeeTable.Columns.Add("EmployeeID", typeof(int));
            employeeTable.Columns.Add("FirstName", typeof(string));
            employeeTable.Columns.Add("LastName", typeof(string));
            employeeTable.Columns.Add("Title", typeof(string));
            employeeTable.Columns.Add("DOB", typeof(DateTime));
            employeeTable.Columns.Add("DOJ", typeof(DateTime));
            employeeTable.Columns.Add("City", typeof(string));

            employeeTable.Rows.Add(1001, "Malcolm", "Daruwalla", "Manager", new DateTime(1984, 11, 16), new DateTime(2011, 8, 6), "Mumbai");
            employeeTable.Rows.Add(1002, "Asdin", "Dhalla", "Assistant Manager", new DateTime(1984, 8, 20), new DateTime(2012, 7, 7), "Mumbai");
            employeeTable.Rows.Add(1003, "Madhavi", "Oza", "Consultant", new DateTime(1987, 12, 14), new DateTime(2015, 12, 14), "Pune");
            employeeTable.Rows.Add(1004, "Saba", "Shaikh", "SE", new DateTime(1990, 3, 6), new DateTime(2016, 2, 2), "Pune");
            employeeTable.Rows.Add(1005, "Nazia", "Shaikh", "SE", new DateTime(1991, 8, 3), new DateTime(2016, 2, 2), "Mumbai");
            employeeTable.Rows.Add(1006, "Amit", "Pathak", "Consultant", new DateTime(1989, 7, 11), new DateTime(2014, 8, 8), "Chennai");
            employeeTable.Rows.Add(1007, "Vijay", "Natrajan", "Consultant", new DateTime(1989, 12, 2), new DateTime(2015, 1, 6), "Mumbai");
            employeeTable.Rows.Add(1008, "Rahul", "Dubey", "Associate", new DateTime(1993, 11, 11), new DateTime(2014, 6, 11), "Chennai");
            employeeTable.Rows.Add(1009, "Suresh", "Mistry", "Associate", new DateTime(1992, 12, 18), new DateTime(2014, 3, 12), "Chennai");
            employeeTable.Rows.Add(1010, "Sumit", "Shah", "Manager", new DateTime(1991, 12, 4), new DateTime(2016, 2, 1), "Pune");


            // Query 1: Employees who joined before 1/1/2015
            var query1 = employeeTable.AsEnumerable()
                .Where(row => row.Field<DateTime>("DOJ") < new DateTime(2015, 1, 1));
            Console.WriteLine("Employees who joined before 1/1/2015:");
            foreach (var row in query1)
                Console.WriteLine($"{row["FirstName"]} {row["LastName"]}");

            // Query 2: Employees born after 1/1/1990
            var query2 = employeeTable.AsEnumerable()
                .Where(row => row.Field<DateTime>("DOB") > new DateTime(1990, 1, 1));
            Console.WriteLine("\nEmployees born after 1/1/1990:");
            foreach (var row in query2)
                Console.WriteLine($"{row["FirstName"]} {row["LastName"]}");

            // Query 3: Employees with title 'Consultant' or 'Associate'
            var query3 = employeeTable.AsEnumerable()
                .Where(row => row.Field<string>("Title") == "Consultant" || row.Field<string>("Title") == "Associate");
            Console.WriteLine("\nEmployees with title 'Consultant' or 'Associate':");
            foreach (var row in query3)
                Console.WriteLine($"{row["FirstName"]} {row["LastName"]}");

            // Query 4: Total number of employees
            var query4 = employeeTable.AsEnumerable().Count();
            Console.WriteLine($"\nTotal number of employees: {query4}");

            // Query 5: Employees from 'Chennai'
            var query5 = employeeTable.AsEnumerable()
                .Where(row => row.Field<string>("City") == "Chennai").Count();
            Console.WriteLine($"\nTotal employees from Chennai: {query5}");

            // Query 6: Highest employee ID
            var query6 = employeeTable.AsEnumerable()
                .OrderByDescending(row => row.Field<int>("EmployeeID")).First();
            Console.WriteLine($"\nHighest Employee ID: {query6["EmployeeID"]} - {query6["FirstName"]} {query6["LastName"]}");

            // Query 7: Employees who joined after 1/1/2015
            var query7 = employeeTable.AsEnumerable()
                .Where(row => row.Field<DateTime>("DOJ") > new DateTime(2015, 1, 1));
            Console.WriteLine("\nEmployees who joined after 1/1/2015:");
            foreach (var row in query7)
                Console.WriteLine($"{row["FirstName"]} {row["LastName"]}");

            // Query 8: Employees whose designation is not 'Associate'
            var query8 = employeeTable.AsEnumerable()
                .Where(row => row.Field<string>("Title") != "Associate").Count();
            Console.WriteLine($"\nTotal employees whose title is not 'Associate': {query8}");

            // Query 9: Total number of employees based on City
            var query9 = employeeTable.AsEnumerable()
                .GroupBy(row => row.Field<string>("City"))
                .Select(group => new { City = group.Key, Count = group.Count() });
            Console.WriteLine("\nEmployee count by City:");
            foreach (var group in query9)
                Console.WriteLine($"{group.City}: {group.Count}");

            // Query 10: Total number of employees based on Title
            var query10 = employeeTable.AsEnumerable()
                .GroupBy(row => row.Field<string>("Title"))
                .Select(group => new { Title = group.Key, Count = group.Count() });
            Console.WriteLine("\nEmployee count by Title:");
            foreach (var group in query10)
                Console.WriteLine($"{group.Title}: {group.Count}");

            // Query 11: Youngest employee
            var query11 = employeeTable.AsEnumerable()
                .OrderBy(row => row.Field<DateTime>("DOB")).Last();
            Console.WriteLine($"\nYoungest Employee: {query11["FirstName"]} {query11["LastName"]} - DOB: {query11["DOB"]:d}");
        }
        
    }
}
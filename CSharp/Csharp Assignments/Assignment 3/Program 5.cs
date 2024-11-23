using System;


public class Person
{
    protected int rollNo;
    protected string name;

   
    public Person(int rollNo, string name)
    {
        this.rollNo = rollNo;
        this.name = name;
    }

    public void DisplayBasicInfo()
    {
        Console.WriteLine($"Roll No: {rollNo}");
        Console.WriteLine($"Name: {name}");
    }
}


public class Student : Person
{
    private string studentClass;
    private string semester;
    private string branch;
    private int[] marks = new int[5];

    public Student(int rollNo, string name, string studentClass, string semester, string branch)
        : base(rollNo, name)
    {
        this.studentClass = studentClass;
        this.semester = semester;
        this.branch = branch;
    }

    public void GetMarks()
    {
        Console.WriteLine("Enter marks for 5 subjects:");
        for (int i = 0; i < 5; i++)
        {
            Console.Write($"Subject {i + 1}: ");
            marks[i] = int.Parse(Console.ReadLine());
        }
    }

    
    public string CalculateResult()
    {
        int totalMarks = 0;
        bool failedInAnySubject = false;

        // Calculate total marks and check for failure
        for (int i = 0; i < 5; i++)
        {
            totalMarks += marks[i];
            if (marks[i] < 35)
            {
                failedInAnySubject = true;
            }
        }

        
        double averageMarks = totalMarks / 5.0;

   
        if (failedInAnySubject)
        {
            return "Failed (One or more subjects below 35)";
        }
        else if (averageMarks < 50)
        {
            return "Failed (Average marks below 50)";
        }
        else
        {
            return "Passed";
        }
    }

    public void DisplayData()
    {
        DisplayBasicInfo();  
        Console.WriteLine($"Class: {studentClass}");
        Console.WriteLine($"Semester: {semester}");
        Console.WriteLine($"Branch: {branch}");

     
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine($"Subject {i + 1}: {marks[i]}");
        }

        Console.WriteLine($"Result: {CalculateResult()}");
    }
}

class Program
{
    static void Main()
    {
        
        Student student = new Student(101, "Alice", "12th", "Semester 1", "Science");

        student.GetMarks();

        
        student.DisplayData();
    }
}

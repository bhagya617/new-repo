using System;

class Box
{
    public int Length { get; set; }
    public int Breadth { get; set; }
}

class Rectangle : Box
{
    public Rectangle Add(Rectangle r1, Rectangle r2)
    {
        return new Rectangle { Length = r1.Length + r2.Length, Breadth = r1.Breadth + r2.Breadth };
    }

    public void Display()
    {
        Console.WriteLine("Length: " + Length + ", Breadth: " + Breadth);
        Console.ReadLine();
    }
}

class Test
{
    static void Main()
    {
        Rectangle r1 = new Rectangle();
        Rectangle r2 = new Rectangle();

        Console.WriteLine("Enter length and breadth of Rectangle 1:");
        r1.Length = int.Parse(Console.ReadLine());
        r1.Breadth = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter length and breadth of Rectangle 2:");
        r2.Length = int.Parse(Console.ReadLine());
        r2.Breadth = int.Parse(Console.ReadLine());

        Rectangle r3 = new Rectangle();
        r3 = r3.Add(r1, r2);

        Console.WriteLine("Details of Rectangle 3:");
        r3.Display();
    }
}

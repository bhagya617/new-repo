using System;

class Book
{
    public string BookName { get; set; }
    public string AuthorName { get; set; }

    
    public Book(string bookName, string authorName)
    {
        BookName = bookName;
        AuthorName = authorName;
    }

    
    public void Display()
    {
        Console.WriteLine("Book Name: " + BookName);
        Console.WriteLine("Author Name: " + AuthorName);
    }
}

class BookShelf
{
    
    private Book[] books = new Book[5];

    
    public Book this[int index]
    {
        get
        {
            if (index >= 0 && index < 5)
                return books[index];
            else
                throw new IndexOutOfRangeException("Invalid index. Valid indices are from 0 to 4.");
        }
        set
        {
            if (index >= 0 && index < 5)
                books[index] = value;
            else
                throw new IndexOutOfRangeException("Invalid index. Valid indices are from 0 to 4.");
        }
    }

    
    public void DisplayAllBooks()
    {
        for (int i = 0; i < books.Length; i++)
        {
            if (books[i] != null)
            {
                Console.WriteLine($"Book {i + 1}:");
                books[i].Display();
                Console.WriteLine(); 
            }
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        
        BookShelf bookShelf = new BookShelf();

       
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine($"Enter details for Book {i + 1}:");

            Console.Write("Enter Book Name: ");
            string bookName = Console.ReadLine();

            Console.Write("Enter Author Name: ");
            string authorName = Console.ReadLine();

            
            bookShelf[i] = new Book(bookName, authorName);
            Console.WriteLine(); 
        }

        
        Console.WriteLine("\nBooks in the BookShelf:");
        bookShelf.DisplayAllBooks();

      
        Console.WriteLine("\nPress Enter to exit...");
        Console.ReadLine();
    }
}

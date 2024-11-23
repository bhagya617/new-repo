using System;
namespace ProgRams
{
    class Books
    {
        public string BookName { get; set; }
        public string AuthorName { get; set; }

        public Books(string bookName, string authorName)
        {
            BookName = bookName;
            AuthorName = authorName;
        }

        public void Display()
        {
            Console.WriteLine($"Book: {BookName}, Author: {AuthorName}");
            
        }
    }

    class BookShelf
    {
        private Books[] books = new Books[5];

        public Books this[int index]
        {
            get { return books[index]; }
            set { books[index] = value; }
        }

        public void DisplayBooks()
        {
            foreach (var book in books)
            {
                if (book != null)
                    book.Display();
            }
        }
    }

    class Program
    {
        static void Main()
        {
            BookShelf shelf = new BookShelf();

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Enter details for Book {i + 1}:");

                Console.Write("Enter Book Name: ");
                string bookName = Console.ReadLine();

                Console.Write("Enter Author Name: ");
                string authorName = Console.ReadLine();

                shelf[i] = new Books(bookName, authorName);
            }

            Console.WriteLine("\nBooks in Shelf:");
            shelf.DisplayBooks();
            Console.ReadLine();
        }
    }
}
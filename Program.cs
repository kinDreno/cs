using System;
using System.Collections.Generic;
using System.Linq;

class Books
{
    public string? BookName { get; set; }
    public int BookCount { get; set; }
    public bool IsBorrowed { get; set; }

    //constructor
    public Books(string bookName, int bookCount, bool isBorrowed)
    {
        BookName = bookName;
        BookCount = bookCount;
        IsBorrowed = isBorrowed;
    }

}

class Program
{
    static List<Books> books = new List<Books> { };
    static void AddBook()
    {
        Console.WriteLine("Enter the book you would like to add: ");
        string? addBook = Console.ReadLine();
        if (string.IsNullOrEmpty(addBook))
        {
            Console.WriteLine("You did not enter anything.");
            return;
        }
        Books addedBook = new Books(addBook, 1, false);
        books.Add(addedBook);
        Console.WriteLine($"Successfully added {addBook} in the list!");
        return;
    }
    static void ViewBooks()
    {
        if (books.Count == 0)
        {
            Console.WriteLine("No books here.");
        }
        foreach (var book in books)
        {
            Console.WriteLine($"- {book.BookName} ({(book.IsBorrowed ? "Not available" : "Available to borrow")})");
        }
    }

    static void BorrowBook()
    {
        if (books.Count == 0)
        {
            Console.WriteLine("No books here.");
        }
        for (int i = 0; i < books.Count; i++)
        {
            Console.WriteLine($"{i + 1}). {books[i].BookName} ({(books[i].IsBorrowed ? "Not available" : "Available to borrow")}) ");
        }
        while (true)
        {
            Console.WriteLine("Choose the book you would like to borrow");
            try
            {
                int borrowBook = Convert.ToInt32(Console.ReadLine()) - 1;
                if (0 > borrowBook || borrowBook >= books.Count)
                {
                    Console.WriteLine("Index out of bounds!");
                    continue;
                }
                else if (books[borrowBook].IsBorrowed)
                {
                    Console.WriteLine($"{books[borrowBook]} is not available to borrow");
                    continue;
                }
                books[borrowBook].IsBorrowed = true;
                Console.WriteLine($"You have successfully borrowed \"{books[borrowBook].BookName}\".");
                return;
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input! Please enter a number.");
            }
        }

    }

    static void ReturnBook()
    {
        var borrowedBooks = books.Where(n => n.IsBorrowed == true).ToList();

        if (!borrowedBooks.Any())
        {
            Console.WriteLine("No books are currently borrowed.");
            return;
        }

        Console.WriteLine("Select the book you want to return:");
        for (int i = 0; i < borrowedBooks.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {borrowedBooks[i].BookName}");
        }

        while (true)
        {
            try
            {
                int returnBookIndex = Convert.ToInt32(Console.ReadLine()) - 1;
                if (returnBookIndex < 0 || returnBookIndex >= borrowedBooks.Count)
                {
                    Console.WriteLine("Invalid selection. Try again.");
                    continue;
                }
                borrowedBooks[returnBookIndex].IsBorrowed = false;
                Console.WriteLine($"You have successfully returned \"{borrowedBooks[returnBookIndex].BookName}\".");
                return;
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input! Please enter a number.");
            }
        }
    }


    static void Main(string[] args)
    {
        Console.WriteLine(@"Welcome to Book Management System
            1. Add a book
            2. View all Books
            3. Borrow a Book
            4. Return a Book.
            5. View Borrowed Books.
            6. Exit the application.");
        while (true)
        {
            try
            {
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        AddBook();
                        break;
                    case 2:
                        ViewBooks();
                        break;
                    case 3:
                        BorrowBook();
                        break;
                    case 4:
                        ReturnBook();
                        break;
                    case 5:
                        Console.WriteLine("Thank you for choosing our service! \n Exiting..");
                        return;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid type input!");
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid type input!");
            }
        }
    }
}
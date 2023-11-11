using System;
using System.Collections.Generic;
using System.Globalization;

class Program
{
    static List<Book> books = new List<Book>();  // قائمة لتخزين الكتب
    static List<User> users = new List<User>();  // قائمة لتخزين المستخدمين
    static List<Loan> loans = new List<Loan>();  // قائمة لتخزين الإعارات

    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("1. Add Book");  // إضافة كتاب
            Console.WriteLine("2. Add User");  // إضافة مستخدم
            Console.WriteLine("3. Add Loan");  // إضافة إعارة
            Console.WriteLine("4. Exit");  // الخروج
            Console.WriteLine("Enter your choice:");  // أدخل اختيارك:

            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Invalid choice. Please try again.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    AddBook();
                    break;
                case 2:
                    AddUser();
                    break;
                case 3:
                    AddLoan();
                    break;
                case 4:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");  // اختيار غير صالح. يرجى المحاولة مرة أخرى.
                    break;
            }
        }
    }

    static void AddBook()
    {
        Console.WriteLine("Enter BookID:");  // أدخل معرف الكتاب:
        int bookID;
        if (!int.TryParse(Console.ReadLine(), out bookID))
        {
            Console.WriteLine("Invalid book ID. Please enter a valid integer value.");
            return;
        }

        if (BookExists(bookID))
        {
            Console.WriteLine("Book with the given ID already exists.");  // الكتاب بالمعرف المحدد موجود بالفعل.
            return;
        }

        Console.WriteLine("Enter Title:");  // أدخل العنوان:
        string title = Console.ReadLine();

        Console.WriteLine("Enter Author:");  // أدخل الكاتب:
        string author = Console.ReadLine();

        Console.WriteLine("Enter Publication Year:");  // أدخل سنة النشر:
        int publicationYear;
        if (!int.TryParse(Console.ReadLine(), out publicationYear))
        {
            Console.WriteLine("Invalid publication year. Please enter a valid integer value.");
            return;
        }

        Console.WriteLine("Enter Category:");  // أدخل الفئة:
        string category = Console.ReadLine();

        Book book = new Book(bookID, title, author, publicationYear, category);
        books.Add(book);

        Console.WriteLine("Book added successfully.");  // تمت إضافة الكتاب بنجاح.
    }

    static void AddUser()
    {
        Console.WriteLine("Enter UserID:");  // أدخل معرف المستخدم:
        int userID;
        if (!int.TryParse(Console.ReadLine(), out userID))
        {
            Console.WriteLine("Invalid user ID. Please enter a valid integer value.");
            return;
        }

        if (UserExists(userID))
        {
            Console.WriteLine("User with the given ID already exists.");  // المستخدم بالمعرف المحدد موجود بالفعل.
            return;
        }

        Console.WriteLine("Enter Username:");  // أدخل اسم المستخدم:
        string username = Console.ReadLine();

        User user = new User(userID, username);
        users.Add(user);

        Console.WriteLine("User added successfully.");  // تمت إضافة المستخدم بنجاح.
    }

    static void AddLoan()
    {
        Console.WriteLine("Enter LoanID:");  // أدخل معرف الإعارة:
        int loanID;
        if (!int.TryParse(Console.ReadLine(), out loanID))
        {
            Console.WriteLine("Invalid loan ID. Please enter a valid integer value.");
            return;
        }

        if (LoanExists(loanID))
        {
            Console.WriteLine("Loan with the given ID already exists.");  // الإعارة بالمعرف المحدد موجودة بالفعل.
            return;
        }

        Console.WriteLine("Enter BookID:");  // أدخل معرف الكتاب:
        int bookID;
        if (!int.TryParse(Console.ReadLine(), out bookID))
        {
            Console.WriteLine("Invalid book ID. Please enter a valid integer value.");
            return;
        }

        if (!BookExists(bookID))
        {
            Console.WriteLine("Book with the given ID does not exist.");  // الكتاب بالمعرف المحدد غير موجود.
            return;
        }

        Console.WriteLine("Enter UserID:");  // أدخل معرف المستخدم:
        int userID;
        if (!int.TryParse(Console.ReadLine(), out userID))
        {
            Console.WriteLine("Invalid user ID. Please enter a valid integer value.");
            return;
        }

        if (!UserExists(userID))
        {
            Console.WriteLine("User with the given ID does not exist.");  // المستخدم بالمعرف المحدد غير موجود.
            return;
        }

        Console.WriteLine("Enter Start Date (YYYY-MM-DD):");  // أدخل تاريخ البدء (YYYY-MM-DD):
        DateTime startDate;
        if (!DateTime.TryParseExact(Console.ReadLine(), "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out startDate))
        {
            Console.WriteLine("Invalid start date. Please enter a valid date in the format YYYY-MM-DD.");
            return;
        }

        Console.WriteLine("Enter Return Date (YYYY-MM-DD):");  // أدخل تاريخ الإرجاع (YYYY-MM-DD):
        DateTime returnDate;
        if (!DateTime.TryParseExact(Console.ReadLine(), "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out returnDate))
        {
            Console.WriteLine("Invalid return date. Please enter a valid date in the format YYYY-MM-DD.");
            return;
        }

        Loan loan = new Loan(loanID, bookID, userID, startDate, returnDate);
        loans.Add(loan);

        Console.WriteLine("Loan added successfully.");  // تمت إضافة الإعارة بنجاح.
    }

    static bool BookExists(int bookID)
    {
        return books.Exists(book => book.BookID == bookID);
    }

    static bool UserExists(int userID)
    {
        return users.Exists(user => user.UserID == userID);
    }

    static bool LoanExists(int loanID)
    {
        return loans.Exists(loan => loan.LoanID == loanID);
    }
}

class Book
{
    public int BookID { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public int PublicationYear { get; set; }
    public string Category { get; set; }

    public Book(int bookID, string title, string author, int publicationYear, string category)
    {
        BookID = bookID;
        Title = title;
        Author = author;
        PublicationYear = publicationYear;
        Category = category;
    }
}

class User
{
    public int UserID { get; set; }
    public string Username { get; set; }

    public User(int userID, string username)
    {
        UserID = userID;
        Username = username;
    }
}

class Loan
{
    public int LoanID { get; set; }
    public int BookID { get; set; }
    public int UserID { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime ReturnDate { get; set; }

    public Loan(int loanID, int bookID, int userID, DateTime startDate, DateTime returnDate)
    {
        LoanID = loanID;
        BookID = bookID;
        UserID = userID;
        StartDate = startDate;
        ReturnDate = returnDate;
    }
}
// See https://aka.ms/new-console-template for more information
using CodingWiki_DataAccess.Data;
using CodingWiki_DataAccess.Migrations;
using CodingWiki_Model.Models;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Hello, World!");

/*

// cretaing an object of the context
using(ApplicationDbContext context = new())
{
    // checking with the help of connection string that DB is created
    // if not exists, creates a Database
    context.Database.EnsureCreated();


    //applying all the pending migrations
    if(context.Database.GetPendingMigrations().Count()  > 0)
    {
        context.Database.Migrate();
    }

}

// AddBook();
// GetAllBooks();

void GetAllBooks()
{
    using var context = new ApplicationDbContext();
    var books = context.Books.ToList();

    foreach(var book in books)
    {
        Console.WriteLine(book.Title+ " - " + book.ISBN);
    }
}

void AddBook()
{
    Book book = new Book {Title="rishabh new book", ISBN="121212", Price=13.00m, Publisher_Id=1 };
    //dont provide ID, error shown, EF core automatically enters that by ownself

    using var context = new ApplicationDbContext();
    var books = context.Books.Add(book);
    // till here it only knows it has something to add

    context.SaveChanges();
    // adds in DB after this step
}

//GetBooks();

void GetBooks()
{
    using var context = new ApplicationDbContext();
    Book book = context.Books.Where(u=>u.Publisher_Id==3 && u.Price>10).FirstOrDefault();

    //Book book = context.Books.FirstOrDefault(u => u.Title=="rishabh book");

    Console.WriteLine(book.Title);
}

//GetByFind();
void GetByFind()
{
    using var context = new ApplicationDbContext();
    Book book = context.Books.Find(4);
    Console.WriteLine(book.Title);
}

//GetBySingle();
void GetBySingle()
{
    using var context = new ApplicationDbContext();
    Book book = context.Books.Single(u => u.Title == "value");
    Console.WriteLine(book.Title);
}

//GetContain();
void GetContain()
{
    using var context = new ApplicationDbContext();
    var books = context.Books.Where(u => u.Title.Contains("si"));
    
    foreach(var book in books)
    {
        Console.WriteLine(book.Title);
    }
}

//GetLike();
void GetLike()
{
    using var context = new ApplicationDbContext();
    var books = context.Books.Where(u => EF.Functions.Like(u.Title , "Rs%"));
    //starts with Rs 

    foreach (var book in books)
    {
        Console.WriteLine(book.Title);
    }
}

//GetOrder();
void GetOrder()
{
    using var context = new ApplicationDbContext();
    // var books = context.Books.OrderBy(u => u.ISBN).OrderByDescending(u=>u.Title);

    var books = context.Books.OrderBy(u => u.ISBN).ThenByDescending(u => u.Title);
    foreach (var book in books)
    {
        Console.WriteLine(book.Title);
    }
}

//GetPagination();
void GetPagination()
{
    using var context = new ApplicationDbContext();

    var books = context.Books.Skip(2).Take(1);
    foreach (var book in books)
    {
        Console.WriteLine(book.Title);
    }
}

// UpdateRecord();
void UpdateRecord()
{
    using var context = new ApplicationDbContext();
    var book = context.Books.Find(4);

    book.ISBN = "abcdabcd";
    context.SaveChanges();
}

 RemoveRecord();
void RemoveRecord()
{
    using var context = new ApplicationDbContext();
    var book = context.Books.Find(3);
    context.Books.Remove(book);
    context.SaveChanges();
}

*/
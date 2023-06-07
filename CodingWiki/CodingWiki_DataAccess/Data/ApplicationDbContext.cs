using Microsoft.EntityFrameworkCore;
using CodingWiki_Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodingWiki_DataAccess.FluentConfig;

namespace CodingWiki_DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<BookDetail> BookDetails { get; set; }

        //renaming table using fluent API
        public DbSet<Fluent_BookDetail> BookDetails_fluent { get; set; }
        public DbSet<Fluent_Book> Books_fluent { get; set; }

        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        
        
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            //options.UseSqlServer("Server=.\\SQLEXPRESS;Database=CodingWiki;TrustServerCertificate=True;Trusted_Connection=True;");
               // .LogTo(Console.WriteLine);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FluentBookConfig());
            modelBuilder.ApplyConfiguration(new FluentBookDetailConfig());

            modelBuilder.Entity<Book>().Property(u => u.Price).HasPrecision(10, 5);
            modelBuilder.Entity<Book>().HasData(
                new Book {BookId = 1, Title = "Rsihabh Book", ISBN = "1231234", Price = 10.99m, Publisher_Id=1 });

            //adding multiple records
            var bookList = new Book[]
            {
                new Book {BookId = 2, Title = "Rsihabh Book2", ISBN = "1231235", Price = 10.99m, Publisher_Id=2},
                new Book { BookId = 3, Title = "Rsihabh Book3", ISBN = "1231236", Price = 10.99m , Publisher_Id=3}
            };

            modelBuilder.Entity<Book>().HasData(bookList);

            modelBuilder.Entity<Publisher>().HasData(
                new Publisher { Publisher_Id = 1, Name = "p1", Location= "chicago" },
                new Publisher { Publisher_Id = 2, Name = "p2", Location = "havana" },
                new Publisher { Publisher_Id = 3, Name = "p3", Location = "Paris" }
                );

        }
    }
}

﻿// <auto-generated />
using System;
using CodingWiki_DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CodingWiki_DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230605065518_oneToOneFAPI")]
    partial class oneToOneFAPI
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AuthorBook", b =>
                {
                    b.Property<int>("AuthorsAuthor_Id")
                        .HasColumnType("int");

                    b.Property<int>("BooksBookId")
                        .HasColumnType("int");

                    b.HasKey("AuthorsAuthor_Id", "BooksBookId");

                    b.HasIndex("BooksBookId");

                    b.ToTable("AuthorBook");
                });

            modelBuilder.Entity("CodingWiki_Model.Models.Author", b =>
                {
                    b.Property<int>("Author_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Author_Id"));

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Author_Id");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("CodingWiki_Model.Models.Book", b =>
                {
                    b.Property<int>("BookId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookId"));

                    b.Property<string>("ISBN")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasPrecision(10, 5)
                        .HasColumnType("decimal(10,5)");

                    b.Property<int>("Publisher_Id")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BookId");

                    b.HasIndex("Publisher_Id");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            BookId = 1,
                            ISBN = "1231234",
                            Price = 10.99m,
                            Publisher_Id = 1,
                            Title = "Rsihabh Book"
                        },
                        new
                        {
                            BookId = 2,
                            ISBN = "1231235",
                            Price = 10.99m,
                            Publisher_Id = 2,
                            Title = "Rsihabh Book2"
                        },
                        new
                        {
                            BookId = 3,
                            ISBN = "1231236",
                            Price = 10.99m,
                            Publisher_Id = 3,
                            Title = "Rsihabh Book3"
                        });
                });

            modelBuilder.Entity("CodingWiki_Model.Models.BookDetail", b =>
                {
                    b.Property<int>("BookDetail_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookDetail_Id"));

                    b.Property<int>("Book_Id")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfChapter")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfPages")
                        .HasColumnType("int");

                    b.Property<string>("Weight")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BookDetail_Id");

                    b.HasIndex("Book_Id")
                        .IsUnique();

                    b.ToTable("BookDetails");
                });

            modelBuilder.Entity("CodingWiki_Model.Models.Fluent_Book", b =>
                {
                    b.Property<int>("BookId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookId"));

                    b.Property<string>("ISBN")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BookId");

                    b.ToTable("Books_fluent");
                });

            modelBuilder.Entity("CodingWiki_Model.Models.Fluent_BookDetail", b =>
                {
                    b.Property<int>("BookDetail_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookDetail_Id"));

                    b.Property<int>("Book_Id")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfChapter")
                        .HasColumnType("int")
                        .HasColumnName("NoOfChapter");

                    b.Property<int>("NumberOfPages")
                        .HasColumnType("int");

                    b.Property<string>("Weight")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BookDetail_Id");

                    b.HasIndex("Book_Id")
                        .IsUnique();

                    b.ToTable("Fluent_BookDetails", (string)null);
                });

            modelBuilder.Entity("CodingWiki_Model.Models.Genre", b =>
                {
                    b.Property<int>("GenreId")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(10)
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GenreId"));

                    b.Property<string>("DisplayOrder")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GenreName")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Nanme");

                    b.HasKey("GenreId");

                    b.ToTable("tb_genres");
                });

            modelBuilder.Entity("CodingWiki_Model.Models.Publisher", b =>
                {
                    b.Property<int>("Publisher_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Publisher_Id"));

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Publisher_Id");

                    b.ToTable("Publishers");

                    b.HasData(
                        new
                        {
                            Publisher_Id = 1,
                            Location = "chicago",
                            Name = "p1"
                        },
                        new
                        {
                            Publisher_Id = 2,
                            Location = "havana",
                            Name = "p2"
                        },
                        new
                        {
                            Publisher_Id = 3,
                            Location = "Paris",
                            Name = "p3"
                        });
                });

            modelBuilder.Entity("CodingWiki_Model.Models.SubCategory", b =>
                {
                    b.Property<int>("Subcatagory_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Subcatagory_Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Subcatagory_Id");

                    b.ToTable("SubCategories");
                });

            modelBuilder.Entity("AuthorBook", b =>
                {
                    b.HasOne("CodingWiki_Model.Models.Author", null)
                        .WithMany()
                        .HasForeignKey("AuthorsAuthor_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CodingWiki_Model.Models.Book", null)
                        .WithMany()
                        .HasForeignKey("BooksBookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CodingWiki_Model.Models.Book", b =>
                {
                    b.HasOne("CodingWiki_Model.Models.Publisher", "Publisher")
                        .WithMany("Books")
                        .HasForeignKey("Publisher_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Publisher");
                });

            modelBuilder.Entity("CodingWiki_Model.Models.BookDetail", b =>
                {
                    b.HasOne("CodingWiki_Model.Models.Book", "Book1")
                        .WithOne("BookDetail1")
                        .HasForeignKey("CodingWiki_Model.Models.BookDetail", "Book_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book1");
                });

            modelBuilder.Entity("CodingWiki_Model.Models.Fluent_BookDetail", b =>
                {
                    b.HasOne("CodingWiki_Model.Models.Fluent_Book", "Book1")
                        .WithOne("BookDetail1")
                        .HasForeignKey("CodingWiki_Model.Models.Fluent_BookDetail", "Book_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book1");
                });

            modelBuilder.Entity("CodingWiki_Model.Models.Book", b =>
                {
                    b.Navigation("BookDetail1");
                });

            modelBuilder.Entity("CodingWiki_Model.Models.Fluent_Book", b =>
                {
                    b.Navigation("BookDetail1");
                });

            modelBuilder.Entity("CodingWiki_Model.Models.Publisher", b =>
                {
                    b.Navigation("Books");
                });
#pragma warning restore 612, 618
        }
    }
}

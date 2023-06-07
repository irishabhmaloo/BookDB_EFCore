using CodingWiki_Model.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingWiki_DataAccess.FluentConfig
{
    public class FluentBookConfig : IEntityTypeConfiguration<Fluent_Book>
    {
        public void Configure(EntityTypeBuilder<Fluent_Book> modelBuilder)
        {
            //1-M mapping
            modelBuilder.HasOne(b => b.Publisher).WithMany(b => b.Books)
                .HasForeignKey(u => u.Publisher_Id);

            modelBuilder.Property(u => u.ISBN).HasMaxLength(50); //MaxLength
            modelBuilder.Ignore(u => u.BookId); // NotMapped
            modelBuilder.HasKey(u => u.BookId); //primary key
            modelBuilder.Property(U => U.ISBN).IsRequired(); //required
        }
    }
}

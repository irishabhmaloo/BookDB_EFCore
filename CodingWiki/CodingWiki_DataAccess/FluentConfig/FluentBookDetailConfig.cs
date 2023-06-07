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
    public class FluentBookDetailConfig : IEntityTypeConfiguration<Fluent_BookDetail>
    {
        public void Configure(EntityTypeBuilder<Fluent_BookDetail> modelBuilder)
        {
            modelBuilder.ToTable("Fluent_BookDetails"); //table
            modelBuilder.Property(u => u.NumberOfChapter).HasColumnName("NoOfChapter"); //column
            modelBuilder.Property(U => U.NumberOfChapter).IsRequired(); //required
            modelBuilder.HasKey(u => u.BookDetail_Id); //primary key


            //1-1 mapping
            modelBuilder.HasOne(b => b.Book1).WithOne(b => b.BookDetail1)
                .HasForeignKey<Fluent_BookDetail>(u => u.Book_Id);
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingWiki_Model.Models
{
    public class BookDetail
    {
        [Key]
        public int BookDetail_Id { get; set; }
        
        [Required]
        public int NumberOfChapter { get; set; }

        public int NumberOfPages { get; set; }

        public string Weight { get; set; }

        [ForeignKey("Book1")]
        public int Book_Id { get; set; }
        public Book Book1 { get; set; }
    }
}

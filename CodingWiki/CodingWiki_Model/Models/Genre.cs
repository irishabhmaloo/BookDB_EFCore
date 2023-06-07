using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingWiki_Model.Models
{
    [Table("tb_genres")]
    public class Genre
    {
        [MaxLength(10)]
        public int GenreId { get; set; }

        [Column("Nanme")]
        public string GenreName { get; set; }

        [Required]
        public string DisplayOrder { get; set;}

        [NotMapped]
        public decimal PriceRange { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Model.Models
{
    [Table("Books")]
    public class Book
    {
        [Key]
        public int id { get; set; }
        [Required]
        [MaxLength(30)]
        public string title { get; set; }
        public string authers { get; set; }

        [Column("Year")]
        [Display(Name = "Publish Year")]
        public string publishYear { get; set; }

        [Column("Price")]
        [Display(Name = "Price")]
        public decimal basePrice { get; set; }
    }
}

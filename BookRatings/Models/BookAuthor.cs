using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BookRatings.Models
{
    public class BookAuthor
    {
        [Column("BookID")]
        public int ID { get; set; }
        [Key]
        public string Author { get; set; }
        public Book Book { get; set; }
    }
}
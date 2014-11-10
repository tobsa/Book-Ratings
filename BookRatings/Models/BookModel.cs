using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookRatings.Models
{
    public class BookModel
    {
        private Dictionary<string, Book> books = new Dictionary<string, Book>();

        public BookModel(List<Book> books)
        {
            this.books = books.ToDictionary(x => x.ID, x => x);
        }

        public List<Book> GetBooks 
        { 
            get { return books.Values.ToList(); } 
        }
    }
}
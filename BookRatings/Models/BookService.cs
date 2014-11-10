using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookRatings.Models
{
    public class BookService
    {
        private BookContext context = new BookContext();

        public void AddBook(Book book)
        {
            context.Books.Add(book);
            context.SaveChanges();
        }

        public List<Book> GetBooks()
        {
            var books = from book in context.Books
                        select book;

            return books.ToList();
        }

        public Book GetBook(string id)
        {
            return context.Books.Where(x => x.ID.Equals(id)).SingleOrDefault();
        }
    }
}
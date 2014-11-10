using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookRatings.Models
{
    public class BookRepository
    {
        public List<Book> GetBooksFromQuery(string query)
        {
            BookParser parser = new BookParser();
            return parser.GetBooks(query);
        }

        public Book GetBookFromQuery(string id)
        {
            BookParser parser = new BookParser();
            return parser.GetBook(id);
        }

        public List<Book> GetBooksFromService()
        {
            BookService service = new BookService();
            return service.GetBooks();
        }

        public Book GetBookFromService(string id)
        {
            BookService service = new BookService();
            return service.GetBook(id);
        }
    }
}
using BookRatings.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookRatings.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        [ActionName("Index")]
        public ActionResult IndexGet()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Index")]
        public ActionResult IndexPost(string query)
        {
            return View("BookSearchResultView");
        }

        public ActionResult BookDetails(string id)
        {
            BookRepository repository = new BookRepository();
            return View("BookDetailView", repository.GetBookFromService(id));
        }

        public ActionResult GoogleSearch()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GoogleSearchResults(string query)
        {
            BookRepository repository = new BookRepository();
            return View("GoogleSearchResultView", new BookModel(repository.GetBooksFromQuery(query)));
        }

        public ActionResult GoogleSearchDetails(string id)
        {
            BookRepository repository = new BookRepository();
            return View("GoogleSearchDetailView", repository.GetBookFromQuery(id));
        }
    }
}
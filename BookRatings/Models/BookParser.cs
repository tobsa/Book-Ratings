using BookRatings.Models.GoogleBooksAPI;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace BookRatings.Models
{
    public class BookParser
    {
        private const string BaseSearchQuery = "https://www.googleapis.com/books/v1/volumes?q=";
        private const string BaseVolumeQuery = "https://www.googleapis.com/books/v1/volumes/";
        private const string MaxResult = "&maxResults=40";

        public List<Book> GetBooks(string query)
        {
            var response = GetQueryResponse<Items>(BaseSearchQuery + query + MaxResult);

            if (response.ItemList == null)
                return new List<Book>();

            var books = from item in response.ItemList
                        select CreateBook(item);

            return books.ToList();
        }

        public Book GetBook(string id)
        {
            return CreateBook(GetQueryResponse<Item>(BaseVolumeQuery + id));            
        }

        private T GetQueryResponse<T>(string query)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(query);
            request.Method = "GET";
            request.Accept = "application/json; charset=utf-8";

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            string text;
            using (StreamReader reader = new StreamReader(response.GetResponseStream()))
            {
                text = reader.ReadToEnd();
            }

            response.Close();
            return JsonConvert.DeserializeObject<T>(text);
        }

        private Book CreateBook(Item item)
        {
            Book book = new Book();
            if (item != null)
            {
                book.ID = item.ID;

                VolumeInfo volumeInfo = item.VolumeInfo;
                if (volumeInfo != null)
                {
                    book.Title = volumeInfo.Title;
                    book.Subtitle = volumeInfo.Subtitle;
                    book.Authors = new string[0];

                    if(volumeInfo.Authors != null)
                        book.Authors = volumeInfo.Authors;

                    book.Description = volumeInfo.Description;
                    book.Publisher = volumeInfo.Publisher;
                    book.PublishedDate = volumeInfo.PublishedDate;
                    book.Language = volumeInfo.Language;
                    book.PageCount = volumeInfo.PageCount;
                    book.AverageRating = item.VolumeInfo.AverageRating;
                    book.RatingsCount = item.VolumeInfo.RatingsCount;

                    ImageLinks imageLinks = volumeInfo.ImageLinks;
                    if (imageLinks != null)
                    {
                        book.Thumbnail = imageLinks.Thumbnail;
                        book.ThumbnailSmall = imageLinks.SmallThumbnail;
                    }

                    book.IndustryIdentifiers = new Dictionary<string,string>();

                    IndustryIdentifier[] identifiers = volumeInfo.IndustryIdentifiers;
                    if(identifiers != null)
                        book.IndustryIdentifiers = identifiers.ToDictionary(x => x.Type, x => x.Identifier);
                }
            }

            return book;
        }
    }
}
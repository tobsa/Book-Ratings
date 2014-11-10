using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookRatings.Models
{
    public class Book
    {
        public string ID { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string[] Authors { get; set; }
        public string Publisher { get; set; }
        public string PublishedDate { get; set; }
        public string Language { get; set; }
        public int PageCount { get; set; }
        public Dictionary<string, string> IndustryIdentifiers { get; set; }
        public string Description { get; set; }
        public double AverageRating { get; set; }
        public int RatingsCount { get; set; }
        public string Thumbnail { get; set; }
        public string ThumbnailSmall { get; set; }
    }
}
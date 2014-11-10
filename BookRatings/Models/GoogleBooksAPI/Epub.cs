using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookRatings.Models.GoogleBooksAPI
{
    public class Epub
    {
        [JsonProperty("isAvailable")]
        public bool IsAvailable { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookRatings.Models
{
    public static class HtmlHelperBookRatings
    {
        public static MvcHtmlString Truncate(this HtmlHelper helper, string input, int length)
        {
            if (input == null)
                return MvcHtmlString.Empty;

            if (input.Length <= length)
                return MvcHtmlString.Create(input);

            return MvcHtmlString.Create(input.Substring(0, length) + "...");
        }

        public static MvcHtmlString DisplayRating(this HtmlHelper helper, double averageRating)
        {
            TagBuilder builder = new TagBuilder("span");
            for (int i = 1; i <= 5; i++)
            {
                TagBuilder spanBuilder = new TagBuilder("span");

                if (i <= (int)averageRating)
                    spanBuilder.AddCssClass("glyphicon glyphicon-star");
                else
                    spanBuilder.AddCssClass("glyphicon glyphicon-star-empty");

                builder.InnerHtml += spanBuilder.ToString();
            }

            return MvcHtmlString.Create(builder.ToString());
        }

        public static MvcHtmlString DisplayAuthors(this HtmlHelper helper, string[] authors)
        {
            TagBuilder builder = new TagBuilder("span");

            foreach (string author in authors)
            {
                if(author == authors.Last())
                    builder.InnerHtml += author;
                else
                    builder.InnerHtml += author + ", ";
            }

            return MvcHtmlString.Create(builder.ToString());
        }
    }

    
}
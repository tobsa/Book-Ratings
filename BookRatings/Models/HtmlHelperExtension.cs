using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace BookRatings.Models
{
    public static class HtmlHelperExtension
    {
        public static MvcHtmlString ImageLink(this HtmlHelper helper, string src, string url, object srcAttributes = null)
        {
            TagBuilder urlBuilder = new TagBuilder("a");
            urlBuilder.MergeAttribute("href", url);
            urlBuilder.InnerHtml = helper.Image(src, srcAttributes).ToString();

            return MvcHtmlString.Create(urlBuilder.ToString());
        }

        public static MvcHtmlString Image(this HtmlHelper helper, string src, object srcAttributes = null)
        {
            TagBuilder imageBuilder = new TagBuilder("img");
            imageBuilder.MergeAttribute("src", src);

            if (srcAttributes != null)
            {
                srcAttributes = new RouteValueDictionary(srcAttributes);
                imageBuilder.MergeAttributes((IDictionary<string, object>)srcAttributes, true);
            }

            return MvcHtmlString.Create(imageBuilder.ToString());
        }
    }
}
using NewsBlogDAL.Enums;
using System.Collections.Generic;
using System.Web.Mvc;

namespace NewsBlog.Helpers
{
    /// <summary>
    /// Create list for integrate in html
    /// </summary>
    public static class ListHelper
    {
        /// <summary>
        /// Create list
        /// </summary>
        /// <param name="html"></param>
        /// <param name="items"></param>
        /// <returns>html string</returns>
        public static MvcHtmlString CreateList(this HtmlHelper html, List<Preference> items)
        {
            if (items == null) return new MvcHtmlString("List is null");
            TagBuilder ul = new TagBuilder("ul");
            foreach (var item in items)
            {
                TagBuilder li = new TagBuilder("li");
                li.SetInnerText(item.ToString());
                ul.InnerHtml += li.ToString();
            }
            return new MvcHtmlString(ul.ToString());
        }
    }
}
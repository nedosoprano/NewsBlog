using System;
using System.Web.Mvc;

namespace NewsBlog.Helpers
{
    /// <summary>
    /// Create list of inputters for integrate in html
    /// </summary>
    public static class PickListHelper
    {
        /// <summary>
        /// Create list of inputters
        /// </summary>
        /// <param name="html"></param>
        /// <param name="items"></param>
        /// <param name="inputType"></param>
        /// <param name="theme"></param>
        /// <returns>html string</returns>
        public static MvcHtmlString CreateList(this HtmlHelper html, Array items, string inputType, string theme)
        {
            string container = "";

            foreach (var i in items)
            {
                TagBuilder input = new TagBuilder("input");
                input.MergeAttribute("type", inputType);
                input.MergeAttribute("name", theme);
                input.MergeAttribute("value", i.ToString());
                container += input.ToString();

                TagBuilder span = new TagBuilder("span");
                span.SetInnerText(i.ToString());
                container += span.ToString();

                container += "<br />";
            }

            return new MvcHtmlString(container.ToString());
        }
    }
}
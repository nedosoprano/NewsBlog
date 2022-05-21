using System.Web.Mvc;
using System;
using System.Web.Mvc.Html;

namespace NewsBlog.Helpers
{
    /// <summary>
    /// Create menu for integrate in html
    /// </summary>
    public static class MenuHelper
    {
        /// <summary>
        /// Create menu
        /// </summary>
        /// <param name="html"></param>
        /// <param name="isLogIn"></param>
        /// <returns>html string</returns>
        public static MvcHtmlString CreateMenu(this HtmlHelper html, bool isLogIn)
        {
            TagBuilder menu = new TagBuilder("menu");
            menu.InnerHtml += html.ActionLink("Main page", "Index", "Home");
            menu.InnerHtml += html.ActionLink("Guest page", "Guest", "Guest");
            menu.InnerHtml += html.ActionLink("Questionnaire page", "Questionnaire", "Questionnaire");
            menu.InnerHtml += isLogIn ? html.ActionLink("Sign Out", "SignOut", "User") : html.ActionLink("Log In", "Login", "User");
            return new MvcHtmlString(menu.ToString());
        }
    }
}
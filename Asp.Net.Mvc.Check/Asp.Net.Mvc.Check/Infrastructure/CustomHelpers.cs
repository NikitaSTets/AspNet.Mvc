using System.Web.Mvc;

namespace Asp.Net.Mvc.Check.Infrastructure
{
    public static class CustomHelpers
    {
        public static MvcHtmlString ListArrayItems(this HtmlHelper html, string[] list)
        {
            var ulTag = new TagBuilder("ul");
            foreach (string str in list)
            {
                var ilTag = new TagBuilder("li");
                ilTag.SetInnerText(str);
                ulTag.InnerHtml += ilTag.ToString();
            }

            return new MvcHtmlString(ulTag.ToString());
        }
    }
}
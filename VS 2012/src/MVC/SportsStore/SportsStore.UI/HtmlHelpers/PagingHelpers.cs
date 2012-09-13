using SportsStore.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace SportsStore.UI.HtmlHelpers
{
    public static class PagingHelpers
    {
        public static MvcHtmlString PageLinks(this HtmlHelper html, PagingInfo pagingInfo, Func<int, string> pageUrl)
        {
            var sb = new StringBuilder();

            for (int i = 1; i <= pagingInfo.TotalPages; i++)
            {
                var a = new TagBuilder("a");

                a.MergeAttribute("href", pageUrl(i));
                a.InnerHtml = i.ToString();

                if (i == pagingInfo.CurrentPage)
                {
                    a.AddCssClass("selected");
                }

                sb.Append(a.ToString());
            }

            return MvcHtmlString.Create(sb.ToString());
        }
    }
}
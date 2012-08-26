using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SportsStore.UI.Models;
using SportsStore.UI.HtmlHelpers;
using System.Web.Mvc;
using FluentAssertions;

namespace SportsStore.UnitTests.MVC.HtmlHelpers
{
    [TestClass]
    public class PagingHelpersTests
    {
        [TestClass]
        public class ThePageLinksMethod
        {
            [TestMethod]
            public void can_page_and_render_correct_html()
            {
                var pagingInfo = new PagingInfo { CurrentPage = 2, ItemsPerPage = 3, TotalItems = 5 };
                Func<int, string> pageUrl = x => "Page" + x.ToString();
                HtmlHelper sut = null;
                var res = sut.PageLinks(pagingInfo, pageUrl);

                res.ToString()
                    .Should()
                        .NotBeNullOrEmpty()
                    .And
                        .NotBeBlank()
                    .And
                        .Be(@"<a href=""Page1"">1</a><a class=""selected"" href=""Page2"">2</a>");
            }
        }
    }
}

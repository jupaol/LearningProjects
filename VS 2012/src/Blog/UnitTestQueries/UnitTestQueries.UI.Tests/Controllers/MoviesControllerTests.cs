using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestQueries.UI.Controllers;
using UnitTestQueries.UI.Tests.Controllers.Builders;
using FluentAssertions;
using FluentMVCTesting;
using UnitTestQueries.Logic;
using UnitTestQueries.Data;
using System.Web.Mvc;

namespace UnitTestQueries.UI.Tests.Controllers
{
    [TestClass]
    public class MoviesControllerTests
    {
        [TestClass]
        public class TheIndexMethod
        {
            [TestMethod]
            public void it_should_render_the_index_view()
            {
                var builder = new MoviesControllerBuilder()
                    .Setup_MoviesQueryManager_FindAll();
                var sut = builder.Build();

                sut.WithCallTo(x => x.Index(string.Empty)).ShouldRenderDefaultView();
            }

            [TestMethod]
            public void the_model_should_contain_the_list_of_all_movies()
            {
                var builder = new MoviesControllerBuilder()
                    .Setup_MoviesQueryManager_FindAll();
                var movieResults = builder.GetDefaultMovieResults();
                var sut = builder.Build();

                var result = sut.Index() as ViewResult;

                var res = result.Model as QueryResults<Movie>;

                res.Should().NotBeNull().And.Be(movieResults);
            }
        }
    }
}

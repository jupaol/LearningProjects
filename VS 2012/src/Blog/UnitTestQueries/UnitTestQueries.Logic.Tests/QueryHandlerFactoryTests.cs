using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestQueries.Logic.Tests.Builders;
using FluentAssertions;
using UnitTestQueries.Data;

namespace UnitTestQueries.Logic.Tests
{
    [TestClass]
    public class QueryHandlerFactoryTests
    {
        [TestClass]
        public class TheCreateMethod
        {
            [TestMethod]
            public void it_should_not_throw_an_exception_when_the_requested_type_is_found()
            {
                var sut = new QueryHandlerFactoryBuilder()
                    .SetupServiceLocatorReturningAQueryHandlerObjectWithAnonymous<FindMoviesByTitleQuery, Movie>()
                    .Build();

                sut.Invoking(x => x.Create<FindMoviesByTitleQuery, Movie>())
                    .ShouldNotThrow();
            }

            [TestMethod]
            public void it_should_return_the_registered_query_handler()
            {
                var builder = new QueryHandlerFactoryBuilder()
                .SetupServiceLocatorReturningAQueryHandlerObjectWithAnonymous<FindMoviesByTitleQuery, Movie>();
                var queryHandler = builder.GetQueryHandler<FindMoviesByTitleQuery, Movie>();
                var sut = builder.Build();

                var res = sut.Create<FindMoviesByTitleQuery, Movie>();

                res.Should().NotBeNull().And.Be(queryHandler);
            }

            [TestMethod]
            public void it_should_throw_an_exception_when_the_requested_type_is_not_found()
            {
                var sut = new QueryHandlerFactoryBuilder()
                    .SetupServiceLocatorReturningAQueryHandlerObject<FindMoviesByTitleQuery, Movie>(null)
                    .Build();

                sut.Invoking(x => x.Create<FindMoviesByTitleQuery, Movie>())
                    .ShouldThrow<Exception>();
            }
        }
    }
}

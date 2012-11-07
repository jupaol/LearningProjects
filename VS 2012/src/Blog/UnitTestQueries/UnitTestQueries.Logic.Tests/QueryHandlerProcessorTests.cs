using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestQueries.Logic.Tests.Builders;
using UnitTestQueries.Data;
using FluentAssertions;
using CuttingEdge.Conditions;

namespace UnitTestQueries.Logic.Tests
{
    [TestClass]
    public class QueryHandlerProcessorTests
    {
        [TestClass]
        public class TheProcessMethod
        {
            [TestMethod]
            public void it_should_throw_an_eception_if_the_specified_type_is_not_found()
            {
                var builder = new QueryHandlerProcessorBuilder()
                    .SetupQueryHandlerFactoryMock<FindMoviesByTitleQuery, Movie>(null);

                var sut = builder.Build();

                sut.Invoking(x => x.Process<FindMoviesByTitleQuery, Movie>(new FindMoviesByTitleQuery(string.Empty)))
                    .ShouldThrow<PostconditionException>();
            }

            [TestMethod]
            public void it_should_throw_an_exception_if_the_result_of_HandleQuery_is_null()
            {
                var sut = new QueryHandlerProcessorBuilder()
                    .SetupQueryHandlerMock<FindMoviesByTitleQuery, Movie>(null)
                    .SetupQueryHandlerFactoryMockWithConfiguredMock<FindMoviesByTitleQuery, Movie>()
                    .Build();

                sut.Invoking(x => x.Process<FindMoviesByTitleQuery, Movie>(new FindMoviesByTitleQuery(string.Empty)))
                    .ShouldThrow<PostconditionException>();
            }

            [TestMethod]
            public void it_should_not_throw_an_exception_if_it_can_process_the_query()
            {
                var sut = new QueryHandlerProcessorBuilder()
                    .SetupQueryHandlerMockWithAnonymous<FindMoviesByTitleQuery, Movie>()
                    .SetupQueryHandlerFactoryMockWithConfiguredMock<FindMoviesByTitleQuery, Movie>()
                    .Build();

                sut.Invoking(x => x.Process<FindMoviesByTitleQuery, Movie>(new FindMoviesByTitleQuery(string.Empty)))
                    .ShouldNotThrow();
            }

            [TestMethod]
            public void it_should_return_the_handled_query()
            {
                var builder = new QueryHandlerProcessorBuilder()
                    .SetupQueryHandlerMockWithAnonymous<FindMoviesByTitleQuery, Movie>()
                    .SetupQueryHandlerFactoryMockWithConfiguredMock<FindMoviesByTitleQuery, Movie>();
                var queryResults = builder.GetQueryResult<Movie>();
                var sut = builder.Build();

                var res = sut.Process<FindMoviesByTitleQuery, Movie>(new FindMoviesByTitleQuery(string.Empty));

                res.Should().NotBeNull();
                res.Should().Be(queryResults);
            }
        }
    }
}

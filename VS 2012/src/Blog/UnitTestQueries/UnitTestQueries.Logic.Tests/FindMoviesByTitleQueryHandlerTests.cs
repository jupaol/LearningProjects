using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using FizzWare.NBuilder;
using UnitTestQueries.Data;
using FluentAssertions;
using UnitTestQueries.Logic.Tests.Builders;

namespace UnitTestQueries.Logic.Tests
{
    [TestClass]
    public class FindMoviesByTitleQueryHandlerTests
    {
        [TestClass]
        public class TheHandleQueryMethod
        {
            [TestMethod]
            public void it_should_not_apply_the_query_when_the_title_is_null_or_empty()
            {
                var numberOfElements = 10;
                var builder = new FindMoviesByTitleQueryHandlerBuilder();
                var sut = builder.Build();
                var movies = builder.Movies;
                var queryObject = new FindMoviesByTitleQuery(string.Empty);

                var res = sut.HandleQuery(queryObject);

                res.Should().NotBeNull();
                res.VirtualRowsCount.Should().Be(numberOfElements);
                res.Results.Should().NotBeNull()
                    .And.HaveCount(numberOfElements)
                    .And.ContainInOrder(movies);
            }

            [TestMethod]
            public void it_should_apply_the_query_and_return_the_matching_elements_when_the_title_is_not_null_nor_empty()
            {
                var numberOfElements = 10;
                var movies = Builder<Movie>.CreateListOfSize(numberOfElements)
                    .TheFirst(1)
                        .With(x => x.Title, "Warcraft")
                    .TheNext(1)
                        .With(x => x.Title, "Avatar")
                    .TheNext(1)
                        .With(x => x.Title, "World War II")
                    .Build().AsQueryable();
                var sut = new FindMoviesByTitleQueryHandlerBuilder().SetMovies(movies).Build();
                var titleFilter = "war";
                var queryObject = new FindMoviesByTitleQuery(titleFilter);

                var res = sut.HandleQuery(queryObject);
                var filteredMovies = movies.Where(x => x.Title.Contains(titleFilter));

                res.Should().NotBeNull();
                res.VirtualRowsCount.Should().Be(2);
                res.Results.Should().NotBeNull()
                    .And.HaveCount(2)
                    .And.ContainInOrder(filteredMovies);
            }

            [TestMethod]
            public void it_should_sort_and_page_using_the_specified_order_field_when_order_field_is_not_null_nor_empty()
            {
                var items = Builder<Movie>.CreateListOfSize(10).Build().AsQueryable();
                var sut = new FindMoviesByTitleQueryHandlerBuilder().SetMovies(items).Build();
                var query = new FindMoviesByTitleQuery(string.Empty);
                var pagingAndSortingInfo = new PagingAndSortingInfo(3, 3, "ID");
                var processedItems = items.OrderBy(x => x.ID).Skip(6).Take(3);

                var res = sut.HandleQuery(query, pagingAndSortingInfo);

                res.Should().NotBeNull();
                res.VirtualRowsCount.Should().Be(3);
                res.Results.Should().NotBeNull()
                    .And.HaveCount(3)
                    .And.ContainInOrder(processedItems);
            }

            [TestMethod]
            public void it_should_sort_descending_and_page_using_the_specified_order_field_when_order_field_is_not_null_nor_empty()
            {
                var items = Builder<Movie>.CreateListOfSize(10).Build().AsQueryable();
                var sut = new FindMoviesByTitleQueryHandlerBuilder().SetMovies(items).Build();
                var query = new FindMoviesByTitleQuery(string.Empty);
                var pagingAndSortingInfo = new PagingAndSortingInfo(3, 3, "ID", OrderDirection.Descending);
                var processedItems = items.OrderByDescending(x => x.ID).Skip(6).Take(3);

                var res = sut.HandleQuery(query, pagingAndSortingInfo);

                res.Should().NotBeNull();
                res.VirtualRowsCount.Should().Be(3);
                res.Results.Should().NotBeNull()
                    .And.HaveCount(3)
                    .And.ContainInOrder(processedItems);
            }

            [TestMethod]
            public void it_should_sort_and_page_using_the_default_order_when_order_field_is_null_or_empty()
            {
                var items = Builder<Movie>.CreateListOfSize(10).Build().AsQueryable();
                var sut = new FindMoviesByTitleQueryHandlerBuilder().SetMovies(items).Build();
                var query = new FindMoviesByTitleQuery(string.Empty);
                var pagingAndSortingInfo = new PagingAndSortingInfo(3, 3, string.Empty);
                var processedItems = items.OrderBy(x => x.Title).Skip(6).Take(3);

                var res = sut.HandleQuery(query, pagingAndSortingInfo);

                res.Should().NotBeNull();
                res.VirtualRowsCount.Should().Be(3);
                res.Results.Should().NotBeNull()
                    .And.HaveCount(3)
                    .And.ContainInOrder(processedItems);
            }

            [TestMethod]
            public void it_should_throw_an_exception_when_the_value_for_the_OrderDirection_enumeration_is_out_of_range()
            {
                var sut = new FindMoviesByTitleQueryHandlerBuilder().Build();

                sut.Invoking(x => x.HandleQuery(new FindMoviesByTitleQuery(string.Empty), new PagingAndSortingInfo(orderByField: "ID", orderDirection: (OrderDirection)4)))
                    .ShouldThrow<ArgumentOutOfRangeException>()
                    .WithMessage("Sorting can only be Ascending or Descending.", ComparisonMode.Substring);


            }
        }
    }
}

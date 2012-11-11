using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestQueries.Logic.Tests.Mocks;
using FluentAssertions;
using System.Linq;
using System.Reflection;
using UnitTestQueries.Data;

namespace UnitTestQueries.Logic.Tests
{
    [TestClass]
    public class QueryHandler_SpecificQuery_Tests
    {
        [TestClass]
        public class TheHandleQueryMethod
        {
            [TestMethod]
            public void it_should_apply_the_query_without_paging_nor_ordering_when_the_pagingAndSortingInfo_parameter_is_null()
            {
                var sut = new QueryHandler_SpecificQuery_Mock();
                var title = "wa";
                var queryObject = new FindMoviesByTitleQuery(title);
                var property = sut.GetType().GetProperty("InitialItems", BindingFlags.DeclaredOnly | BindingFlags.NonPublic | BindingFlags.Instance);
                var items = (IQueryable<Movie>)property.GetValue(sut);
                var expectedItems = items.Where(x => x.Title.ToLower().Contains(title.ToLower()));

                var res = sut.HandleQuery(queryObject);

                res.Should().NotBeNull();
                res.VirtualRowsCount.Should().Be(expectedItems.Count());
                res.Results.Should().NotBeNull()
                    .And.HaveCount(expectedItems.Count());
                res.Results.ToList().ForEach(z =>
                    {
                        var item = expectedItems.FirstOrDefault(x => x.ID.Equals(z.ID));

                        item.Should().NotBeNull();
                    });
            }

            [TestMethod]
            public void it_should_apply_the_query_paging_and_ordering_when_the_pagingAndSortingInfo_parameter_is_not_null()
            {
                var sut = new QueryHandler_SpecificQuery_Mock();
                var title = "wa";
                var queryObject = new FindMoviesByTitleQuery(title);
                var property = sut.GetType().GetProperty("InitialItems", BindingFlags.DeclaredOnly | BindingFlags.NonPublic | BindingFlags.Instance);
                var items = (IQueryable<Movie>)property.GetValue(sut);
                var pagingInfo = new PagingAndSortingInfo(page: 2, pageSize: 1);
                var pageIndex = pagingInfo.Page - 1;
                var expectedItems = items.Where(x => x.Title.ToLower().Contains(title.ToLower()))
                    .OrderByDescending(x => x.ID).Skip(pageIndex * pagingInfo.PageSize).Take(pagingInfo.PageSize);

                var res = sut.HandleQuery(queryObject, pagingInfo);

                res.Should().NotBeNull();
                res.VirtualRowsCount.Should().Be(expectedItems.Count());
                res.Results.Should().NotBeNull()
                    .And.HaveCount(expectedItems.Count());
                res.Results.ToList().ForEach(z =>
                {
                    var item = expectedItems.FirstOrDefault(x => x.ID.Equals(z.ID));

                    item.Should().NotBeNull("The expected item should belong to the res list");
                });
            }
        }
    }
}

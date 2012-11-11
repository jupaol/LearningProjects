using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ploeh.AutoFixture;
using UnitTestQueries.Logic.Tests.Builders;
using UnitTestQueries.Data;
using Moq;
using UnitTestQueries.Logic.Tests.Mocks;
using FluentAssertions;
using System.Reflection;
using FizzWare.NBuilder;
using System.Linq;

namespace UnitTestQueries.Logic.Tests
{
    [TestClass]
    public class QueryPageAndSortingBaseTests
    {
        [TestClass]
        public class TheApplyPagingAndSortingMethod
        {
            [TestMethod]
            public void it_should_apply_the_default_order_when_the_order_field_is_null_or_empty()
            {
                var sut = new QueryPageAndSortingBaseMock();
                var items = Builder<Movie>.CreateListOfSize(10).Build().AsQueryable();
                var expectedItems = items.OrderByDescending(x => x.Title);
                var methodInfo = sut.GetType().GetMethod("ApplyPagingAndSorting", BindingFlags.Instance | BindingFlags.NonPublic);
                var pagingInfo = new PagingAndSortingInfo(orderByField: string.Empty);

                var res = (IQueryable<Movie>)methodInfo.Invoke(sut, new object[] { items, pagingInfo });

                res.Should().NotBeNull()
                    .And.HaveCount(items.Count())
                    .And.ContainInOrder(expectedItems);
            }

            [TestMethod]
            public void it_should_order_in_ascending_mode_when_the_order_fiels_is_not_null_and_the_order_direction_is_Ascending()
            {
                var sut = new QueryPageAndSortingBaseMock();
                var items = Builder<Movie>.CreateListOfSize(10).Build().AsQueryable();
                var expectedItems = items.OrderBy(x => x.ID);
                var methodInfo = sut.GetType().GetMethod("ApplyPagingAndSorting", BindingFlags.Instance | BindingFlags.NonPublic);
                var pagingInfo = new PagingAndSortingInfo(orderByField: "ID", orderDirection: OrderDirection.Ascending);

                var res = (IQueryable<Movie>)methodInfo.Invoke(sut, new object[] { items, pagingInfo });

                res.Should().NotBeNull()
                    .And.HaveCount(items.Count())
                    .And.ContainInOrder(expectedItems);
            }

            [TestMethod]
            public void it_should_order_in_descending_mode_when_the_order_fiels_is_not_null_and_the_order_direction_is_Descending()
            {
                var sut = new QueryPageAndSortingBaseMock();
                var items = Builder<Movie>.CreateListOfSize(10).Build().AsQueryable();
                var expectedItems = items.OrderByDescending(x => x.ID);
                var methodInfo = sut.GetType().GetMethod("ApplyPagingAndSorting", BindingFlags.Instance | BindingFlags.NonPublic);
                var pagingInfo = new PagingAndSortingInfo(orderByField: "ID", orderDirection: OrderDirection.Descending);

                var res = (IQueryable<Movie>)methodInfo.Invoke(sut, new object[] { items, pagingInfo });

                res.Should().NotBeNull()
                    .And.HaveCount(items.Count())
                    .And.ContainInOrder(expectedItems);
            }

            [TestMethod]
            public void it_should_paginate_the_results()
            {
                var sut = new QueryPageAndSortingBaseMock();
                var page = 3;
                var pageSize = 4;
                var pageIndex = page - 1;
                var pagingInfo = new PagingAndSortingInfo(orderByField: "Title", orderDirection: OrderDirection.Descending, page: page, pageSize: pageSize);
                var items = Builder<Movie>.CreateListOfSize(20).Build().AsQueryable();
                var expectedItems = items.OrderByDescending(x => x.Title).Skip(pageIndex * pageSize).Take(pageSize);
                var methodInfo = sut.GetType().GetMethod("ApplyPagingAndSorting", BindingFlags.Instance | BindingFlags.NonPublic);

                var res = (IQueryable<Movie>)methodInfo.Invoke(sut, new object[] { items, pagingInfo });

                res.Should().NotBeNull()
                    .And.HaveCount(pageSize)
                    .And.ContainInOrder(expectedItems);
            }
        }
    }
}

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestQueries.Logic.Tests.Mocks;
using FluentAssertions;
using System.Linq;
using FizzWare.NBuilder;
using UnitTestQueries.Data;
using System.Reflection;

namespace UnitTestQueries.Logic.Tests
{
    [TestClass]
    public class QueryHandlerBaseTests
    {
        [TestClass]
        public class TheHandleCustomQueryMethod
        {
            [TestMethod]
            public void it_should_not_apply_paging_nor_sorting_when_the_pagingAndSortingInfo_parameter_is_null()
            {
                var sut = new QueryHandlerBaseMock();
                var items = Builder<Movie>.CreateListOfSize(20).Build().AsQueryable();
                var paging = (PagingAndSortingInfo)null;
                var methodInfo = sut.GetType().GetMethod("HandleCustomQuery", BindingFlags.NonPublic | BindingFlags.Instance);

                var res = (IQueryable<Movie>)methodInfo.Invoke(sut, new object[] { items, paging });

                res.Should().NotBeNull()
                    .And.HaveCount(items.Count())
                    .And.ContainInOrder(items);
            }

            [TestMethod]
            public void it_should_apply_paging_and_sorting_when_the_pagingAndSortingInfo_parameter_is_not_null()
            {
                var sut = new QueryHandlerBaseMock();
                var items = Builder<Movie>.CreateListOfSize(20).Build().AsQueryable();
                var paging = new PagingAndSortingInfo(orderByField: "ID");
                var pageIndex = paging.Page - 1;
                var expectedItems = items.OrderBy(x => x.ID).Skip(pageIndex * paging.PageSize).Take(paging.PageSize);
                var methodInfo = sut.GetType().GetMethod("HandleCustomQuery", BindingFlags.NonPublic | BindingFlags.Instance);

                var res = (IQueryable<Movie>)methodInfo.Invoke(sut, new object[] { items, paging });

                res.Should().NotBeNull()
                    .And.HaveCount(expectedItems.Count())
                    .And.ContainInOrder(expectedItems);
            }
        }
    }
}

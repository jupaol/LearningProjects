using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestQueries.Data;
using UnitTestQueries.Logic.Tests.Builders;
using FluentAssertions;
using System.Collections.Generic;
using System.Linq;
using System.Collections.Generic;

namespace UnitTestQueries.Logic.Tests
{
    [TestClass]
    public class MovieQueryManagerTests
    {
        [TestClass]
        public class TheFindByIDMethod
        {
            [TestMethod]
            public void it_should_return_null_if_the_item_was_not_found()
            {
                var sut = new MovieQueryManagerBuilder()
                    .SetupMoviesQueryRepositoryMockWithDefaultMovies()
                    .Build();

                var res = sut.FindByID(new MovieID(Guid.Empty));

                res.Should().BeNull();
            }

            [TestMethod]
            public void it_should_return_a_valid_instance_matching_the_specified_id_when_the_id_exists_in_the_collection()
            {
                var builder = new MovieQueryManagerBuilder()
                    .SetupMoviesQueryRepositoryMockWithDefaultMovies();
                var movies = builder.GetDefaultMovies();
                var sut = builder.Build();
                var existingID = movies.Last().ID;

                var res = sut.FindByID(new MovieID(existingID));

                res.Should().NotBeNull();
                res.ID.Should().Be(existingID);
                movies.FirstOrDefault(x => x.ID == existingID).Should().NotBeNull();
            }
        }

        [TestClass]
        public class TheFindAllMethod
        {
            [TestMethod]
            public void it_should_return_all_the_movies_without_paging_when_the_pagingAndSortingInfo_parameter_is_null()
            {
                var builder = new MovieQueryManagerBuilder()
                    .SetupMoviesQueryRepositoryMockWithDefaultMovies();
                var movies = builder.GetDefaultMovies();
                var sut = builder.Build();

                var res = sut.FindAll();

                res.Should().NotBeNull();
                res.VirtualRowsCount.Should().Be(movies.Count());
                res.Results.Should().NotBeNull().And.ContainInOrder(movies);
            }

            [TestMethod]
            public void it_should_return_all_the_movies_paging_when_the_pagingAndSortingInfo_parameter_is_not_null()
            {
                var builder = new MovieQueryManagerBuilder()
                    .SetupMoviesQueryRepositoryMockWithDefaultMovies();
                var movies = builder.GetDefaultMovies();
                var sut = builder.Build();
                var page = 3;
                var pageIndex = page - 1;
                var pageSize = 3;
                var pagingAndSortingInfo = new PagingAndSortingInfo(page: page, pageSize: pageSize, orderByField: "Title", orderDirection: OrderDirection.Descending);
                var pagedMovies = movies.OrderByDescending(x => x.Title).Skip(pageIndex * pageSize).Take(pageSize);

                var res = sut.FindAll(pagingAndSortingInfo);

                res.Should().NotBeNull();
                res.VirtualRowsCount.Should().Be(pageSize);
                res.Results.Should().NotBeNull().And.ContainInOrder(pagedMovies);

            }
        }

        [TestClass]
        public class TheHandleQueryMethod
        {
        }
    }
}

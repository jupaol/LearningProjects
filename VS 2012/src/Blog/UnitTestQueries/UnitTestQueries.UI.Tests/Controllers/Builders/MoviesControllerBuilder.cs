using FizzWare.NBuilder;
using Moq;
using MvcContrib.TestHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestQueries.Data;
using UnitTestQueries.Logic;
using UnitTestQueries.Testing;
using UnitTestQueries.UI.Controllers;

namespace UnitTestQueries.UI.Tests.Controllers.Builders
{
    public class MoviesControllerBuilder : BuilderBase<MoviesController>
    {
        private IQueryable<Movie> movies;
        private QueryResults<Movie> queryResults;

        public MoviesControllerBuilder()
        {
            this.AddMock<IMovieQueryManager>();
        }

        public override MoviesController Build()
        {
            var testControllerBuilder = new TestControllerBuilder();
            var controller = new MoviesController(
                this.GetMock<IMovieQueryManager>().Object);

            testControllerBuilder.InitializeController(controller);

            return controller;
        }

        public QueryResults<Movie> GetDefaultMovieResults()
        {
            if (this.queryResults == null)
            {
                if (this.movies == null)
                {
                    return null;
                }

                this.queryResults = QueryResults.Of(this.movies.ToList(), this.movies.Count());
            }

            return this.queryResults;
        }

        public MoviesControllerBuilder SetupMoviesQueryManagerMock(Action<Mock<IMovieQueryManager>> settingUp)
        {
            settingUp(this.GetMock<IMovieQueryManager>());

            return this;
        }

        public MoviesControllerBuilder SetupMock_MoviesQueryManager_FindByID(MovieID validID, Movie movie)
        {
            return this.SetupMoviesQueryManagerMock(mock =>
                {
                    mock.Setup(x => x.FindByID(validID)).Returns(movie);
                });
        }

        public MoviesControllerBuilder Setup_MoviesQueryManager_FindAll(PagingAndSortingInfo pagingAndSortingInfo = null)
        {
            this.movies = Builder<Movie>.CreateListOfSize(10).Build().AsQueryable();

            this.SetupMoviesQueryManagerMock(mock =>
                {
                    mock.Setup(x => x.FindAll(pagingAndSortingInfo)).Returns(this.GetDefaultMovieResults());
                });

            return this;
        }
    }
}

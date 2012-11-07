using FizzWare.NBuilder;
using Moq;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.AutoMoq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestQueries.Data;
using UnitTestQueries.Testing;

namespace UnitTestQueries.Logic.Tests.Builders
{
    public class MovieQueryManagerBuilder : BuilderBase<MovieQueryManager>
    {
        private object queryResult;
        private IQueryable<Movie> movies;

        public MovieQueryManagerBuilder()
        {
            this.AddMock<IQueryHandlerProcessor>();
            this.AddMock<IMoviesQueryRepository>();
            this.movies = Enumerable.Empty<Movie>().AsQueryable();
        }

        public MovieQueryManagerBuilder SetupQueryHandlerProcessorMockWithAnonymousQueryResult<TQuery>()
            where TQuery : IQuery
        {
            this.queryResult = this.fixture.CreateAnonymous<QueryResults<Movie>>();

            this.GetMock<IQueryHandlerProcessor>().Setup(x => x.Process<TQuery, Movie>(It.IsAny<TQuery>(), It.IsAny<PagingAndSortingInfo>()))
                .Returns(this.GetAnonymousQueryResult());
            return this;
        }

        public MovieQueryManagerBuilder SetupMoviesQueryRepositoryMock(IQueryable<Movie> movies)
        {
            this.GetMock<IMoviesQueryRepository>().Setup(x => x.GetItems()).Returns(movies);

            return this;
        }

        public MovieQueryManagerBuilder SetupMoviesQueryRepositoryMockWithDefaultMovies()
        {
            this.movies = Builder<Movie>.CreateListOfSize(10)
                .All()
                    .With(x => x.ID, Guid.NewGuid())
                .Build().AsQueryable();

            this.SetupMoviesQueryRepositoryMock(movies);

            return this;
        }

        public IQueryable<Movie> GetDefaultMovies()
        {
            return this.movies;
        }

        public QueryResults<Movie> GetAnonymousQueryResult()
        {
            var res = default(QueryResults<Movie>);

            if (this.queryResult != null)
            {
                res = (QueryResults<Movie>)this.queryResult;
            }

            return res;
        }
    }
}

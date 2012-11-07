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
    public class FindMoviesByTitleQueryHandlerBuilder : BuilderBase<FindMoviesByTitleQueryHandler>
    {
        public IQueryable<Movie> Movies { get; protected set; }
        public FindMoviesByTitleQueryHandlerBuilder SetMovies(IQueryable<Movie> movies)
        {
            this.Movies = movies;
            return this;
        }

        public override FindMoviesByTitleQueryHandler Build()
        {
            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            var moviesQueryRepositoryMock = fixture.Freeze<Mock<IMoviesQueryRepository>>();

            if (this.Movies == null)
            {
                this.Movies = Builder<Movie>.CreateListOfSize(10).Build().AsQueryable();
            }

            moviesQueryRepositoryMock.Setup(x => x.GetItems()).Returns(this.Movies);

            var sut = fixture.CreateAnonymous<FindMoviesByTitleQueryHandler>();

            return sut;
        }
    }
}

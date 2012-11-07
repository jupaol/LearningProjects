using CuttingEdge.Conditions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestQueries.Data
{
    public class MoviesQueryRepository : IMoviesQueryRepository
    {
        private MoviesContext moviesContext;

        public MoviesQueryRepository(MoviesContext moviesContext)
        {
            Condition.Requires(moviesContext).IsNotNull();

            this.moviesContext = moviesContext;
        }

        public IQueryable<Movie> GetItems()
        {
            var movies = this.moviesContext.Movies.AsQueryable();

            Condition.Ensures(movies).IsNotNull();
            return movies;
        }
    }
}

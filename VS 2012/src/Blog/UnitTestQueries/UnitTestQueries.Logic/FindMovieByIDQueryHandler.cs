using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestQueries.Data;

namespace UnitTestQueries.Logic
{
    public class FindMovieByIDQueryHandler : QueryByIDHandler<MovieID, Movie>, IFindMovieByIDQueryHandler
    {
        private IMoviesQueryRepository moviesQueryRepository;

        public FindMovieByIDQueryHandler(IMoviesQueryRepository moviesQueryRepository)
        {
            this.moviesQueryRepository = moviesQueryRepository;
        }

        protected override IQueryable<Movie> InitialItems
        {
            get { return this.moviesQueryRepository.GetItems(); }
        }

        protected override Movie FindItem(MovieID queryID, IQueryable<Movie> items)
        {
            return items.FirstOrDefault(x => x.ID.Equals(queryID.ID));
        }
    }
}

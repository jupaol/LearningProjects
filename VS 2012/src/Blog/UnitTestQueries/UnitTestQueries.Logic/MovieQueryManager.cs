using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestQueries.Data;

namespace UnitTestQueries.Logic
{
    public class MovieQueryManager : QueryManagerBase<Movie, MovieID>, IMovieQueryManager
    {
        private IMoviesQueryRepository moviesQueryRepository;

        public MovieQueryManager(
            IQueryHandlerProcessor queryHandlerProcessor,
            IMoviesQueryRepository moviesQueryRepository)
            : base(queryHandlerProcessor)
        {
            this.moviesQueryRepository = moviesQueryRepository;
        }

        protected override IQueryable<Movie> InitialItems
        {
            get { return this.moviesQueryRepository.GetItems(); }
        }

        protected override Movie FindByID(MovieID id, IQueryable<Movie> items)
        {
            return items.FirstOrDefault(x => x.ID.Equals(id.ID));
        }

        protected override IQueryable<Movie> ApplyDefaultOrder(IQueryable<Movie> items)
        {
            return items.OrderBy(x => x.Title);
        }
    }
}

using CuttingEdge.Conditions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestQueries.Data;

namespace UnitTestQueries.Logic
{
    public class FindMoviesByTitleQueryHandler : QueryHandler<FindMoviesByTitleQuery, Movie>, IFindMoviesByTitleQueryHandler
    {
        private IMoviesQueryRepository moviesQueryRepository;

        public FindMoviesByTitleQueryHandler(IMoviesQueryRepository moviesQueryRepository)
        {
            this.moviesQueryRepository = moviesQueryRepository;
        }

        protected override IQueryable<Movie> ApplyDefaultOrder(IQueryable<Movie> items)
        {
            return items.OrderBy(x => x.Title);
        }

        protected override IQueryable<Movie> InitialItems
        {
            get { return this.moviesQueryRepository.GetItems(); }
        }

        protected override IQueryable<Movie> ApplyQuery(FindMoviesByTitleQuery query, IQueryable<Movie> items)
        {
            var customQuery = items;

            if (!string.IsNullOrWhiteSpace(query.Title))
            {
                customQuery = customQuery.Where(x => x.Title.ToLower().Contains(query.Title.ToLower()));
            }

            return customQuery;
        }
    }
}

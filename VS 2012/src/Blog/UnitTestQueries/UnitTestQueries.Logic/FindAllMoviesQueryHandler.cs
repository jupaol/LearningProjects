using CuttingEdge.Conditions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestQueries.Data;

namespace UnitTestQueries.Logic
{
    public class FindAllMoviesQueryHandler : QueryHandler<Movie>, IFindAllMoviesQueryHandler
    {
        private IMoviesQueryRepository moviesQueryRepository;

        public FindAllMoviesQueryHandler(IMoviesQueryRepository moviesQueryRepository)
        {
            this.moviesQueryRepository = moviesQueryRepository;
        }

        protected override IQueryable<Movie> ApplyDefaultOrder(IQueryable<Movie> items)
        {
            return items.OrderByDescending(x => x.ID);
        }

        protected override IQueryable<Movie> InitialItems
        {
            get { return this.moviesQueryRepository.GetItems(); }
        }
    }
}

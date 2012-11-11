using FizzWare.NBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestQueries.Data;

namespace UnitTestQueries.Logic.Tests.Mocks
{
    public class QueryHandler_SpecificQuery_Mock : QueryHandler<FindMoviesByTitleQuery, Movie>
    {
        protected override IQueryable<Movie> ApplyQuery(FindMoviesByTitleQuery query, IQueryable<Movie> items)
        {
            return items.Where(x => x.Title.ToLower().Contains(query.Title.ToLower()));
        }

        protected override IQueryable<Movie> InitialItems
        {
            get
            {
                var items = Builder<Movie>.CreateListOfSize(10)
                    .TheFirst(1)
                        .With(x => x.Title, "Warcraft")
                    .TheNext(1)
                        .With(x => x.Title, "World War II")
                    .TheNext(1)
                        .With(x => x.Title, "Once Upon a Time")
                    .Build()
                    .AsQueryable();

                return items;
            }
        }

        protected override IQueryable<Movie> ApplyDefaultOrder(IQueryable<Movie> items)
        {
            return items.OrderByDescending(x => x.ID);
        }
    }
}

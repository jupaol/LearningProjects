using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestQueries.Data;
using FluentAssertions;

namespace UnitTestQueries.Logic.Tests.Mocks
{
    public class QueryPageAndSortingBaseMock : QueryPageAndSortingBase<Movie>
    {
        protected override IQueryable<Movie> ApplyDefaultOrder(IQueryable<Movie> items)
        {
            return items.OrderByDescending(x => x.Title);
        }
    }
}

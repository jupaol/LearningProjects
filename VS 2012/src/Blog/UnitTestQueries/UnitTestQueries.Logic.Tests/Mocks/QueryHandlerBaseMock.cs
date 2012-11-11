using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestQueries.Data;

namespace UnitTestQueries.Logic.Tests.Mocks
{
    public class QueryHandlerBaseMock : QueryHandlerBase<Movie>
    {
        protected override IQueryable<Movie> InitialItems
        {
            get { throw new NotImplementedException(); }
        }

        protected override IQueryable<Movie> ApplyDefaultOrder(IQueryable<Movie> items)
        {
            throw new NotImplementedException();
        }
    }
}

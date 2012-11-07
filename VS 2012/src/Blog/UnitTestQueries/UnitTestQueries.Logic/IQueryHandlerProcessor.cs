using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestQueries.Logic
{
    public interface IQueryHandlerProcessor
    {
        QueryResults<TQueryResult> Process<TQuery, TQueryResult>(TQuery query, PagingAndSortingInfo pagingandSortingInfo = null) where TQuery : IQuery;
    }
}

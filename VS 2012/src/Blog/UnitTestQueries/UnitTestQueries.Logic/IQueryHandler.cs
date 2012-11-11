using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestQueries.Logic
{
    public interface IQueryHandler<TQuery, TQueryResult> where TQuery : IQuery
    {
        QueryResults<TQueryResult> HandleQuery(TQuery query, PagingAndSortingInfo pagingAndSortingInfo = null);
    }

    public interface IQueryHandler<TQueryResult>
    {
        QueryResults<TQueryResult> HandleQuery(PagingAndSortingInfo pagingAndSortingInfo = null);
    }
}

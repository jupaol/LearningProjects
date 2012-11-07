using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestQueries.Data;

namespace UnitTestQueries.Logic
{
    public interface IQueryManager<TQueryResult, TQueryResultID> where TQueryResultID : IQueryID
    {
        TQueryResult FindByID(TQueryResultID id);

        QueryResults<TQueryResult> FindAll(PagingAndSortingInfo pagingAndSortingInfo = null);

        QueryResults<TQueryResult> HandleQuery<TQuery>(TQuery query, PagingAndSortingInfo pagingAndSortingInfo = null)
            where TQuery : IQuery;
    }
}

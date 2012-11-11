using CuttingEdge.Conditions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic;
using System.Linq.Expressions;

namespace UnitTestQueries.Logic
{
    public abstract class QueryHandlerBase<TQueryResult> : QueryPageAndSortingBase<TQueryResult>
    {
        protected abstract IQueryable<TQueryResult> InitialItems { get; }

        protected virtual IQueryable<TQueryResult> HandleCustomQuery(IQueryable<TQueryResult> items, PagingAndSortingInfo pagingAndSortingInfo = null)
        {
            Condition.Requires(items).IsNotNull();

            var customQuery = items;

            if (pagingAndSortingInfo != null)
            {
                customQuery = this.ApplyPagingAndSorting(items: customQuery, pagingAndSortingInfo: pagingAndSortingInfo);
            }

            Condition.Ensures(customQuery).IsNotNull();

            return customQuery;
        }
    }
}

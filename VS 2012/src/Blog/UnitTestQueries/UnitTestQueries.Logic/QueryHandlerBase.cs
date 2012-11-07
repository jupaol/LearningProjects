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
    public abstract class QueryHandlerBase<TQuery, TQueryResult> : 
        QueryPageAndSortingBase<TQueryResult>,
        IQueryHandler<TQuery, TQueryResult>
        where TQuery : IQuery
    {
        protected abstract IQueryable<TQueryResult> InitialItems { get; }

        public QueryResults<TQueryResult> HandleQuery(TQuery query, PagingAndSortingInfo pagingAndSortingInfo = null)
        {
            Condition.Requires(query).Evaluate(query != null);

            var customQuery = this.ApplyQuery(query, this.InitialItems);

            Condition.Ensures(customQuery).IsNotNull();

            if (pagingAndSortingInfo != null)
            {
                customQuery = this.ApplyPagingAndSorting(items: customQuery, pagingAndSortingInfo: pagingAndSortingInfo);
            }

            Condition.Ensures(customQuery).IsNotNull();

            return QueryResults.Of(customQuery.ToList(), customQuery.Count());
        }

        protected abstract IQueryable<TQueryResult> ApplyQuery(TQuery query, IQueryable<TQueryResult> items);
    }
}

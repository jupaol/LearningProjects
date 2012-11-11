using CuttingEdge.Conditions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestQueries.Logic
{
    public abstract class QueryHandler<TQuery, TQueryResult> : QueryHandlerBase<TQueryResult>,
        IQueryHandler<TQuery, TQueryResult>
        where TQuery : IQuery
    {
        public virtual QueryResults<TQueryResult> HandleQuery(TQuery query, PagingAndSortingInfo pagingAndSortingInfo = null)
        {
            Condition.Requires(query).Evaluate(query != null);
            Condition.Requires(this.InitialItems).IsNotNull();

            var queryProcessed = this.ApplyQuery(query, this.InitialItems);
            Condition.Ensures(queryProcessed).IsNotNull();

            var res = this.HandleCustomQuery(queryProcessed, pagingAndSortingInfo);
            Condition.Ensures(res).IsNotNull();

            return QueryResults.Of(res.ToList(), res.Count());
        }

        protected abstract IQueryable<TQueryResult> ApplyQuery(TQuery query, IQueryable<TQueryResult> items);
    }

    public abstract class QueryHandler<TQueryResult> : QueryHandlerBase<TQueryResult>,
        IQueryHandler<TQueryResult>
    {
        public virtual QueryResults<TQueryResult> HandleQuery(PagingAndSortingInfo pagingAndSortingInfo = null)
        {
            Condition.Requires(this.InitialItems).IsNotNull();

            var res = this.HandleCustomQuery(this.InitialItems, pagingAndSortingInfo);
            Condition.Ensures(res).IsNotNull();

            return QueryResults.Of(res.ToList(), res.Count());
        }
    }
}

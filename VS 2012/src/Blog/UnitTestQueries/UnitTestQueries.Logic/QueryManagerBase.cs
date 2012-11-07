using CuttingEdge.Conditions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestQueries.Logic
{
    public abstract class QueryManagerBase<TQueryResult, TQueryResultID> : 
        QueryPageAndSortingBase<TQueryResult>,
        IQueryManager<TQueryResult, TQueryResultID>
        where TQueryResultID : IQueryID
    {
        private IQueryHandlerProcessor queryHandlerProcessor;

        public QueryManagerBase(IQueryHandlerProcessor queryHandlerProcessor)
        {
            this.queryHandlerProcessor = queryHandlerProcessor;
        }

        protected abstract IQueryable<TQueryResult> InitialItems { get; }

        public TQueryResult FindByID(TQueryResultID id)
        {
            Condition.Requires(id).Evaluate(id != null);

            var item = this.FindByID(id, this.InitialItems);

            return item;
        }

        public QueryResults<TQueryResult> FindAll(PagingAndSortingInfo pagingAndSortingInfo = null)
        {
            var query = this.InitialItems;

            Condition.Ensures(query).IsNotNull();

            if (pagingAndSortingInfo != null)
            {
                query = this.ApplyPagingAndSorting(items: query, pagingAndSortingInfo: pagingAndSortingInfo);
            }

            Condition.Ensures(query).IsNotNull();

            return QueryResults.Of(query.ToList(), query.Count());
        }

        public QueryResults<TQueryResult> HandleQuery<TQuery>(TQuery query, PagingAndSortingInfo pagingAndSortingInfo = null) where TQuery : IQuery
        {
            Condition.Requires(query).Evaluate(query != null);

            var res = this.queryHandlerProcessor.Process<TQuery, TQueryResult>(query, pagingAndSortingInfo);
            Condition.Ensures(res).IsNotNull();

            return res;
        }

        protected abstract TQueryResult FindByID(TQueryResultID id, IQueryable<TQueryResult> items);
    }
}

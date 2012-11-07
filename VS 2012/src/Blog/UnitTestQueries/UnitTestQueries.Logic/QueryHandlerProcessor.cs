using CuttingEdge.Conditions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestQueries.Logic
{
    public class QueryHandlerProcessor : IQueryHandlerProcessor
    {
        private IQueryHandlerFactory queryHandlerFactory;

        public QueryHandlerProcessor(IQueryHandlerFactory queryHandlerFactory)
        {
            this.queryHandlerFactory = queryHandlerFactory;
        }

        public QueryResults<TQueryResult> Process<TQuery, TQueryResult>(TQuery query, PagingAndSortingInfo pagingandSortingInfo = null) where TQuery : IQuery
        {
            Condition.Requires(query).Evaluate(query != null);

            var queryHandler = this.queryHandlerFactory.Create<TQuery, TQueryResult>();
            Condition.Ensures(queryHandler).IsNotNull();

            var res = queryHandler.HandleQuery(query, pagingandSortingInfo);
            Condition.Ensures(res).IsNotNull();

            return res;
        }
    }
}

using CuttingEdge.Conditions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestQueries.Logic
{
    public sealed class QueryResults
    {
        private static object syncRoot = new Object();

        public static QueryResults<TTarget> Of<TTarget>(IList<TTarget> results, int virtualRowsCount)
        {
            Condition.Requires(results).IsNotNull();
            Condition.Requires(virtualRowsCount).IsGreaterOrEqual(0);

            var queryResults = default(QueryResults<TTarget>);

            if (queryResults == null)
            {
                lock (syncRoot)
                {
                    if (queryResults == null)
                    {
                        queryResults = new QueryResults<TTarget>(results, virtualRowsCount);
                    }
                }
            }

            return queryResults;
        }
    }

    public class QueryResults<TTarget>
    {
        public QueryResults(IList<TTarget> results, int virtualRowsCount)
        {
            Condition.Requires(results).IsNotNull();
            Condition.Requires(virtualRowsCount).IsGreaterOrEqual(0);

            this.VirtualRowsCount = virtualRowsCount;
            this.Results = results;
        }

        public int VirtualRowsCount { get; protected set; }

        public IList<TTarget> Results { get; protected set; }
    }
}

using CuttingEdge.Conditions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestQueries.Logic
{
    public abstract class QueryByIDHandler<TQueryID, TQueryResult> : IQueryByIDHandler<TQueryID, TQueryResult>
        where TQueryID : IQueryID
    {
        public virtual TQueryResult HandleQuery(TQueryID queryID)
        {
            Condition.Requires(queryID).Evaluate(queryID != null);
            Condition.Requires(this.InitialItems).IsNotNull();

            return this.FindItem(queryID, this.InitialItems);
        }

        protected abstract IQueryable<TQueryResult> InitialItems { get; }
        protected abstract TQueryResult FindItem(TQueryID queryID, IQueryable<TQueryResult> items);
    }
}

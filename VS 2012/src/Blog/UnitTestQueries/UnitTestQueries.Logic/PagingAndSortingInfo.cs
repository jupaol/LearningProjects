using CuttingEdge.Conditions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestQueries.Logic
{
    public sealed class PagingAndSortingInfo
    {
        public PagingAndSortingInfo(
            int page = 1,
            int pageSize = 10,
            string orderByField = "",
            OrderDirection orderDirection = OrderDirection.Ascending)
        {
            Condition.Requires(page).IsGreaterOrEqual(1);
            Condition.Requires(pageSize).IsGreaterOrEqual(1); ;

            this.Page = page;
            this.PageSize = pageSize;
            this.OrderByField = orderByField;
            this.OrderDirection = orderDirection;
        }

        public int Page { get; private set; }

        public int PageSize { get; private set; }

        public string OrderByField { get; private set; }

        public OrderDirection OrderDirection { get; private set; }
    }
}

using CuttingEdge.Conditions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic;

namespace UnitTestQueries.Logic
{
    public abstract  class QueryPageAndSortingBase<TQueryResult>
    {
        protected abstract IQueryable<TQueryResult> ApplyDefaultOrder(IQueryable<TQueryResult> items);

        protected virtual IQueryable<TQueryResult> ApplyPagingAndSorting(IQueryable<TQueryResult> items, PagingAndSortingInfo pagingAndSortingInfo)
        {
            Condition.Requires(pagingAndSortingInfo).IsNotNull();
            Condition.Requires(items).IsNotNull();

            var customQuery = items;
            var page = pagingAndSortingInfo.Page;
            var pageIndex = page - 1;
            var pagesize = pagingAndSortingInfo.PageSize;
            var orderDirection = pagingAndSortingInfo.OrderDirection;
            var orderField = pagingAndSortingInfo.OrderByField;

            if (!string.IsNullOrWhiteSpace(orderField))
            {
                switch (orderDirection)
                {
                    case OrderDirection.Ascending:
                        customQuery = customQuery.OrderBy(orderField);
                        break;
                    case OrderDirection.Descending:
                        customQuery = customQuery.OrderBy(string.Format("{0} descending", orderField));
                        break;
                    default:
                        throw new ArgumentOutOfRangeException("pagingAndSortingInfo", "Sorting can only be Ascending or Descending.");
                }
            }
            else
            {
                customQuery = this.ApplyDefaultOrder(customQuery);
            }

            customQuery = customQuery.Skip(pageIndex * pagesize).Take(pagesize);
            Condition.Ensures(customQuery).IsNotNull();

            return customQuery;
        }
    }
}

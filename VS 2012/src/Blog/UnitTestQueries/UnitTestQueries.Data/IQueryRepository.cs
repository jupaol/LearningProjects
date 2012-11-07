using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestQueries.Data
{
    public interface IQueryRepository<out TTarget>
    {
        IQueryable<TTarget> GetItems();
    }
}

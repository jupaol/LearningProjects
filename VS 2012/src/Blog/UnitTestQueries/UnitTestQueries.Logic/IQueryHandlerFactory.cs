using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestQueries.Logic
{
    public interface IQueryHandlerFactory
    {
        IQueryHandler<TQuery, TQueryResult> Create<TQuery, TQueryResult>() where TQuery : IQuery;
    }
}

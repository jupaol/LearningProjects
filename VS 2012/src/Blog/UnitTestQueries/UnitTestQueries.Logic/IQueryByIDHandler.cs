using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestQueries.Logic
{
    public interface IQueryByIDHandler<TQueryID, TQueryResult> where TQueryID : IQueryID
    {
        TQueryResult HandleQuery(TQueryID queryID);
    }
}

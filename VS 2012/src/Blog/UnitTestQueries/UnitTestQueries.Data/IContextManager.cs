using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestQueries.Data
{
    public interface IContextManager
    {
        TContext GetCurrentContext<TContext>() where TContext : DbContext;

        void ReleaseContext();
    }
}

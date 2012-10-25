using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Msts.Mvc.Abstract
{
    public interface IContextResolver
    {
        TContext GetCurrentContext<TContext>() where TContext : DbContext;

        void ReleaseContext();
    }
}

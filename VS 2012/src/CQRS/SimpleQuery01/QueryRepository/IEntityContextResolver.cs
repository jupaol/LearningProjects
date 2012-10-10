using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryRepository
{
    public interface IEntityContextResolver
    {
        T GetCurrentContext<T>() where T : DbContext, new();

        void ReleaseContext();
    }
}

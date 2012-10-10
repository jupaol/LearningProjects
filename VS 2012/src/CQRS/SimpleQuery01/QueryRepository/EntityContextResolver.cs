using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace QueryRepository
{
    public class EntityContextResolver : IEntityContextResolver
    {
        private HttpContextBase context;
        private const string ContextSessionKey = "EntityContextSessionKey";

        public EntityContextResolver(HttpContextBase context)
        {
            this.context = context;
        }

        public T GetCurrentContext<T>() where T : DbContext, new()
        {
            var current = this.context.Items[ContextSessionKey] as T;

            if (current == null)
            {
                current = new T();
                this.context.Items[ContextSessionKey] = context;
            }

            return current;
        }

        public void ReleaseContext()
        {
            var current = this.context.Items[ContextSessionKey] as DbContext;

            if (current != null)
            {
                current.Dispose();
            }
        }
    }
}

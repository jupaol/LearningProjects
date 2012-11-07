using CuttingEdge.Conditions;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace UnitTestQueries.Data
{
    public class ContextManager : IContextManager
    {
        private static object syncRoot = new Object();
        private string connectionString;
        private HttpContextBase httpContextBase;
        private const string ContextItemName = "EF_Context_Per_Request_Item_Name";

        public ContextManager(HttpContextBase httpContext, string connectionString = "")
        {
            Condition.Requires(httpContext).IsNotNull();

            this.connectionString = connectionString;
            this.httpContextBase = httpContext;
        }

        public TContext GetCurrentContext<TContext>() where TContext : DbContext
        {
            TContext context = default(TContext);

            lock (syncRoot)
            {
                context = this.GetContext<TContext>();
            }

            if (context == null)
            {
                lock (syncRoot)
                {
                    if (context == null)
                    {
                        context = this.CreateContext<TContext>(this.connectionString);
                    }
                }
            }

            Condition.Ensures(context).IsNotNull().IsOfType(typeof(TContext));
            return context;
        }

        public void ReleaseContext()
        {
            var context = default(DbContext);

            lock (syncRoot)
            {
                context = this.GetContext<DbContext>();
            }

            if (context != null)
            {
                context.Dispose();
            }
        }

        private TContext GetContext<TContext>() where TContext : DbContext
        {
            return this.httpContextBase.Items[ContextItemName] as TContext;
        }

        private TContext CreateContext<TContext>(string connectionString) where TContext : DbContext
        {
            var ctx = default(TContext);

            if (string.IsNullOrWhiteSpace(connectionString))
            {
                ctx = (TContext)Activator.CreateInstance(typeof(TContext));
            }
            else
            {
                ctx = (TContext)Activator.CreateInstance(typeof(TContext), connectionString);
            }

            Condition.Ensures(ctx).IsNotNull();
            this.httpContextBase.Items.Add(ContextItemName, ctx);

            return ctx;
        }
    }
}

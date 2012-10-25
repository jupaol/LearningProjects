using CuttingEdge.Conditions;
using Msts.Mvc.Abstract;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Msts.Mvc.Concrete
{
    public class ContextResolver : IContextResolver
    {
        private static object syncRoot = new Object();
        private string connectionString;
        private HttpContextBase httpContextBase;
        private const string ContextItemName = "Context_Per_Request";

        public ContextResolver(HttpContextBase httpContext, string connectionString)
        {
            Condition.Requires(httpContext).IsNotNull();
            Condition.Requires(connectionString).IsNotNullOrWhiteSpace();

            this.connectionString = connectionString;
            this.httpContextBase = httpContext;
        }

        public TContext GetCurrentContext<TContext>() where TContext : DbContext
        {
            TContext context = default(TContext);

            lock (syncRoot)
            {
                context = this.httpContextBase.Items[ContextItemName] as TContext;
            }

            if (context == null)
            {
                lock (syncRoot)
                {
                    if (context == null)
                    {
                        context = (TContext)Activator.CreateInstance(typeof(TContext), this.connectionString);
                        this.httpContextBase.Items.Add(ContextItemName, context);
                    }
                }
            }

            Condition.Ensures(context).IsNotNull().IsOfType(typeof(TContext));
            return context;
        }

        public void ReleaseContext()
        {
            DbContext context = default(DbContext);

            lock (syncRoot)
            {
                context = this.httpContextBase.Items[ContextItemName] as DbContext;
            }

            if (context != null)
            {
                context.Dispose();
            }
        }
    }
}
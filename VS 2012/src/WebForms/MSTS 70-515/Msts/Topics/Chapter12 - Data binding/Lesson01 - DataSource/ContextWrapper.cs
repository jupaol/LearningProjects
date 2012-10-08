using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Msts.Topics.Chapter12___Data_binding.Lesson01___DataSource
{
    public class ContextWrapper: IContextWrapper
    {
        private const string ContextKey = "EFContextKey";
        private HttpContextBase context;

        public ContextWrapper(HttpContextBase context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            this.context = context;
        }

        public Msts.DataAccess.EFData.PubsEntities GetEFContext()
        {
            var current = this.context.Items[ContextKey] as Msts.DataAccess.EFData.PubsEntities;

            if (current == null)
            {
                current = new DataAccess.EFData.PubsEntities();
                this.context.Items[ContextKey] = current;
            }

            return current;
        }

        public void ReleaseEFContext()
        {
            var current = this.context.Items[ContextKey] as Msts.DataAccess.EFData.PubsEntities;

            if (current != null)
            {
                current.Dispose();
            }
        }
    }
}
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Msts.Topics.Chapter12___Data_binding.Lesson01___DataSource
{
    public class ContextWrapper: IContextWrapper
    {
        private const string ContextKey = "EFContextKey";
        private HttpContextBase context;
        private ILog logger;

        public ContextWrapper(HttpContextBase context)
        {
            //var context = new HttpContextWrapper(HttpContext.Current);

            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            this.logger = LogManager.GetLogger(this.GetType());

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

            if (this.logger.IsDebugEnabled)
            {
                this.logger.Debug(MethodInfo.GetCurrentMethod().Name + " " + (current as object).GetHashCode().ToString());
            }

            return current;
        }

        public void ReleaseEFContext()
        {
            var current = this.context.Items[ContextKey] as Msts.DataAccess.EFData.PubsEntities;

            if (this.logger.IsDebugEnabled)
            {
                this.logger.Debug(MethodInfo.GetCurrentMethod().Name + " " + (current as object).GetHashCode().ToString());
            }

            if (current != null)
            {
                current.Dispose();
            }
        }
    }
}
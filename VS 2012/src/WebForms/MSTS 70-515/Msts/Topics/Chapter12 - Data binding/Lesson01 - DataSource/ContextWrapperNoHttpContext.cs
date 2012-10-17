using log4net;
using Msts.DataAccess.EFData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Msts.Topics.Chapter12___Data_binding.Lesson01___DataSource
{
    public class ContextWrapperNoHttpContext : IContextWrapper
    {
        private PubsEntities context;
        private ILog logger;

        public ContextWrapperNoHttpContext()
        {
            this.context = new PubsEntities();
            this.logger = LogManager.GetLogger(this.GetType());
        }

        public PubsEntities GetEFContext()
        {
            HttpContext.Current.Trace.Warn(MethodInfo.GetCurrentMethod().Name + " " + (this.context as object).GetHashCode().ToString());

            if (this.logger.IsDebugEnabled)
            {
                this.logger.Debug(MethodInfo.GetCurrentMethod().Name + " " + (this.context as object).GetHashCode().ToString());
            }

            return this.context;
        }

        public void ReleaseEFContext()
        {
            HttpContext.Current.Trace.Warn(MethodInfo.GetCurrentMethod().Name + " " + (this.context as object).GetHashCode().ToString());

            if (this.logger.IsDebugEnabled)
            {
                this.logger.Debug(MethodInfo.GetCurrentMethod().Name + " " + (this.context as object).GetHashCode().ToString());
            }

            this.context.Dispose();
        }
    }
}
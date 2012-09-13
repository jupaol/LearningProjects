using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Web;
using System.Web.UI;

namespace ControllingInformation
{
    public class ReplyAttackModule : IHttpModule
    {
        public void Init(HttpApplication context)
        {
            context.PreRequestHandlerExecute += context_PreRequestHandlerExecute;
        }

        private void context_PreRequestHandlerExecute(object sender, EventArgs e)
        {
            var app = sender as HttpApplication;

            if (app != null)
            {
                var ctx = app.Context;

                if (ctx != null)
                {
                    var page = ctx.Handler as Page;

                    if (page != null)
                    {
                        if (ctx.Request.AppRelativeCurrentExecutionFilePath.ToLowerInvariant().Contains("Protected".ToLowerInvariant()))
                        {
                            if (!ctx.User.Identity.IsAuthenticated)
                            {
                                throw new SecurityException("User is not authenticated");
                            }

                            page.ViewStateUserKey = ctx.User.Identity.Name;
                        }
                    }
                }
            }
        }

        public void Dispose()
        {
        }
    }
}
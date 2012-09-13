using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace Msts.Topics.Chapter02.Lesson01___MasterPages
{
    public class ChangeMasterPageModule : IHttpModule
    {
        public void Dispose()
        {
        }

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
                        if (!ctx.Request.AppRelativeCurrentExecutionFilePath.ToLowerInvariant().Contains("SettingMasterPageDynamically.aspx".ToLowerInvariant()))
                        {
                            page.PreInit += page_PreInit;
                        }
                    }
                }
            }
        }

        private void page_PreInit(object sender, EventArgs e)
        {
            var profile = CustomProfile.GetCurrentProfile();
            var page = sender as Page;

            if (page != null)
            {
                if (profile != null)
                {
                    if (!string.IsNullOrWhiteSpace(profile.MasterPage))
                    {
                        page.MasterPageFile = profile.MasterPage;
                    }

                    if (!string.IsNullOrWhiteSpace(profile.Theme))
                    {
                        page.Theme = profile.Theme;
                    }
                }

            }
        }
    }
}
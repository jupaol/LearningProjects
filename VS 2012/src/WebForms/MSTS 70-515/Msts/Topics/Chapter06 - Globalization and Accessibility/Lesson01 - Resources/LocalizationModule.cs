using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace Msts.Topics.Chapter06___Globalization_and_Accessibility.Lesson01___Globalization_and_Localization
{
    public class LocalizationModule : IHttpModule
    {
        public void Dispose()
        {
        }

        public void Init(HttpApplication context)
        {
            context.PreRequestHandlerExecute += context_PreRequestHandlerExecute;
        }

        void context_PreRequestHandlerExecute(object sender, EventArgs e)
        {
            var application = sender as HttpApplication;
            var context = application.Context;
            var handler = context.Handler;
            var profile = context.Profile as CustomProfile;

            if (handler != null)
            {
                var page = handler as Page;

                if (page != null)
                {
                    if (profile != null)
                    {
                        if (!string.IsNullOrEmpty(profile.Language))
                        {
                            page.UICulture = profile.Language;
                            page.Culture = profile.Language;
                        }
                    }
                    
                    page.PreInit += page_PreInit;
                }
            }
        }

        void page_PreInit(object sender, EventArgs e)
        {
            
        }
    }
}
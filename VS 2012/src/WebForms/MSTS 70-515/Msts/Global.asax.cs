using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace Msts
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {

        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }

        public override string GetVaryByCustomString(HttpContext context, string custom)
        {
            if (string.IsNullOrWhiteSpace(custom))
            {
                throw new ArgumentNullException("custom");
            }

            var parameters = custom.Split(';');

            foreach (var item in parameters)
            {
                switch (item)
                {
                    case "session":
                        return context.Session.SessionID;
                    default:
                        throw new ArgumentException("custom");
                }
            }

            return base.GetVaryByCustomString(context, custom);
        }
    }
}
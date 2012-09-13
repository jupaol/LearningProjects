using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace CrossSiteRequestForgery
{
    public class AntiCsrf : IHttpModule
    {
        private const string cookieName = "__CSRFCOOKIE";
        private const string hiddenField = "__CSRFTOKEN";
        private const string csrfCtx = "CSRF_Context";

        public void Dispose()
        {
        }

        public void Init(HttpApplication context)
        {
            context.PreSendRequestHeaders += context_PreSendRequestHeaders;
            context.PreRequestHandlerExecute += context_PreRequestHandlerExecute;
        }

        private void context_PreRequestHandlerExecute(object sender, EventArgs e)
        {
            var app = sender as HttpApplication;

            if (app != null)
            {
                var ctx = app.Context;

                if (ctx.Request.AppRelativeCurrentExecutionFilePath.ToLowerInvariant().Contains("MakeTransfer.aspx".ToLowerInvariant()))
                {
                    return;
                }

                if (ctx.Handler != null)
                {
                    var page = ctx.Handler as Page;

                    if (page != null)
                    {
                        page.PreRender += page_PreRender;

                        if (ctx.Request.HttpMethod.Equals("POST", StringComparison.OrdinalIgnoreCase))
                        {
                            var cookie = ctx.Request.Cookies[cookieName];
                            var hidden = ctx.Request.Form[hiddenField];
                            var cookieValue = string.Empty;

                            if (cookie != null)
                            {
                                cookieValue = cookie.Value;
                            }

                            if (string.IsNullOrWhiteSpace(cookieValue) && string.IsNullOrWhiteSpace(hidden))
                            {
                                throw new Exception("Cookie and Form field missing");
                            }

                            if (string.IsNullOrWhiteSpace(cookieValue))
                            {
                                throw new Exception("Cookie missing");
                            }

                            if (string.IsNullOrWhiteSpace(hidden))
                            {
                                throw new Exception("Form field missing");
                            }

                            var tokenField = string.Empty;
                            var osf = new ObjectStateFormatter();

                            try
                            {
                                tokenField = osf.Deserialize(hidden).ToString();
                                //tokenField = hidden;
                            }
                            catch
                            {
                                throw new Exception("Invalid form field format");
                            }

                            if (string.IsNullOrWhiteSpace(tokenField))
                            {
                                throw new Exception("Invalid token");
                            }

                            if (!tokenField.Equals(cookieValue))
                            {
                                throw new Exception("Tokens mismatch");
                            }
                        }
                    }
                }
            }
        }

        private void page_PreRender(object sender, EventArgs e)
        {
            var page = sender as Page;
            var ctx = HttpContext.Current;

            if (page != null && page.Form != null)
            {
                var csrfToken = string.Empty;

                if (
                    ctx.Request != null ||
                    ctx.Request.Cookies != null ||
                    ctx.Request.Cookies[cookieName] == null ||
                    string.IsNullOrWhiteSpace(ctx.Request.Cookies[cookieName].Value))
                {
                    csrfToken = Guid.NewGuid().ToString("D", CultureInfo.InvariantCulture);
                    ctx.Items[csrfCtx] = csrfToken;
                }
                else
                {
                    csrfToken = page.Request.Cookies[cookieName].Value;
                }

                var osf = new ObjectStateFormatter();

                page.ClientScript.RegisterHiddenField(hiddenField, osf.Serialize(csrfToken));
                //page.ClientScript.RegisterHiddenField(hiddenField, csrfToken);
            }
        }

        private void context_PreSendRequestHeaders(object sender, EventArgs e)
        {
            var app = sender as HttpApplication;
            var ctx = app.Context;

            if (app != null)
            {
                if (ctx.Request.AppRelativeCurrentExecutionFilePath.ToLowerInvariant().Contains("MakeTransfer.aspx".ToLowerInvariant()))
                {
                    return;
                }

                if (ctx.Items[csrfCtx] != null)
                {
                    var cookie = new HttpCookie(cookieName)
                    {
                        Value = ctx.Items[csrfCtx].ToString(),
                        HttpOnly = true
                    };

                    ctx.Response.Cookies.Add(cookie);
                }
            }
        }
    }
}
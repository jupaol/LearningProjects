using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Msts.Topics.Chapter03.Lesson01
{
    public class RequestLifeCycle : IHttpModule
    {
        public void Dispose()
        {
        }

        public void Init(HttpApplication context)
        {
            context.BeginRequest += context_BeginRequest;
            context.AuthenticateRequest += context_AuthenticateRequest;
            context.PostAuthenticateRequest += context_PostAuthenticateRequest;
            context.AuthorizeRequest += context_AuthorizeRequest;
            context.PostAuthorizeRequest += context_PostAuthorizeRequest;
            context.ResolveRequestCache += context_ResolveRequestCache;
            context.PostResolveRequestCache += context_PostResolveRequestCache;
            context.MapRequestHandler += context_MapRequestHandler;
            context.PostMapRequestHandler += context_PostMapRequestHandler;
            context.AcquireRequestState += context_AcquireRequestState;
            context.PostAcquireRequestState += context_PostAcquireRequestState;
            context.PreRequestHandlerExecute += context_PreRequestHandlerExecute;
            // page life cycle
            context.PostRequestHandlerExecute += context_PostRequestHandlerExecute;
            context.ReleaseRequestState += context_ReleaseRequestState;
            context.PostReleaseRequestState += context_PostReleaseRequestState;
            context.UpdateRequestCache += context_UpdateRequestCache;
            context.PostUpdateRequestCache += context_PostUpdateRequestCache;
            context.LogRequest += context_LogRequest;
            context.PostLogRequest += context_PostLogRequest;
            context.EndRequest += context_EndRequest;
            context.PreSendRequestContent += context_PreSendRequestContent;
            context.PreSendRequestHeaders += context_PreSendRequestHeaders;
            context.RequestCompleted += context_RequestCompleted;
        }

        void context_UpdateRequestCache(object sender, EventArgs e)
        {
            HttpContext.Current.Trace.Warn("Request", MethodInfo.GetCurrentMethod().Name);
        }

        void context_ResolveRequestCache(object sender, EventArgs e)
        {
            HttpContext.Current.Trace.Warn("Request", MethodInfo.GetCurrentMethod().Name);
        }

        void context_RequestCompleted(object sender, EventArgs e)
        {
            //HttpContext.Current.Trace.Warn("Request", MethodInfo.GetCurrentMethod().Name);
        }

        void context_ReleaseRequestState(object sender, EventArgs e)
        {
            HttpContext.Current.Trace.Warn("Request", MethodInfo.GetCurrentMethod().Name);
        }

        void context_PreSendRequestHeaders(object sender, EventArgs e)
        {
            HttpContext.Current.Trace.Warn("Request", MethodInfo.GetCurrentMethod().Name);
        }

        void context_PreSendRequestContent(object sender, EventArgs e)
        {
            HttpContext.Current.Trace.Warn("Request", MethodInfo.GetCurrentMethod().Name);
        }

        void context_PreRequestHandlerExecute(object sender, EventArgs e)
        {
            HttpContext.Current.Trace.Warn("Request", MethodInfo.GetCurrentMethod().Name);
        }

        void context_PostUpdateRequestCache(object sender, EventArgs e)
        {
            HttpContext.Current.Trace.Warn("Request", MethodInfo.GetCurrentMethod().Name);
        }

        void context_PostResolveRequestCache(object sender, EventArgs e)
        {
            HttpContext.Current.Trace.Warn("Request", MethodInfo.GetCurrentMethod().Name);
        }

        void context_PostRequestHandlerExecute(object sender, EventArgs e)
        {
            HttpContext.Current.Trace.Warn("Request", MethodInfo.GetCurrentMethod().Name);
        }

        void context_PostReleaseRequestState(object sender, EventArgs e)
        {
            HttpContext.Current.Trace.Warn("Request", MethodInfo.GetCurrentMethod().Name);
        }

        void context_PostMapRequestHandler(object sender, EventArgs e)
        {
            HttpContext.Current.Trace.Warn("Request", MethodInfo.GetCurrentMethod().Name);
        }

        void context_PostLogRequest(object sender, EventArgs e)
        {
            HttpContext.Current.Trace.Warn("Request", MethodInfo.GetCurrentMethod().Name);
        }

        void context_PostAuthorizeRequest(object sender, EventArgs e)
        {
            HttpContext.Current.Trace.Warn("Request", MethodInfo.GetCurrentMethod().Name);
        }

        void context_PostAuthenticateRequest(object sender, EventArgs e)
        {
            HttpContext.Current.Trace.Warn("Request", MethodInfo.GetCurrentMethod().Name);
        }

        void context_PostAcquireRequestState(object sender, EventArgs e)
        {
            HttpContext.Current.Trace.Warn("Request", MethodInfo.GetCurrentMethod().Name);
        }

        void context_MapRequestHandler(object sender, EventArgs e)
        {
            HttpContext.Current.Trace.Warn("Request", MethodInfo.GetCurrentMethod().Name);
        }

        void context_LogRequest(object sender, EventArgs e)
        {
            HttpContext.Current.Trace.Warn("Request", MethodInfo.GetCurrentMethod().Name);
        }

        void context_EndRequest(object sender, EventArgs e)
        {
            HttpContext.Current.Trace.Warn("Request", MethodInfo.GetCurrentMethod().Name);
        }

        void context_BeginRequest(object sender, EventArgs e)
        {
            HttpContext.Current.Trace.Warn("Request", MethodInfo.GetCurrentMethod().Name);
        }

        void context_AuthorizeRequest(object sender, EventArgs e)
        {
            HttpContext.Current.Trace.Warn("Request", MethodInfo.GetCurrentMethod().Name);
        }

        void context_AuthenticateRequest(object sender, EventArgs e)
        {
            HttpContext.Current.Trace.Warn("Request", MethodInfo.GetCurrentMethod().Name);
        }

        void context_AcquireRequestState(object sender, EventArgs e)
        {
            HttpContext.Current.Trace.Warn("Request", MethodInfo.GetCurrentMethod().Name);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Runtime.Remoting.Messaging;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace Msts.Topics.Chapter10___Services_and_Handlers.Lesson01___Handlers
{
    public class RetrievingImageAsyncHandler : IHttpAsyncHandler
    {
        public IAsyncResult BeginProcessRequest(HttpContext context, AsyncCallback cb, object extraData)
        {
            var apm = new ProcessResult(cb, context, extraData);

            context.Response.Write(string.Format("<h1>This handler uses a simple custom implementation of the IAsyncResult interface (Async Programming Model)</h1><br/><br/><hr/><br/><br/>"));

            context.Response.Write(string.Format("<br/>Before calling start asynchronously: {0} ThreadPool ID: {1}", DateTime.Now.ToString(), Thread.CurrentThread.ManagedThreadId));
            apm.Start();
            context.Response.Write(string.Format("<br/>After calling start asynchronously: {0} ThreadPool ID: {1}", DateTime.Now.ToString(), Thread.CurrentThread.ManagedThreadId));

            return apm;
        }

        public void EndProcessRequest(IAsyncResult result)
        {
            var res = result as ProcessResult;
            var resData = res.Result;

            res.Context.Response.Write(string.Format("<br/>Asynchronous operation ended at: '{0}' with data from the async operation: {1} ThreadPool ID: {2}", DateTime.Now.ToString(), resData.ToString(), Thread.CurrentThread.ManagedThreadId));
        }

        public bool IsReusable
        {
            get { return false; }
        }

        public void ProcessRequest(HttpContext context)
        {
            throw new InvalidOperationException();
        }
    }
}
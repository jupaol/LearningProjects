using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Threading;
using System.Web;

namespace Msts.Topics.Chapter10___Services_and_Handlers.Lesson01___Handlers
{
    /// <summary>
    /// Summary description for AsyncHandlerCallingAsyncMethodsAsynchronously
    /// </summary>
    public class AsyncHandlerCallingAsyncMethodsAsynchronously : IHttpAsyncHandler
    {
        private DateTime LongTimeConsumingOperation(TimeSpan slidingTime)
        {
            this.Context.Response.Write(string.Format("<br/>Before long operation asynchronously: {0} Async Thread ID: {1}", DateTime.Now.ToString(), Thread.CurrentThread.ManagedThreadId));
            Thread.Sleep(5000);
            this.Context.Response.Write(string.Format("<br/>After long operation asynchronously: {0} Aync Thread ID: {1}", DateTime.Now.ToString(), Thread.CurrentThread.ManagedThreadId));

            return DateTime.Now.Add(slidingTime);
        }

        public IAsyncResult BeginProcessRequest(HttpContext context, AsyncCallback cb, object extraData)
        {
            Func<TimeSpan, DateTime> myLongOperation = this.LongTimeConsumingOperation;

            context.Response.Write(string.Format("<h1>This handler calls a sync method asynchronously (Async Programming Model)</h1><br/><br/><hr/><br/><br/>"));

            context.Response.Write(string.Format("<br/>Before calling BeginInvoke asynchronously: {0} ThreadPool ID: {1}", DateTime.Now.ToString(), Thread.CurrentThread.ManagedThreadId));
            var res = myLongOperation.BeginInvoke(TimeSpan.FromDays(2), cb, extraData);
            context.Response.Write(string.Format("<br/>After calling BeginInvoke asynchronously: {0} ThreadPool ID: {1}", DateTime.Now.ToString(), Thread.CurrentThread.ManagedThreadId));

            this.Context = context;
            return res;
        }

        public void EndProcessRequest(IAsyncResult result)
        {
            var asyncRes = result as AsyncResult;
            var caller = asyncRes.AsyncDelegate as Func<TimeSpan, DateTime>;
            var res = caller.EndInvoke(result);

            this.Context.Response.Write(string.Format("<br/>Asynchronous operation ended at: '{0}' with data from the async operation: {1} ThreadPool ID: {2}", DateTime.Now.ToString(), res, Thread.CurrentThread.ManagedThreadId));
        }

        public bool IsReusable
        {
            get { return false; }
        }

        public void ProcessRequest(HttpContext context)
        {
            throw new InvalidOperationException();
        }

        public HttpContext Context { get; set; }
    }
}
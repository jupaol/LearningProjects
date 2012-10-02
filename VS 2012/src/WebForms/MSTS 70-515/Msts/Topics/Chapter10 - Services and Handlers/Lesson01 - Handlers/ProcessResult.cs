using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;

namespace Msts.Topics.Chapter10___Services_and_Handlers.Lesson01___Handlers
{
    public class ProcessResult : IAsyncResult
    {
        public ProcessResult(AsyncCallback callback, HttpContext context, object state)
        {
            this.IsCompleted = false;
            this.CompletedSynchronously = false;
            this.AsyncWaitHandle = null;
            this.AsyncState = state;

            this.Callback = callback;
            this.Context = context;
        }

        public object AsyncState { get; protected set; }
        public WaitHandle AsyncWaitHandle { get; protected set; }
        public bool CompletedSynchronously { get; protected set; }
        public bool IsCompleted { get; protected set; }

        public AsyncCallback Callback { get; set; }
        public HttpContext Context { get; set; }
        public DateTime Result { get; set; }

        public void Start()
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(StartAsyncOperation), this.AsyncState);
        }

        private void StartAsyncOperation(object state)
        {
            this.Context.Response.Write(string.Format("<br/>Before long operation asynchronously: {0} Async Thread ID: {1}", DateTime.Now.ToString(), Thread.CurrentThread.ManagedThreadId));
            this.Result = DateTime.Now;
            Thread.Sleep(3000);
            this.Context.Response.Write(string.Format("<br/>After long operation asynchronously: {0} Aync Thread ID: {1}", DateTime.Now.ToString(), Thread.CurrentThread.ManagedThreadId));
            this.IsCompleted = true;
            this.Callback(this);
        }
    }
}
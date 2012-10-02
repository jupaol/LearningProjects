using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Msts.Topics.Chapter10___Services_and_Handlers.Lesson01___Handlers
{
    public partial class AsyncPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpContext.Current.Response.Write(string.Format("<br /> Thread ID: {0} From: {1}", Thread.CurrentThread.ManagedThreadId, MethodInfo.GetCurrentMethod().Name));
        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            HttpContext.Current.Response.Write(string.Format("<br /> Thread ID: {0} From: {1}", Thread.CurrentThread.ManagedThreadId, MethodInfo.GetCurrentMethod().Name));
            this.AddOnPreRenderCompleteAsync(
                new BeginEventHandler(this.BeginProcessRequest),
                new EndEventHandler(this.EndProcessRequest));
        }

        public DateTime ExecuteLongTimeConsumingOperation(TimeSpan time)
        {
            HttpContext.Current.Response.Write(string.Format("<br /> Thread ID: {0} From: {1}", Thread.CurrentThread.ManagedThreadId, MethodInfo.GetCurrentMethod().Name));
            Thread.Sleep(5000);

            return DateTime.Now.Subtract(time);
        }

        public IAsyncResult BeginProcessRequest(object sender, EventArgs e, AsyncCallback cb, object extraData)
        {
            HttpContext.Current.Response.Write(string.Format("<br /> Thread ID: {0} From: {1}", Thread.CurrentThread.ManagedThreadId, MethodInfo.GetCurrentMethod().Name));
            //Func<TimeSpan, DateTime> operation = this.ExecuteLongTimeConsumingOperation;

            //return operation.BeginInvoke(TimeSpan.FromDays(10), cb, extraData);

            var f = new ProcessResult(cb, this.Context, extraData);

            f.Start();

            return f;
        }

        public void EndProcessRequest(IAsyncResult result)
        {
            HttpContext.Current.Response.Write(string.Format("<br /> Thread ID: {0} From: {1}", Thread.CurrentThread.ManagedThreadId, MethodInfo.GetCurrentMethod().Name));
            //var asyncResult = result as AsyncResult;
            //var handler = (Func<TimeSpan, DateTime>)asyncResult.AsyncDelegate;
            //var res = handler.EndInvoke(result);

            //this.msg.Text = res.ToString();

            var f = result as ProcessResult;

            this.msg.Text = f.Result.ToString();
        }
    }
}
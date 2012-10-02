using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Msts.Topics.Chapter10___Services_and_Handlers.Lesson02___XML_Services
{
    public partial class ConsumingXmlWebServiceAsXmlWebService : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            this.Trace.Warn("postback event called");
            HttpContext.Current.Response.Write(string.Format("<br />Thread ID: {0} From: {1}", Thread.CurrentThread.ManagedThreadId, MethodInfo.GetCurrentMethod().Name));

            using (var s = new HelloWorldXmlService.HelloWorldService())
            {
                s.HelloWorldCompleted += (x, y) =>
                    {
                        HttpContext.Current.Response.Write(string.Format("<br />Thread ID: {0} From: {1}", Thread.CurrentThread.ManagedThreadId, MethodInfo.GetCurrentMethod().Name));
                        this.msg.Text = y.Result;
                    };
                s.HelloWorldAsync(this.name.Text);
            }
        }
    }
}
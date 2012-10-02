using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Msts.Topics.Chapter10___Services_and_Handlers.Lesson02___XML_Services
{
    public partial class ConsumingPageMethodsUsingScriptManager : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            var sm = ScriptManager.GetCurrent(this);

            sm.EnablePageMethods = true;
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = false)]
        public static string HelloWorld(DateTime dateTime)
        {
            return string.Format("Hello World: {0} at: {1}", HttpContext.Current.Request.PhysicalApplicationPath, dateTime);
        }
    }
}
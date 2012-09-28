using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Msts.Topics.Chapter09___Scripts.Lesson02___Client_MS_AJAX
{
    public partial class CustomCallbackEvent : System.Web.UI.Page, ICallbackEventHandler
    {
        public string Result { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            var callback = this.ClientScript.GetCallbackEventReference(
                this,
                "argskkk",
                "clientCallback",
                null);
            var wrapper = "function callServer(args){ var argskkk = args + ' plop'; " + callback + "; }";

            this.ClientScript.RegisterClientScriptBlock(
                this.GetType(),
                "callServer",
                wrapper,
                true);
        }

        public string GetCallbackResult()
        {
            return this.Result;
        }

        public void RaiseCallbackEvent(string eventArgument)
        {
            this.Result = string.Format("Args: {0} Res: {1}", eventArgument, DateTime.Now.ToString());
        }
    }
}
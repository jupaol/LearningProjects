using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Msts.Topics.Chapter08___Debugging_and_Deploying.Lesson01___Debugging
{
    public partial class DefaultErrorPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var lastError = Server.GetLastError();

            if (lastError != null)
            {
                this.errorPanel.Visible = true;
                this.errorMessage.Text = lastError.Message;
                this.errorTrace.Text = lastError.StackTrace;
            }
            else
            {
                this.errorPanel.Visible = false;
            }
        }
    }
}
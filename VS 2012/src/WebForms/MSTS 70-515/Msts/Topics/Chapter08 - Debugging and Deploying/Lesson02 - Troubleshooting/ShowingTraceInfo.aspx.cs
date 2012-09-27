using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Msts.Topics.Chapter08___Debugging_and_Deploying.Lesson02___Troubleshooting
{
    public partial class ShowingTraceInfo : System.Web.UI.Page
    {
        protected void Page_PreLoad(object sender, EventArgs e)
        {
            this.Trace.Warn("Tracing pre-load method");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.Trace.Warn("Tracing load method");
        }
    }
}
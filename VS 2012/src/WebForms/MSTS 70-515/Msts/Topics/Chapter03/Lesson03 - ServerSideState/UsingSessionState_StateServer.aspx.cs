using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Msts.Topics.Chapter03.Lesson03___ServerSideState
{
    public partial class UsingSessionState_StateServer : System.Web.UI.Page
    {
        protected void Page_PreRender(object sender, EventArgs e)
        {
            this.msg.Text = this.Session["cs"] != null ? this.Session["cs"].ToString() : string.Empty;
        }

        protected void updateSessionState_Click(object sender, EventArgs e)
        {
            this.Session["cs"] = DateTime.Now;
        }
    }
}
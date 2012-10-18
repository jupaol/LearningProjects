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

            var sessionObject = this.Session["cso"] as SessionObject;

            if (sessionObject != null)
            {
                var lastLogin = sessionObject.LastLogin.HasValue ? sessionObject.LastLogin.Value.ToString() : string.Empty;

                this.msg.Text += "<br />" + lastLogin + "<br />" + sessionObject.User;
            }
        }

        protected void updateSessionState_Click(object sender, EventArgs e)
        {
            this.Session["cs"] = DateTime.Now;
            this.Session["cso"] = new SessionObject { LastLogin = DateTime.Now, User = this.User.Identity.Name };
        }
    }
}
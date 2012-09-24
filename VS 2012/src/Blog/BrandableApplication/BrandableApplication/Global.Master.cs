using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BrandableApplication
{
    public partial class Global : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void layouts_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Response.Redirect(this.Request.RawUrl);
        }

        protected void colors_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Response.Redirect(this.Request.RawUrl);
        }

        protected void languages_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Response.Redirect(this.Request.RawUrl);
        }
    }
}
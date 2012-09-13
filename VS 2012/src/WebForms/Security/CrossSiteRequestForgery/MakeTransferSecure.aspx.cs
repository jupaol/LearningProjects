using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CrossSiteRequestForgery
{
    public partial class MakeTransferSecure : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["d"] == null)
            {
                Session["d"] = 1500;
            }

            this.msg.Text = Session["d"].ToString();
        }

        protected void make_transfer_Click(object sender, EventArgs e)
        {
            Session["d"] = decimal.Parse(Session["d"].ToString()) - decimal.Parse(this.ammount.Text);

            this.msg.Text = Session["d"].ToString();
        }
    }
}
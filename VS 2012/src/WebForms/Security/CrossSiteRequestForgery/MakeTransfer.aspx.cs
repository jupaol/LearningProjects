using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CrossSiteRequestForgery
{
    public partial class MakeTransfer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["c"] == null)
            {
                Session["c"] = 1500;
            }

            this.msg.Text = Session["c"].ToString();
        }

        protected void make_transfer_Click(object sender, EventArgs e)
        {
            Session["c"] = decimal.Parse(Session["c"].ToString()) - decimal.Parse(this.ammount.Text);

            this.msg.Text = Session["c"].ToString();
        }
    }
}
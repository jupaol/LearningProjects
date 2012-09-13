using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ControllingInformation
{
    public partial class ReplyAttack : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["d"] == null)
            {
                this.Session["d"] = DateTime.Now;
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ControllingInformation
{
    public partial class SessionPageState : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            this.Response.Cache.SetCacheability(HttpCacheability.NoCache);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!this.IsPostBack)
            {
                this.bl.DataSource = this.Session.Keys.OfType<string>().Select(x => string.Format("{0} = {1}", x, this.Session[x]));
                this.bl.DataBind();
            }
        }

        protected override PageStatePersister PageStatePersister
        {
            get
            {
                return new SessionPageStatePersister(this);
            }
        }
    }
}
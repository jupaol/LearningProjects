using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GetAndPostRequests
{
    public partial class TestingPostMethod : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.getParams.DataSource = 
                this.Request.QueryString.Keys.OfType<string>().Select(x => string.Format("{0} = {1}", x, this.Request.QueryString[x]));
            this.getParams.DataBind();

            this.postParams.DataSource =
                this.Request.Form.Keys.OfType<string>().Select(x => string.Format("{0} = {1}", x, this.Request.Form[x]));
            this.postParams.DataBind();

            this.headerParams.DataSource =
                this.Request.Headers.Keys.OfType<string>().Select(x => string.Format("{0} = {1}", x, this.Request.Headers[x]));
            this.headerParams.DataBind();

            this.reqParams.DataSource = new[]
                {
                    string.Format("Using Request.QueryString['txt']: {0}", this.Request.QueryString["txt"]),
                    string.Format("Using Request.Form['txt']: {0}", this.Request.Form["txt"]),
                    string.Format("Using Request['txt']: {0}", this.Request["txt"])
                };
            this.reqParams.DataBind();
        }
    }
}
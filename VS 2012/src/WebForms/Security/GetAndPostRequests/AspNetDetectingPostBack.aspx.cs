using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GetAndPostRequests
{
    public partial class AspNetDetectingPostBack : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.postParams.DataSource = this.Request.Form.Keys.OfType<string>().Select(x => string.Format("{0} = {1}", x, this.Request.Form[x]));
            this.postParams.DataBind();
        }

        protected void btn_Click(object sender, EventArgs e)
        {
            this.msg.Text = MethodInfo.GetCurrentMethod().Name + " called";
        }
    }
}
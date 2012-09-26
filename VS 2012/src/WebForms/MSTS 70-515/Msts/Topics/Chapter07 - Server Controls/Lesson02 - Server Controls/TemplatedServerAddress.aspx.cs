using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Msts.Topics.Chapter07___Server_Controls.Lesson02___Server_Controls
{
    public partial class TemplatedServerAddress : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.addressControl1.Address = "Super Toronot";
            this.DataBind();
        }
    }
}
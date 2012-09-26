using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Msts.Topics.Chapter07___Server_Controls.Lesson01___User_Controls
{
    public partial class TemplatedAddress1 : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.templatedAddress1.Address = "Toronto";
            this.templatedAddress1.DataBind();
        }
    }
}
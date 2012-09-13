using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ControllingInformation
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void login_Click(object sender, EventArgs e)
        {
            var res = this.userName.Text.Equals("admin", StringComparison.OrdinalIgnoreCase) &&
                this.password.Text.Equals("secret", StringComparison.OrdinalIgnoreCase);

            if (res)
            {
                FormsAuthentication.RedirectFromLoginPage(this.userName.Text, false);
            }
        }
    }
}
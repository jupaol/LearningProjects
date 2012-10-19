using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Msts
{
    public partial class CreateAccount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void createUser_SendingMail(object sender, MailMessageEventArgs e)
        {
            var message = e.Message.Body.Replace("{{ pwd }}", this.createUser.Password);

            e.Message.Body = message;
        }
    }
}
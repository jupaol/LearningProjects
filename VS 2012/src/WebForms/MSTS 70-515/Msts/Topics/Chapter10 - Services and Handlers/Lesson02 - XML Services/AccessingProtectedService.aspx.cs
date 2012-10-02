using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Msts.Topics.Chapter10___Services_and_Handlers.Lesson02___XML_Services
{
    public partial class AccessingProtectedService : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            var nt = new NetworkCredential { UserName = "jupaol", Password = "password!" };
            var ntc = new CredentialCache();

            ntc.Add(
                new Uri("http://localhost:49354/Topics/Chapter10%20-%20Services%20and%20Handlers/Lesson02%20-%20XML%20Services/ProtectedWebService.asmx"),
                "Basic",
                nt);

            using (var s = new ProtectedXmlWebService.ProtectedWebService { Credentials = ntc, CookieContainer = new CookieContainer() })
            {
                this.res.Text = s.HelloWorld();
            }
        }
    }
}
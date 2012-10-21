using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Msts.Topics.Chapter13___Profiles_and_security.Lesson02___Membership
{
    public partial class TestingTheFormsAuthenticationObject : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void login_Click(object sender, EventArgs e)
        {
            Thread.Sleep(4000);

            var res = FormsAuthentication.Authenticate(this.username.Text, this.password.Text);

            if (res)
            {
                this.msg.Text = "Authenticated";
            }
            else
            {
                this.msg.Text = "Non authenticated";
                return;
            }

            if (this.useRedirectFromLoginPage.Checked)
            {
                FormsAuthentication.RedirectFromLoginPage(this.username.Text, this.remmeberMe.Checked);
            }

            var redirectUrl = FormsAuthentication.GetRedirectUrl(this.username.Text, this.remmeberMe.Checked);
            var hashedPassword = FormsAuthentication.HashPasswordForStoringInConfigFile(this.password.Text, "MD5");
            var ticket = new FormsAuthenticationTicket(this.username.Text, this.remmeberMe.Checked, 30);
            var encryptedCookie = FormsAuthentication.Encrypt(ticket);
            var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedCookie);

            if (this.manualAuthentication.Checked)
            {
                this.Response.Cookies.Add(cookie);
                this.Response.Redirect(this.Request.RawUrl);
            }
            else
            {
                this.redirectUrl.Value = string.Format("Redirect URL: {0} HashedPassword: {1} Encrypted Cookie: {2}",
                    redirectUrl, hashedPassword, encryptedCookie);
            }
        }

        protected void logout_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();

            this.Response.Redirect(this.Request.RawUrl);
        }
    }
}
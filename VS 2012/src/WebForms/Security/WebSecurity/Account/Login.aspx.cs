using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebSecurity.Account
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterHyperLink.NavigateUrl = "Register.aspx";
            this.forgotPasswordHyperLink.NavigateUrl = "ForgotPassword.aspx";
            OpenAuthLogin.ReturnUrl = Request.QueryString["ReturnUrl"];

            var returnUrl = HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
            if (!String.IsNullOrEmpty(returnUrl))
            {
                RegisterHyperLink.NavigateUrl += "?ReturnUrl=" + returnUrl;
            }
        }

        protected void Unnamed1_LoggingIn(object sender, LoginCancelEventArgs e)
        {
            var chk = (CheckBox)this.login.FindControl("useFragilAuthentication");

            if (!chk.Checked)
            {
                return;
            }

            var cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            var cmd = cnn.CreateCommand();
            var query = "select m.* from Memberships as m inner join users as u on m.userid = u.userid where u.username = '{0}' and m.password = '{1}'";

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = string.Format(query, this.login.UserName, this.login.Password);

            using (var cnn1 = cnn)
            {
                cnn1.Open();

                var res = cmd.ExecuteReader();

                if (res.Read())
                {
                    FormsAuthentication.RedirectFromLoginPage(this.login.UserName, this.login.RememberMeSet);
                }
                else
                {
                    e.Cancel = true;
                    // throw new ValidationException("The credentials are not valid");
                }
            }
        }
    }
}
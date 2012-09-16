using Microsoft.Security.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Msts.Topics.Chapter03.Lesson02___ClientSideState
{
    public partial class AddingPersistentCookies : System.Web.UI.Page
    {
        public bool CookieSet { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.CookieSet = false;
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            var cookie = (this.CookieSet) ? this.Response.Cookies["customSettingsCookie"] : this.Request.Cookies["customSettingsCookie"];

            if (cookie != null)
            {
                if (!string.IsNullOrWhiteSpace(cookie.Value))
                {
                    this.colors.SelectedValue = cookie.Value;
                }
                else
                {
                    this.colors.SelectedValue = "-1";
                }

                var js = new JavaScriptSerializer();

                this.msg.Text = js.Serialize(cookie);

                if (!this.CookieSet)
                {
                    this.ChangeBackgroundColor(cookie.Value, cookie.Expires);
                }
            }
        }

        protected void saveSettings_Click(object sender, EventArgs e)
        {
            var preferedColor = this.colors.SelectedValue;

            switch (preferedColor.ToLowerInvariant())
            {
                case "blue":
                case "red":
                    break;
                case "-1":
                    preferedColor = string.Empty;
                    break;
                default:
                    throw new SecurityException("Attempt to tamper the page");
            }

            var cookie = new HttpCookie("customSettingsCookie", preferedColor)
            { 
                HttpOnly = false
            };

            if (this.rememberMe.Checked)
            {
                cookie.Expires = DateTime.Now.AddDays(7);
            }

            this.Response.Cookies.Add(cookie);
            this.CookieSet = true;
            this.ChangeBackgroundColor(Encoder.HtmlEncode(cookie.Value), cookie.Expires);
        }

        protected void deleteSettings_Click(object sender, EventArgs e)
        {

        }

        private void ChangeBackgroundColor(string color, DateTime expires)
        {
            this.myContainer.Style.Add(HtmlTextWriterStyle.BackgroundColor, Server.HtmlEncode(color));
            this.expiresDate.Text = expires.ToString();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ValidatingInput
{
    public partial class XssVulnerablePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Response.Cookies["auth"].Value = "secret";

            if (!this.IsPostBack && !string.IsNullOrWhiteSpace(this.Request.HttpMethod) && this.Request.HttpMethod.ToUpper() == "GET")
            {
                this.txt.Text = @"
<script type=""text/javascript"">alert(document.cookie);</script>
<b>this should be displayed</b>
<i>this is itallic</i>
<img width=""100"" height=""100"" title=""puhhho"" src=""javascript:alert('surprise');"" />
";
            }
        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            this.msg.Text = this.txt.Text;
        }

        protected void withEncoding_Click(object sender, EventArgs e)
        {
            this.msg.Text = HttpUtility.HtmlEncode(this.txt.Text);
        }

        protected void withSpecialEncoding_Click(object sender, EventArgs e)
        {
            var sb = new StringBuilder(HttpUtility.HtmlEncode(this.txt.Text));
            var lt = HttpUtility.HtmlEncode("<");
            var rt = HttpUtility.HtmlEncode(">");

            sb.Replace(lt + "b" + rt, "<b>");
            sb.Replace(lt + "/b" + rt, "</b>");
            sb.Replace(lt + "i" + rt, "<i>");
            sb.Replace(lt + "/i" +  rt, "</i>");

            this.msg.Text = sb.ToString();
        }
    }
}
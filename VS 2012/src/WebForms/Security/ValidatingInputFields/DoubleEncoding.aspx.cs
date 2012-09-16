using Microsoft.Security.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ValidatingInputFields
{
    public partial class DoubleEncoding : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Unnamed_Load(object sender, EventArgs e)
        {
            this.msg.Text = this.txt.Text;

            this.msg2.Text = Server.HtmlEncode(this.txt.Text);
            this.msg3.Text = Server.HtmlEncode(Server.HtmlEncode(this.txt.Text));
            this.msg4.Text = Server.HtmlEncode(Server.HtmlEncode(Server.HtmlEncode(this.txt.Text)));

            this.msg5.Text = Encoder.HtmlEncode(this.txt.Text);
            this.msg6.Text = Encoder.HtmlEncode(Encoder.HtmlEncode(this.txt.Text));
            this.msg7.Text = Encoder.HtmlEncode(Encoder.HtmlEncode(Encoder.HtmlEncode(this.txt.Text)));
        }
    }
}
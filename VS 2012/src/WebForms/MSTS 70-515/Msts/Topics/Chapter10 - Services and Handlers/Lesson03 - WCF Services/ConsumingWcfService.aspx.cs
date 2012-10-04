using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Msts.Topics.Chapter10___Services_and_Handlers.Lesson03___WCF_Services
{
    public partial class ConsumingWcfService : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void sendRequest_Click(object sender, EventArgs e)
        {
            Thread.Sleep(2000);

            using (var s = new HelloWorldWcfServiceReference.HelloWorldWcfServiceClient())
            {
                var res = string.Empty;

                res = s.HelloWorldBare(this.name.Text, DateTime.Parse(this.birthdayDate.Text));
                this.msg.Text += res + "<br />";

                res = s.HelloWorldWr(this.name.Text, DateTime.Parse(this.birthdayDate.Text));
                this.msg.Text += res + "<br />";

                res = s.HelloWorldResponseWrapped(this.name.Text, DateTime.Parse(this.birthdayDate.Text));
                this.msg.Text += res + "<br />";

                res = s.HelloWorldRequestWrapped(this.name.Text, DateTime.Parse(this.birthdayDate.Text));
                this.msg.Text += res + "<br />";
            }
        }
    }
}
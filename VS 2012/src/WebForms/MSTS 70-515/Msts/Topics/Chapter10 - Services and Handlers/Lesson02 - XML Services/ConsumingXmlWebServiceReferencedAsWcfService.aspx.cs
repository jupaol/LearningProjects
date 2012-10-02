using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Msts.Topics.Chapter10___Services_and_Handlers.Lesson02___XML_Services
{
    public partial class ConsumingXmlWebServiceReferencedAsWcfService : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            using (var s = new HelloWorldWvfService.HelloWorldServiceSoapClient())
            {
                var t = s.HelloWorldAsync(this.name.Text);

                t.ContinueWith(x => this.msg.Text = x.Result);
            }
        }
    }
}
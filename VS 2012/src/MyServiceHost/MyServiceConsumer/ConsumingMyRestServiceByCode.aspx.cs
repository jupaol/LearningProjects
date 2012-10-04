using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyServiceConsumer
{
    public partial class ConsumingMyRestServiceByCode : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            using (var s = new MyServiceConsumer.ServiceReference1.MyServiceClient())
            {
                var res = s.Execute();

                this.msg.Text = string.Format("Message: {0}, Ticks: {1}, Process date: {2}",
                    res.Message,
                    res.ServerTicks,
                    res.ProcessDate);
            }
        }
    }
}
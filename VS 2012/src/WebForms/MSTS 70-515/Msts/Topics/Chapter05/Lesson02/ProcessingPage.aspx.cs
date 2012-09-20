using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Msts.Topics.Chapter05.Lesson02
{
    public partial class ProcessingPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.PreviousPage != null)
            {
                this.Trace.Warn("previous page is not null");

                this.msg.Text = this.PreviousPage.MyText;
                this.txt.Text = this.PreviousPage.MyText;
            }
        }
    }
}
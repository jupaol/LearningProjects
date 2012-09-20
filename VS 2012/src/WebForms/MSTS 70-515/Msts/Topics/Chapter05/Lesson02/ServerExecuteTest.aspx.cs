using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Msts.Topics.Chapter05.Lesson02
{
    public partial class ServerExecuteTest : BasePreviousPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            Trace.Warn("before calling execute");

            Server.Execute("ProcessingPage.aspx");

            Trace.Warn("after processing page");

            // Since execution return to the calling page (here) if we uncomment the following
            // exception will be thrown
            //throw new InvalidOperationException();
        }

        protected override TextBox MyTextBox
        {
            get
            {
                return this.mytext;
            }
        }
    }
}
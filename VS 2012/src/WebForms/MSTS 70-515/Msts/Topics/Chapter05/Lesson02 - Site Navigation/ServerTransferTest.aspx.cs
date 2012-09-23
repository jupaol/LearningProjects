using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Msts.Topics.Chapter05.Lesson02
{
    public partial class ServerTransferTest : BasePreviousPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            Server.Transfer("ProcessingPage.aspx");
            throw new InvalidOperationException();
        }

        protected override TextBox MyTextBox
        {
            get
            {
                return this.txt;
            }
        }
    }
}
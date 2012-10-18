using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Msts.Topics.Chapter05.Lesson01___Input_Validation
{
    public partial class SimpleValidation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Unnamed_Load(object sender, EventArgs e)
        {
            this.msg.Text = DateTime.Now.ToString();
        }

        protected void Unnamed_Tick(object sender, EventArgs e)
        {
            this.msg.Text = DateTime.Now.ToString();
        }
    }
}
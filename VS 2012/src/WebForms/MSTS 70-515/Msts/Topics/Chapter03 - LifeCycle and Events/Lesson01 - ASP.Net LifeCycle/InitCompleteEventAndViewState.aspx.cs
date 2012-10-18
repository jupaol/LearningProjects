using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Msts.Topics.Chapter03.Lesson01
{
    public partial class InitCompleteEventAndViewState : System.Web.UI.Page
    {
        protected void Page_InitComplete(object sender, EventArgs e)
        {
            this.txt.Text = MethodInfo.GetCurrentMethod().Name;
        }

        protected void Page_PreLoad(object sender, EventArgs e)
        {
            this.txt2.Text = MethodInfo.GetCurrentMethod().Name;
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}
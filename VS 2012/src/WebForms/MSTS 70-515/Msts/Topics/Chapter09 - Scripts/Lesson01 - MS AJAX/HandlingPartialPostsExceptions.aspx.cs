using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Msts.Topics.Chapter09___Scripts.Lesson01___MS_AJAX
{
    public partial class HandlingPartialPostsExceptions : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var sm = ScriptManager.GetCurrent(this);


            sm.AsyncPostBackError += sm_AsyncPostBackError;
        }

        private void sm_AsyncPostBackError(object sender, AsyncPostBackErrorEventArgs e)
        {
            var sm = sender as ScriptManager;

            this.msg.Text = string.Format("An error has occurred: {0}<br />{1}", e.Exception.Message, e.Exception.StackTrace);
            sm.AsyncPostBackErrorMessage = this.msg.Text;
        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            this.msg.Text = "Before exception";
            throw new NotImplementedException();
        }
    }
}
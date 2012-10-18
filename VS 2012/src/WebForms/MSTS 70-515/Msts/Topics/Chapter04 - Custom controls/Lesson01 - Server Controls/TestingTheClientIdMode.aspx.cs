using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Msts.Topics.Chapter04.Lesson01___Server_Controls
{
    public partial class TestingTheClientIdMode : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void gv_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var label = e.Row.FindControl("bAutoID") as Label;
                var literal = e.Row.FindControl("bAutoIDMsg") as Literal;
                literal.Text = label.ClientID;

                label = e.Row.FindControl("bInherit") as Label;
                literal = e.Row.FindControl("bInheritMsg") as Literal;
                literal.Text = label.ClientID;

                label = e.Row.FindControl("bPredicatble") as Label;
                literal = e.Row.FindControl("bPredicatbleMsg") as Literal;
                literal.Text = label.ClientID;

                label = e.Row.FindControl("bStatic") as Label;
                literal = e.Row.FindControl("bStaticMsg") as Literal;
                literal.Text = label.ClientID;
            }
        }
    }
}
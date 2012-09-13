using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EventValidation
{
    public partial class ValidationDisabled : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void delete_Click(object sender, EventArgs e)
        {
            this.msg.Text = "Delete";
        }

        protected void insert_Click(object sender, EventArgs e)
        {
            this.msg.Text = "Insert";
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ValidatingInput
{
    public partial class TestingTheIsValidProperty : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.IsPostBack)
            {
                // the following code generates an exception
                //if (!this.IsValid)
                //{
                //    return;
                //}
            }
        }

        protected void btn_Click(object sender, EventArgs e)
        {
            if (!this.IsValid)
            {
                return;
            }
        }

        protected void gender_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.IsValid)
            {
                return;
            }
        }
    }
}
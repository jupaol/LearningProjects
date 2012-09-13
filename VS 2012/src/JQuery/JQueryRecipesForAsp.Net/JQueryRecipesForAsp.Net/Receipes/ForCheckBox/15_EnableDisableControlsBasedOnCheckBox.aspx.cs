using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JQueryRecipesForAsp.Net.Receipes.ForCheckBox
{
    public partial class _15_EnableDisableControlsBasedOnCheckBox : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.btn.Enabled = this.chk.Checked;
        }
    }
}
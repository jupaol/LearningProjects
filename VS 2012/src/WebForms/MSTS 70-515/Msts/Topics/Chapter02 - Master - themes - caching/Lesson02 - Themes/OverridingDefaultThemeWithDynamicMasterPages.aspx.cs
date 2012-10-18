using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Msts.Topics.Chapter02.Lesson01___MasterPages
{
    public partial class OverridingDefaultThemeWithDynamicMasterPages : Page
    {
        protected void Page_PreInit(object sender, EventArgs e)
        {
            this.Theme = "Green";
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}
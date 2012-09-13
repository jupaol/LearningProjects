using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Msts.Topics.Chapter02.Lesson01___MasterPages
{
    public partial class ClassicMaster : BaseMasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected override DropDownList AvailableLayouts
        {
            get { return null; }
        }

        public override string CurrentTitle
        {
            get
            {
                return "Classic master page";
            }
        }
    }
}
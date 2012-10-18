using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Msts.Topics.Chapter02.Lesson01___MasterPages
{
    public partial class ModernMaster : BaseMasterPage
    {
        protected override DropDownList AvailableLayouts
        {
            get { return null; }
        }

        public override string CurrentTitle
        {
            get
            {
                return "Modern master page";
            }
        }
    }
}
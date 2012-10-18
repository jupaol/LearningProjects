using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Msts.Topics.Chapter02.Lesson01___MasterPages
{
    public partial class LocalMaster : BaseMasterPage
    {
        protected override DropDownList AvailableLayouts
        {
            get
            {
                return this.ddlLayouts;
            }
        }

        protected override DropDownList AvailableThemes
        {
            get
            {
                return this.ddlThemes;
            }
        }

        public override string CurrentTitle
        {
            get
            {
                return "Local master page";
            }
        }

        protected override DropDownList AvailableLanguages
        {
            get
            {
                return this.ddlCultures;
            }
        }
    }
}
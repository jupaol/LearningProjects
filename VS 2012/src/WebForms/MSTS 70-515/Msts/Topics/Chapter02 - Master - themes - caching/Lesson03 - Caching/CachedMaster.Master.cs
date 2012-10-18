using Msts.Topics.Chapter02.Lesson01___MasterPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Msts.Topics.Chapter02.Lesson03
{
    public partial class CachedMaster : BaseMasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Response.Cache.VaryByParams[this.ddlLayouts.UniqueID] = true;
            this.Response.Cache.VaryByParams[this.ddlThemes.UniqueID] = true;
        }

        protected override DropDownList AvailableLayouts
        {
            get
            {
                return null;
            }
        }

        protected override DropDownList AvailableThemes
        {
            get
            {
                return null;
            }
        }
    }
}
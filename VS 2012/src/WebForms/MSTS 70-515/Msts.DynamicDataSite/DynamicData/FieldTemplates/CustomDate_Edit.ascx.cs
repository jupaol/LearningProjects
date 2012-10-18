using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using System.Web.DynamicData;

namespace Msts.DynamicDataSite.DynamicData.FieldTemplates
{
    public partial class CustomDate_EditField : System.Web.DynamicData.FieldTemplateUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Calendar1.ToolTip = Column.Description;
        }

        protected override void ExtractValues(IOrderedDictionary dictionary)
        {
            dictionary[Column.Name] = this.Calendar1.SelectedDate;
        }

        protected override void OnDataBinding(EventArgs e)
        {
            base.OnDataBinding(e);

            this.Calendar1.SelectedDate = Convert.ToDateTime(this.FieldValue).Date;
        }

        public override Control DataControl
        {
            get
            {
                return this.Calendar1;
            }
        }
    }
}

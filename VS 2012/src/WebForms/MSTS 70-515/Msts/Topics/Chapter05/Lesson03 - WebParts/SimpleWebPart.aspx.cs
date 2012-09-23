using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace Msts.Topics.Chapter05.Lesson03___WebParts
{
    public partial class SimpleWebPart : System.Web.UI.Page
    {
        private WebPartManager currentWebPartManager;

        protected void Page_PreLoad(object sender, EventArgs e)
        {
            this.currentWebPartManager = WebPartManager.GetCurrentWebPartManager(this);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.dynamicWebPartZonesMode.DataSource = this.currentWebPartManager.SupportedDisplayModes.OfType<WebPartDisplayMode>();
                this.dynamicWebPartZonesMode.DataMember = "Name";
                this.dynamicWebPartZonesMode.DataBind();
            }
        }

        protected void webPartZonesMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.currentWebPartManager.DisplayMode = this.currentWebPartManager.SupportedDisplayModes[this.webPartZonesMode.SelectedValue];
        }
    }
}
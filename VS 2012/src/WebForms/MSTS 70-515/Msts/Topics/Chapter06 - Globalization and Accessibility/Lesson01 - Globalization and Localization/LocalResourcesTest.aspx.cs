using Msts.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Msts.Topics.Chapter06___Globalization_and_Accessibility.Lesson01___Globalization_and_Localization
{
    public partial class LocalResourcesTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //var rm = new ResourceManager("Msts.Domain.GlobalResources", typeof(SomeClass).Assembly);

            this.satelliteAssemblyMessage.Text = GlobalResources.Welcome_Message + " " + GlobalResources.GoodBye_Message;
            //this.satelliteAssemblyResourceManagerMessage.Text = rm.GetString("Welcome_Message");

            this.DataBind();
        }
    }
}
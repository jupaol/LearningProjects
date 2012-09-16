using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Msts.Topics.Chapter02.Lesson03
{
    public partial class SettingOutputCacheViaCode : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Response.Cache.SetCacheability(HttpCacheability.ServerAndNoCache);
            this.Response.Cache.SetExpires(DateTime.Now.AddSeconds(30));
            this.Response.Cache.SetValidUntilExpires(true);
            this.Response.Cache.VaryByParams[this.ddl1.UniqueID] = true;
            this.Response.Cache.VaryByParams[this.ddl2.UniqueID] = true;

            this.msg.Text = DateTime.Now.ToString();
        }

        public static string MySubstitution(HttpContext context)
        {
            return DateTime.Now.ToString();
        }
    }
}
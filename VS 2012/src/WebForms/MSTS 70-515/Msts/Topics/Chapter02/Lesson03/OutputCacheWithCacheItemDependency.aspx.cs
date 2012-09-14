using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Msts.Topics.Chapter02.Lesson03
{
    public partial class OutputCacheWithCacheItemDependency : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.msg.Text = DateTime.Now.ToString();

            this.Cache.Insert("slidingCacheItem", DateTime.Now, null, Cache.NoAbsoluteExpiration, new TimeSpan(0, 0, 10));

            this.Response.AddCacheItemDependency("slidingCacheItem");
        }

        public static string CustomSubstitution(HttpContext context)
        {
            return DateTime.Now.ToString();
        }
    }
}
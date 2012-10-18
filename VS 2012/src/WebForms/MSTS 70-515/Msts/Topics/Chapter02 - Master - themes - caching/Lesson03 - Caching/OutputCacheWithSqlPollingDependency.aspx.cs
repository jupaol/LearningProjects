using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Msts.Topics.Chapter02.Lesson03
{
    public partial class OutputCacheWithSqlPollingDependency : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.msg.Text = DateTime.Now.ToString();

            var scd = new SqlCacheDependency("PUBS", "jobs");

            this.Response.AddCacheDependency(scd);
        }

        public static string CustomSubstitution(HttpContext context)
        {
            return DateTime.Now.ToString();
        }
    }
}
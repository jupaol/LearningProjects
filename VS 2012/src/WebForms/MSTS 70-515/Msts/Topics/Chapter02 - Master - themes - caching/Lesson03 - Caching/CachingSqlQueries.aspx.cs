using Msts.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Msts.Topics.Chapter02.Lesson03
{
    public partial class CachingSqlQueries : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.gv.DataSource = this.GetJobs();
            this.gv.DataBind();
        }

        private IEnumerable<jobs> GetJobs()
        {
            var cachedJobs = this.Cache["jobs"] as IEnumerable<jobs>;

            if (cachedJobs == null)
            {
                var ctx = new PubsDataContext();
                var jobsList = ctx.jobs.ToList();
                var scd = new SqlCacheDependency("PUBS", "jobs");

                this.Cache.Insert("jobs", jobsList, scd, Cache.NoAbsoluteExpiration, Cache.NoSlidingExpiration, CacheItemPriority.High, null);

                cachedJobs = jobsList;

                this.Trace.Warn("Loaded from the Database");
            }
            else
            {
                this.Trace.Warn("Loaded from the cache");
            }

            return cachedJobs;
        }
    }
}
using Msts.DataAccess.EFData;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Msts.Topics.Chapter12___Data_binding.Lesson02___DataBound
{
    public partial class WorkingWithTheChartControl : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void eds_ContextCreating(object sender, EntityDataSourceContextCreatingEventArgs e)
        {
            e.Context = ((IObjectContextAdapter)new PubsEntities()).ObjectContext;
        }

        protected void eds_QueryCreated(object sender, QueryCreatedEventArgs e)
        {
            //e.Query = e.Query.OfType<job>().GroupBy(x => x.job_desc, x => x, (x, y) => new
            //{
            //    job_desc = x,
            //    count = y.Count()
            //});
        }
    }
}
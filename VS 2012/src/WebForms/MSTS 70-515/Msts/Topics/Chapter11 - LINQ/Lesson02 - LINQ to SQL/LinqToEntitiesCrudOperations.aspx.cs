using Msts.DataAccess.EFData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Msts.Topics.Chapter11___LINQ.Lesson02___LINQ_to_SQL
{
    public partial class LinqToEntitiesCrudOperations : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void cancelSelection_Click(object sender, EventArgs e)
        {
            this.gv.SelectedIndex = -1;
            this.gv.DataBind();
        }

        protected void addNew_Click(object sender, EventArgs e)
        {
            var j = new job
            {
                job_desc = this.description.Text,
                max_lvl = Convert.ToByte(this.maximum.Text),
                min_lvl = Convert.ToByte(this.minimum.Text)
            };

            var ctx = new PubsEntities();

            ctx.jobs.Add(j);

            ctx.SaveChanges();

            this.status.Text = "Job added";
            this.gv.DataBind();
        }
    }
}
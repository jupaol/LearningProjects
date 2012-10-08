using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Msts.Topics.Chapter11___LINQ.Lesson02___LINQ_to_SQL
{
    public partial class LinqToSqlManualMappingsTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.BindGridView();
            }
        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<Msts.Topics.Chapter11___LINQ.Lesson02___LINQ_to_SQL.JobEnityManual> gv_GetData()
        {
            var ctx = new PubsManualContext();

            return from j in ctx.Jobs
                   //where j.Description.Contains("a")
                   select j;
        }

        private void BindGridView()
        {
            this.gv.DataSource = this.gv_GetData();
            this.gv.DataBind();
        }

        protected void save_Click(object sender, EventArgs e)
        {
            var j = new JobEnityManual
            {
                Description = this.description.Text,
                Maximum = Convert.ToByte(this.maximum.Text),
                Minimum = Convert.ToByte(this.minimum.Text)
            };

            var ctx = new PubsManualContext();

            ctx.Jobs.InsertOnSubmit(j);

            ctx.SubmitChanges();

            this.msg.Text = "Data inserted";
            this.BindGridView();
        }

        protected void gv_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            var jobId = (Int16)e.Keys["ID"];

            var ctx = new PubsManualContext();

            if (jobId % 2 == 0)
            {
                var job = ctx.Jobs.First(x => x.ID == jobId);

                if (e.NewValues["Description"] != null)
                {
                    job.Description = (string)e.NewValues["Description"];
                }
                if (e.NewValues["Maximum"] != null)
                {
                    job.Maximum = Convert.ToByte(e.NewValues["Maximum"]);
                }
                if (e.NewValues["Minimum"] != null)
                {
                    job.Minimum = Convert.ToByte(e.NewValues["Minimum"]);
                }

                ctx.SubmitChanges();
            }
            else
            {
                var f = new JobEnityManual
                {
                    ID = jobId,
                    Description = (e.NewValues["Description"] ?? e.OldValues["Description"]).ToString(),
                    Maximum = Convert.ToByte(e.NewValues["Maximum"] ?? e.OldValues["Maximum"]),
                    Minimum = Convert.ToByte(e.NewValues["Minimum"] ?? e.OldValues["Minimum"])
                };

                ctx.Jobs.Attach(f);
                ctx.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, f);
                ctx.SubmitChanges();
            }

            this.gv.EditIndex = -1;
            this.BindGridView();
        }

        protected void gv_RowEditing(object sender, GridViewEditEventArgs e)
        {
            this.gv.EditIndex = e.NewEditIndex;
            this.BindGridView();
        }

        protected void gv_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            this.gv.EditIndex = -1;
            this.BindGridView();
        }

        protected void gv_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            var jobID = (Int16)e.Keys["ID"];

            var ctx = new PubsManualContext();

            ctx.Jobs.DeleteOnSubmit(ctx.Jobs.First(x => x.ID == jobID));

            ctx.SubmitChanges();

            this.BindGridView();
        }

        protected void gv_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            this.gv.SelectedIndex = e.NewSelectedIndex;
            this.BindGridView();
        }
    }
}
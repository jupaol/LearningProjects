using Msts.DataAccess.EFData;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Linq.Dynamic;

namespace Msts.Topics.Chapter12___Data_binding.Lesson02___DataBound
{
    public partial class WorkingWithTheGridViewControl : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void eds_ContextCreating(object sender, EntityDataSourceContextCreatingEventArgs e)
        {
            e.Context = ((IObjectContextAdapter)new PubsEntities()).ObjectContext;
        }

        protected void myCustomGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (this.myCustomGridView.EditIndex != -1)
                {
                    var cbl = e.Row.FindControl("employeesList") as CheckBoxList;

                    if (cbl != null)
                    {
                        var jobID = (Int16)this.myCustomGridView.DataKeys[e.Row.RowIndex].Value;

                        var job = new PubsEntities().jobs.Include("employees").FirstOrDefault(x => x.job_id == jobID);

                        if (job != null)
                        {
                            var currentJobEmployees = job.employees;

                            foreach (var item in cbl.Items.OfType<ListItem>())
                            {
                                item.Selected = currentJobEmployees.Any(x => x.emp_id == item.Value);
                            }
                        }
                    }
                }
            }
        }

        protected void myCustomGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            var row = this.myCustomGridView.Rows[e.RowIndex];
            var cbl = row.FindControl("employeesList") as CheckBoxList;
            var employees = cbl.Items.OfType<ListItem>().Where(x => x.Selected);
            var ctx = new PubsEntities();
            var jobID = (Int16)e.Keys[0];

            foreach (var item in employees)
            {
                var employee = ctx.employees.First(x => x.emp_id.Equals(item.Value));

                if (!employee.job_id.Equals(jobID))
                {
                    employee.job_id = jobID;
                }
            }

            ctx.ChangeTracker.DetectChanges();
            ctx.SaveChanges();
        }
    }
}
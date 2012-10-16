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
    public partial class WorkingWithTheFormViewControl : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void eds_ContextCreating(object sender, EntityDataSourceContextCreatingEventArgs e)
        {
            e.Context = ((IObjectContextAdapter)new PubsEntities()).ObjectContext;
        }

        protected void employeesList_DataBound(object sender, EventArgs e)
        {
            var ctx = new PubsEntities();
            var employeesCheckBoxListControl = sender as CheckBoxList;
            var jobID = Convert.ToInt16(this.fv.DataKey["job_id"]);
            var currentJob = ctx.jobs.Include("employees").First(x => x.job_id == jobID);

            foreach (var item in employeesCheckBoxListControl.Items.OfType<ListItem>())
            {
                item.Selected = currentJob.employees.Any(x => x.emp_id == item.Value);
            }
        }

        protected void fv_ItemUpdating(object sender, FormViewUpdateEventArgs e)
        {
            if (this.fv.CurrentMode == FormViewMode.Edit)
            {
                var employeesListControl = this.fv.FindControl("employeesList") as CheckBoxList;

                if (employeesListControl != null)
                {
                    var ctx = new PubsEntities();
                    var jobID = Convert.ToInt16(this.fv.DataKey["job_id"]);
                    var currentJob = ctx.jobs.First(x => x.job_id == jobID);

                    foreach (var item in employeesListControl.Items.OfType<ListItem>())
                    {
                        var employee = ctx.employees.First(x => x.emp_id == item.Value);

                        if (item.Selected)
                        {
                            employee.job_id = jobID;
                        }
                    }

                    ctx.SaveChanges();
                }
            }
        }

        protected void new_Click(object sender, EventArgs e)
        {
            this.fv.ChangeMode(FormViewMode.Insert);
        }
    }
}
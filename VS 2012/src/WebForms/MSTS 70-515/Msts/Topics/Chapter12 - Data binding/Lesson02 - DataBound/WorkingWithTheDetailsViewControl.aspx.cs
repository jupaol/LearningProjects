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
    public partial class WorkingWithTheDetailsViewControl : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void eds_ContextCreating(object sender, EntityDataSourceContextCreatingEventArgs e)
        {
            e.Context = ((IObjectContextAdapter)new PubsEntities()).ObjectContext;
        }

        protected void dv_DataBound(object sender, EventArgs e)
        {
            if (this.dv.CurrentMode == DetailsViewMode.Edit)
            {
                var employeesListControl = this.dv.FindControl("employeesList") as ListBox;

                if (employeesListControl != null)
                {
                    var ctx = new PubsEntities();
                    var jobID = Convert.ToInt16(this.dv.DataKey[0]);
                    var currentJob = ctx.jobs.Include("employees").FirstOrDefault(x => x.job_id == jobID);

                    if (currentJob != null)
                    {
                        foreach (var item in employeesListControl.Items.OfType<ListItem>())
                        {
                            item.Selected = currentJob.employees.Any(x => x.emp_id == item.Value);
                        }
                    }
                }
            }
        }

        protected void dv_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
        {
            if (this.dv.CurrentMode == DetailsViewMode.Edit)
            {
                var employeesListControl = this.dv.FindControl("employeesList") as ListBox;

                if (employeesListControl != null)
                {
                    var ctx = new PubsEntities();
                    var jobID = Convert.ToInt16(this.dv.DataKey[0]);
                    var currentJob = ctx.jobs.Include("employees").FirstOrDefault(x => x.job_id == jobID);

                    if (currentJob != null)
                    {
                        foreach (var item in employeesListControl.Items.OfType<ListItem>())
                        {
                            var emp = ctx.employees.First(x => x.emp_id == item.Value);

                            if (item.Selected)
                            {
                                emp.job_id = jobID;
                            }
                            else
                            {
                                if (emp.job_id == jobID)
                                {
                                    // here i would normally remove it
                                }
                            }
                        }

                        ctx.SaveChanges();
                    }
                }
            }
        }
    }
}
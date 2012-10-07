using Msts.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Reflection;

namespace Msts.Topics.Chapter11___LINQ.Lesson02___LINQ_to_SQL
{
    public partial class CreatingDataSets : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                var pubs = new DataSet("pubs");

                var jobs = new DataTable("jobs");
                var jobId = new DataColumn("job_id", typeof(Int16));
                var jobDescription = new DataColumn("job_desc", typeof(string));

                var employees = new DataTable("employees");
                var empId = new DataColumn("emp_id", typeof(string));
                var fname = new DataColumn("fname", typeof(string));
                var lname = new DataColumn("lname", typeof(string));
                var empJobId = new DataColumn("job_id", typeof(Int16));

                jobs.Columns.Add(jobId);
                jobs.Columns.Add(jobDescription);
                jobs.PrimaryKey = new[] { jobId };

                employees.Columns.Add(empId);
                employees.Columns.Add(fname);
                employees.Columns.Add(lname);
                employees.Columns.Add(empJobId);
                employees.PrimaryKey = new[] { empId };

                pubs.Tables.AddRange(new[] { jobs, employees });

                var rel = new DataRelation("job_employee", jobId, empJobId);

                pubs.Relations.Add(rel);

                using (var ctx = new PubsDataContext())
                {
                    foreach (var item in ctx.jobs)
                    {
                        var jobRow = jobs.NewRow();

                        jobRow["job_id"] = item.job_id;
                        jobRow["job_desc"] = item.job_desc;

                        jobs.Rows.Add(jobRow);
                    }

                    foreach (var item in ctx.employee)
                    {
                        employees.Rows.Add(item.emp_id, item.fname, item.lname, item.job_id);
                    }
                }

                this.gv.DataSource = pubs;
                this.gv.DataBind();
            }
        }
    }
}
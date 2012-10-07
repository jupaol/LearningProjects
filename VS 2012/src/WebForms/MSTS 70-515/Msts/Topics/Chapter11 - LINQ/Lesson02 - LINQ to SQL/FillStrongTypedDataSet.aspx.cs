using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Msts.Topics.Chapter11___LINQ.Lesson02___LINQ_to_SQL
{
    public partial class FillStrongTypedDataSet : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.gv.DataSource = this.gv_GetData().CopyToDataTable().DefaultView;
                this.gv.DataBind();
            }
        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<Msts.Topics.Chapter11___LINQ.Lesson02___LINQ_to_SQL.JobsDataSet.jobsRow> gv_GetData()
        {
            // from here we bind the second gridview with a tyoped dataset

            var ds = new JobsDataSet();
            var cs = ConfigurationManager.ConnectionStrings["Msts"].ConnectionString;
            var conn = new SqlConnection(cs);
            var cmd = new SqlCommand("select * from jobs", conn) { CommandType = CommandType.Text };
            var sa = new SqlDataAdapter(cmd);
            var scb = new SqlCommandBuilder(sa);

            sa.Fill(ds, ds.jobs.TableName);

            var cmd2 = new SqlCommand("select * from employee", conn) { CommandType = CommandType.Text };
            var sa2 = new SqlDataAdapter(cmd2);
            var scb2 = new SqlCommandBuilder(sa2);

            sa2.Fill(ds, ds.employee.TableName);

            var data = from j in ds.jobs
                       join em in ds.employee
                       on j.job_id equals em.job_id
                       orderby j.job_desc, em.fname, em.lname
                       select j;

            this.msg.Text = data.Count().ToString();

            return data.AsQueryable();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Msts.Topics.Chapter11___LINQ.Lesson02___LINQ_to_SQL
{
    public partial class FillingADataSetUsingSqlAdapter : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.BindGrid();
            }
        }

        protected void gvpicker_RowEditing(object sender, GridViewEditEventArgs e)
        {
            this.gvpicker.EditIndex = e.NewEditIndex;
            this.BindGrid();
        }

        private void BindGrid()
        {
            var ds = new DataSet();
            var cs = ConfigurationManager.ConnectionStrings["Msts"].ConnectionString;
            var cnn = new SqlConnection(cs);
            var cmd = new SqlCommand("select * from jobs", cnn) { CommandType = CommandType.Text };
            var sa = new SqlDataAdapter(cmd) { UpdateBatchSize = 3 };
            var scb = new SqlCommandBuilder(sa);

            sa.RowUpdated += (x, y) =>
            {
                this.msg.Text += "<br />Rows updated: " + y.RecordsAffected.ToString();
            };

            sa.Fill(ds, "jobs");

            this.gvpicker.DataSource = (from DataRow j in ds.Tables["jobs"].Rows
                                        where j.Field<string>("job_desc").Contains("a")
                                        select j).CopyToDataTable().DefaultView;
            this.gvpicker.DataBind();

            foreach (DataRow item in ds.Tables["jobs"].Rows)
            {
                item["job_desc"] = item["job_desc"].ToString() + "plop";
            }

            sa.Update(ds, "jobs");

            foreach (DataRow item in ds.Tables["jobs"].Rows)
            {
                item["job_desc"] = item["job_desc"].ToString().Replace("plop", string.Empty);
            }

            sa.Update(ds, "jobs");
        }
    }
}
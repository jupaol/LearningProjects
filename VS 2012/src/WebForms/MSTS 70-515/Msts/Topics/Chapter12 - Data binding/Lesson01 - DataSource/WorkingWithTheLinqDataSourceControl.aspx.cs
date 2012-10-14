using Msts.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Msts.Topics.Chapter12___Data_binding.Lesson01___DataSource
{
    public partial class WorkingWithTheLinqDataSourceControl : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lds_ContextCreating(object sender, LinqDataSourceContextEventArgs e)
        {
            e.ObjectInstance = new PubsDataContext();
        }

        protected void resetFilter_Click(object sender, EventArgs e)
        {
            this.gv.SelectedIndex = -1;
            this.gv.EditIndex = -1;

            this.descriptionFilter.Text = string.Empty;
            this.minimumFilter.SelectedIndex = 0;
            this.maximumFilter.SelectedIndex = this.maximumFilter.Items.Count - 1;

            this.gv.DataBind();
        }

        protected void applyFilter_Click(object sender, EventArgs e)
        {
            this.gv.DataBind();
        }

        protected void lds_QueryCreated(object sender, QueryCreatedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(this.descriptionFilter.Text))
            {
                e.Query = e.Query.OfType<jobs>().Where(x => x.job_desc.Contains(this.descriptionFilter.Text));
            }
        }

        protected void lds2_Deleted(object sender, LinqDataSourceStatusEventArgs e)
        {
            this.gv.SelectedIndex = -1;
            this.gv.EditIndex = -1;

            this.gv.DataBind();
        }

        protected void lds2_Inserted(object sender, LinqDataSourceStatusEventArgs e)
        {
            this.gv.SelectedIndex = -1;
            this.gv.EditIndex = -1;

            this.gv.DataBind();
        }

        protected void lds2_Updated(object sender, LinqDataSourceStatusEventArgs e)
        {
            this.gv.SelectedIndex = -1;
            this.gv.EditIndex = -1;

            this.gv.DataBind();
        }
    }
}
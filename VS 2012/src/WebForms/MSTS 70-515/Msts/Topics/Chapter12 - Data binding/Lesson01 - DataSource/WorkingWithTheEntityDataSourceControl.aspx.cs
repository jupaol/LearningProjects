using Msts.DataAccess.EFData;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Msts.Topics.Chapter12___Data_binding.Lesson01___DataSource
{
    public partial class WorkingWithTheEntityDataSourceControl : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void resetFilter_Click(object sender, EventArgs e)
        {
            this.gv.SelectedIndex = -1;

            this.descriptionFilter.Text = string.Empty;
            this.minimumFilter.SelectedIndex = 0;
            this.maximumFilter.SelectedIndex = this.maximumFilter.Items.Count - 1;

            this.gv.DataBind();
        }

        protected void applyFilter_Click(object sender, EventArgs e)
        {
            this.gv.DataBind();
        }

        protected void eds_QueryCreated(object sender, QueryCreatedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(this.descriptionFilter.Text))
            {
                e.Query = e.Query.OfType<job>().Where(x => x.job_desc.Contains(this.descriptionFilter.Text));
            }
        }

        protected void dv_ItemInserted(object sender, DetailsViewInsertedEventArgs e)
        {
            this.gv.SelectedIndex = -1;
            this.gv.DataBind();
        }

        protected void dv_ItemDeleted(object sender, DetailsViewDeletedEventArgs e)
        {
            this.gv.SelectedIndex = -1;
            this.gv.DataBind();
        }

        protected void dv_ItemUpdated(object sender, DetailsViewUpdatedEventArgs e)
        {
            this.gv.SelectedIndex = -1;
            this.gv.DataBind();
        }

        protected void eds_ContextCreating(object sender, EntityDataSourceContextCreatingEventArgs e)
        {
            var pubs = new PubsEntities();

            e.Context = ((IObjectContextAdapter)pubs).ObjectContext;
        }
    }
}
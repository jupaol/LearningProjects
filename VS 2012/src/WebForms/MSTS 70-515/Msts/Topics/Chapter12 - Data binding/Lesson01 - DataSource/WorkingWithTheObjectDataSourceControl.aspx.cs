using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Msts.Topics.Chapter12___Data_binding.Lesson01___DataSource
{
    public partial class WorkingWithTheObjectDataSourceControl : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void applyFilter_Click(object sender, EventArgs e)
        {
            this.gv.PageIndex = 0;
            this.gv.DataBind();
        }

        protected void resetFilter_Click(object sender, EventArgs e)
        {
            this.descriptionFilter.Text = string.Empty;
            this.minimumFilter.SelectedIndex = 0;
            this.maximumFilter.SelectedIndex = this.maximumFilter.Items.Count - 1;
            this.gv.PageIndex = 0;
            this.gv.SelectedIndex = -1;
            this.gv.DataBind();
        }

        protected void gv_PageIndexChanged(object sender, EventArgs e)
        {
            this.gv.SelectedIndex = -1;
        }

        protected void jobDetails_ItemUpdated(object sender, DetailsViewUpdatedEventArgs e)
        {
            this.gv.SelectedIndex = -1;
            this.gv.DataBind();
        }

        protected void jobDetails_ItemInserted(object sender, DetailsViewInsertedEventArgs e)
        {
            this.gv.SelectedIndex = -1;
            this.gv.DataBind();
        }

        protected void jobDetails_ItemDeleted(object sender, DetailsViewDeletedEventArgs e)
        {
            this.gv.SelectedIndex = -1;
            this.gv.DataBind();
        }
    }
}
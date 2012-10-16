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
    public partial class WorkingWithTheListViewControl : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void eds_ContextCreating(object sender, EntityDataSourceContextCreatingEventArgs e)
        {
            e.Context = ((IObjectContextAdapter)new PubsEntities()).ObjectContext;
        }

        protected void lv_ItemEditing(object sender, ListViewEditEventArgs e)
        {
            this.lv.EditIndex = e.NewEditIndex;
        }

        protected void lv_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                if (this.lv.EditIndex != -1)
                {
                    var employee = e.Item.DataItem as employee;

                    if (employee != null)
                    {
                        var jobs = e.Item.FindControl("job") as DropDownList;

                        if (jobs != null)
                        {
                            jobs.SelectedValue = employee.job_id.ToString();
                        }
                    }
                }
            }
        }

        protected void lv_ItemUpdating(object sender, ListViewUpdateEventArgs e)
        {
            var jobs = this.lv.Items[e.ItemIndex].FindControl("job") as DropDownList;

            if (jobs != null)
            {
                e.NewValues.Add("job_id", jobs.SelectedValue);
            }
        }

        protected void job_SelectedIndexChanged(object sender, EventArgs e)
        {
            var jobs = sender as DropDownList;
            var jobID = Convert.ToInt16(jobs.SelectedValue);
            var job = new PubsEntities().jobs.FirstOrDefault(x => x.job_id == jobID);
            var listViewItem = (sender as Control).Parent as ListViewItem;

            if (listViewItem != null && job != null)
            {
                var rangeMessage = listViewItem.FindControl("jobLevelRangeMessage") as Label;
                var rangeValidator = listViewItem.FindControl("jobLevelRangeValidator") as RangeValidator;

                if (rangeMessage != null && rangeValidator != null)
                {
                    var min = job.min_lvl;
                    var max = job.max_lvl;

                    rangeMessage.Text = string.Format("({0} - {1})", min, max);
                    rangeValidator.MinimumValue = min.ToString();
                    rangeValidator.MaximumValue = max.ToString();
                }
            }
        }

        protected void new_Click(object sender, EventArgs e)
        {
            this.lv.InsertItemPosition = InsertItemPosition.FirstItem;
        }

        protected void lv_ItemInserting(object sender, ListViewInsertEventArgs e)
        {
            var listViewItem = this.lv.InsertItem;

            if (listViewItem != null)
            {
                var jobs = listViewItem.FindControl("job") as DropDownList;
                var publishers = listViewItem.FindControl("publisher") as DropDownList;

                e.Values.Add("job_id", jobs.SelectedValue);
                e.Values.Add("pub_id", publishers.SelectedValue);
            }
        }

        protected void job_SelectedIndexChanged1(object sender, EventArgs e)
        {
            var jobs = sender as DropDownList;

            if (string.IsNullOrWhiteSpace(jobs.SelectedValue))
            {
                return;
            }

            var jobID = Convert.ToInt16(jobs.SelectedValue);
            var job = new PubsEntities().jobs.FirstOrDefault(x => x.job_id == jobID);
            var listViewItem = (sender as Control).Parent as ListViewItem;

            if (listViewItem != null && job != null)
            {
                var rangeMessage = listViewItem.FindControl("jobLevelRangeMessage") as Label;
                var rangeValidator = listViewItem.FindControl("jobLevelRangeValidator") as RangeValidator;

                if (rangeMessage != null && rangeValidator != null)
                {
                    var min = job.min_lvl;
                    var max = job.max_lvl;

                    rangeMessage.Text = string.Format("({0} - {1})", min, max);
                    rangeValidator.MinimumValue = min.ToString();
                    rangeValidator.MaximumValue = max.ToString();
                }
            }
        }

        protected void lv_ItemInserted(object sender, ListViewInsertedEventArgs e)
        {
            this.lv.InsertItemPosition = InsertItemPosition.None;
        }

        protected void applyFilter_Click(object sender, EventArgs e)
        {
            this.lv.DataBind();
        }

        protected void resetFilter_Click(object sender, EventArgs e)
        {
            this.jobFilter.SelectedIndex = 0;
            this.firstNameFilter.Text = string.Empty;

            this.lv.DataBind();
        }

        protected void eds_QueryCreated(object sender, QueryCreatedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(this.jobFilter.SelectedValue))
            {
                var jobID = Convert.ToInt16(this.jobFilter.SelectedValue);

                e.Query = e.Query.OfType<employee>().Where(x => x.job_id == jobID);
            }

            if (!string.IsNullOrWhiteSpace(this.firstNameFilter.Text))
            {
                e.Query = e.Query.OfType<employee>().Where(x => x.fname.Contains(this.firstNameFilter.Text));
            }
        }
    }
}
using Msts.DataAccess.EFData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Msts.Topics.Chapter12___Data_binding.Lesson02___DataBound
{
    public partial class WorkingWithSimpleDataBoundControls : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void ddl_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.ddlRes.Text = this.ddl.SelectedItem.Text + " " + this.ddl.SelectedItem.Value;
        }

        protected void eds_ContextCreating(object sender, EntityDataSourceContextCreatingEventArgs e)
        {
            e.Context = ((IObjectContextAdapter)new PubsEntities()).ObjectContext;
        }

        protected void refreshListBox_Click(object sender, EventArgs e)
        {
            this.lbRes.Text = string.Empty;

            foreach (var item in this.lb.Items.OfType<ListItem>().Where(x => x.Selected == true))
            {
                this.lbRes.Text += "<br />" + item.Text + " " + item.Value;
            }
        }

        protected void cbl_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cblRes.Text = string.Empty;

            foreach (var item in this.cbl.Items.OfType<ListItem>().Where(x => x.Selected == true))
            {
                this.cblRes.Text += "<br />" + item.Text + " " + item.Value;
            }
        }

        protected void rbl_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.rblRes.Text = this.rbl.SelectedItem.Text + " " + this.rbl.SelectedValue;
        }

        public IQueryable<AdRotatorObject> adRotator_SelectMethod(object sender, EventArgs e)
        {
            return Enumerable.Range(1, 8).Select(x => new AdRotatorObject
                {
                    ImageUrl = "~/Content/Images/image" + x.ToString() + ".jpg"
                }).AsQueryable();
        }
    }

    public class AdRotatorObject
    {
        [Description("The URL of the image to display.")]
        public string ImageUrl { get; set; }

        [Description("The URL of the page to navigate to when the AdRotator control is clicked.")]
        public string NavigateUrl { get; set; }

        [Description("The text to display if the image is unavailable.")]
        public string AlternateText { get; set; }

        [Description("The category of the ad that can be used to filter for specific ads.")]
        public string Keyword { get; set; }

        [Description("A numeric value that indicates the likelihood of how often the ad is displayed. The total of all impression values in the XML file may not exceed 2,048,000,000 - 1. All attributes are optional.")]
        public int Impressions { get; set; }
    }
}
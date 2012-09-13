using Msts.Topics.Chapter02.Lesson01___MasterPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Msts
{
    public partial class Site : MasterPage
    {
        public string CurrentTitle
        {
            get
            {
                return this.title.Text;
            }
            set
            {
                this.title.Text = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //this.ddl.SelectedValue = this.Session["master"].ToString();
        }

        protected void changeMaster_Click(object sender, EventArgs e)
        {
            this.Session["master"] = this.ddl.SelectedValue;
            this.Response.Redirect(this.Request.RawUrl);
        }
    }
}
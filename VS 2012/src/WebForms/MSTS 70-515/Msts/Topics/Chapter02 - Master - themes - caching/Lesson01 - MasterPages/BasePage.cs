using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Profile;
using System.Web.UI;

namespace Msts.Topics.Chapter02.Lesson01___MasterPages
{
    public class BasePage : Page
    {
        public BasePage()
        {
            this.PreInit += BasePage_PreInit;
        }

        private void BasePage_PreInit(object sender, EventArgs e)
        {
            var masterPage = this.Session["master"];

            if (masterPage == null)
            {
                this.Session["master"] = "Site.master";
            }

            this.MasterPageFile = "~/" + this.Session["master"].ToString();
        }
    }
}
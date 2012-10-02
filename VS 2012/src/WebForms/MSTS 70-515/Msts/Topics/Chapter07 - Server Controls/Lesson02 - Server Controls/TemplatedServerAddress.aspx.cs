﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Msts.Topics.Chapter07___Server_Controls.Lesson02___Server_Controls
{
    public partial class TemplatedServerAddress : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.addressControl1.Address = "Super Toronot";
            this.DataBind();
        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            this.Response.Write(DateTime.Now.ToString());
        }

        protected void Unnamed2_Click1(object sender, EventArgs e)
        {
            this.Response.Write("From command button " + DateTime.Now.ToString());
        }
    }
}
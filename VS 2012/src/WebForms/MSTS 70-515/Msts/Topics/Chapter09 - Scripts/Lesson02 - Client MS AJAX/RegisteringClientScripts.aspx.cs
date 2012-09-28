using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

[assembly: WebResource("Msts.Scripts.Chapter09.JavaScriptEmbedded.js", "application/x-javascript")]

namespace Msts.Topics.Chapter09___Scripts.Lesson02___Client_MS_AJAX
{
    public partial class RegisteringClientScripts : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var script = new StringBuilder();

            script.Append("alert('From RegisterClientScriptBlock');");
            this.ClientScript.RegisterClientScriptBlock(
                this.GetType(), 
                "RegisterClientScriptBlock", 
                script.ToString(), 
                true);
            script.Clear();

            script.Append("alert('From RegisterStartupScript');");
            this.ClientScript.RegisterStartupScript(
                this.GetType(),
                "RegisterStartupScript",
                script.ToString(),
                true);
            script.Clear();

            script.AppendLine("alert('From RegisterOnSubmitStatement');");
            this.ClientScript.RegisterOnSubmitStatement(
                this.GetType(),
                "RegisterOnSubmitStatement",
                script.ToString());
            script.Clear();

            this.ClientScript.RegisterClientScriptInclude(
                this.GetType(),
                "RegisterClientScriptInclude",
                "/Scripts/Chapter09/JavaScript1Include.js");

            this.ClientScript.RegisterClientScriptResource(
                this.GetType(),
                "Msts.Scripts.Chapter09.JavaScriptEmbedded.js");
        }
    }
}
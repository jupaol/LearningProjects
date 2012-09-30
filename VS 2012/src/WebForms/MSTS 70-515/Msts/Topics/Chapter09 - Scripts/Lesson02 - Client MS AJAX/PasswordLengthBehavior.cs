using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

[assembly: WebResource("Msts.Scripts.Chapter09.PasswordLengthBehavior.js", "text/javascript")]

namespace Msts.Topics.Chapter09___Scripts.Lesson02___Client_MS_AJAX
{
    [TargetControlType(typeof(TextBox))]
    public class PasswordLengthBehavior : ExtenderControl
    {
        public string WeakCssClass { get; set; }
        public string MediumCssClass { get; set; }
        public string StrongCssClass { get; set; }
        public ScriptManager Manager { get; set; }

        protected override IEnumerable<ScriptDescriptor> GetScriptDescriptors(Control targetControl)
        {
            var descriptor = new ScriptControlDescriptor(
                "Msts.UI.Client.Controls.passwordLengthBehavior", 
                targetControl.ClientID);

            descriptor.AddProperty("weakCss", this.WeakCssClass);
            descriptor.AddProperty("mediumCss", this.MediumCssClass);
            descriptor.AddProperty("strongCss", this.StrongCssClass);

            return new[] { descriptor };
        }

        protected override IEnumerable<ScriptReference> GetScriptReferences()
        {
            var script1 = new ScriptReference
            {
                Assembly = this.GetType().Assembly.FullName,
                Name = "Msts.Scripts.Chapter09.PasswordLengthValidator.js"
            };
            var script2 = new ScriptReference
            {
                Assembly = this.GetType().Assembly.FullName,
                Name = "Msts.Scripts.Chapter09.PasswordLengthBehavior.js"
            };

            return new[] { script1, script2 };
        }

        protected override void OnInit(EventArgs e)
        {
            if (this.Page != null)
            {
                if (this.Page.ClientScript != null)
                {
                    if (this.Page.Header != null)
                    {
                        if (!this.Page.ClientScript.IsClientScriptBlockRegistered("passCss"))
                        {
                            var link = new HtmlLink
                            {
                                Href = this.Page.ClientScript.GetWebResourceUrl(
                                    this.GetType(),
                                    "Msts.Content.Chapter09.PasswordStrength.css")
                            };

                            link.Attributes.Add("rel", "stylesheet");
                            link.Attributes.Add("type", "text/css");

                            this.Page.Header.Controls.Add(link);

                            this.Page.ClientScript.RegisterClientScriptBlock(
                                typeof(Page),
                                "passCss",
                                string.Empty);
                        }
                    }
                }
            }

            base.OnInit(e);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

[assembly: WebResource("Msts.Scripts.Chapter09.PasswordLengthControl.js", "text/javascript")]
[assembly: WebResource("Msts.Scripts.Chapter09.PasswordLengthValidator.js", "text/javascript")]

[assembly: WebResource("Msts.Content.Chapter09.PasswordStrength.css", "text/css")]

namespace Msts.Topics.Chapter09___Scripts.Lesson02___Client_MS_AJAX
{
    public class PasswordLengthControl : TextBox, IScriptControl
    {
        public string WeakCssClass { get; set; }
        public string MediumCssClass { get; set; }
        public string StrongCssClass { get; set; }
        public ScriptManager ScriptManager { get; set; }

        public PasswordLengthControl()
        {
            this.Load += PasswordLengthControl_Load;
        }

        private void PasswordLengthControl_Load(object sender, EventArgs e)
        {
            if (this.Page != null)
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

        public IEnumerable<ScriptDescriptor> GetScriptDescriptors()
        {
            var descriptor = new ScriptControlDescriptor("Msts.UI.Client.Controls.passwordLengthControl", this.ClientID);

            descriptor.AddProperty("weakCss", this.WeakCssClass);
            descriptor.AddProperty("mediumCss", this.MediumCssClass);
            descriptor.AddProperty("strongCss", this.StrongCssClass);

            return new[] { descriptor };
        }

        public IEnumerable<ScriptReference> GetScriptReferences()
        {
            var script1 = new ScriptReference
            {
                Assembly = this.GetType().Assembly.FullName,
                Name = "Msts.Scripts.Chapter09.PasswordLengthValidator.js"
            };
            var script2 = new ScriptReference
            {
                Assembly = this.GetType().Assembly.FullName,
                Name = "Msts.Scripts.Chapter09.PasswordLengthControl.js"
            };

            return new[] { script1, script2 };
        }

        protected override void OnPreRender(EventArgs e)
        {
            if (!this.DesignMode)
            {
                var manager = ScriptManager.GetCurrent(this.Page);

                if (manager == null)
                {
                    throw new InvalidOperationException("A 'ScriptManager' control is required");
                }

                manager.RegisterScriptControl(this);
                this.ScriptManager = manager;
            }

            base.OnPreRender(e);
        }

        protected override void Render(HtmlTextWriter writer)
        {
            if (!this.DesignMode)
            {
                this.ScriptManager.RegisterScriptDescriptors(this);
            }

            base.Render(writer);
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.Design;

namespace Msts.Topics.Chapter07___Server_Controls.Lesson02___Server_Controls
{
    public class TemplatedServerAddressDesigner : ControlDesigner
    {
        private TemplatedServerAddressControl controlInstance;

        public override void Initialize(IComponent component)
        {
            this.controlInstance = (TemplatedServerAddressControl)component;

            base.Initialize(component);
        }

        public override string GetDesignTimeHtml()
        {
            var sw = new StringWriter();
            var htmlWriter = new HtmlTextWriter(sw);
            var controlTemplate = this.controlInstance.AddressTemplate;

            if (controlTemplate != null)
            {
                this.controlInstance.AddressContainer = new TemplatedServerAddressContainer(
                    this.controlInstance.Address
                    );
                controlTemplate.InstantiateIn(this.controlInstance.AddressContainer);

                this.controlInstance.DataBind();

                this.controlInstance.RenderControl(htmlWriter);
            }

            return sw.ToString();
        }
    }
}
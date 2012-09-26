using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.Design;

namespace Msts.Topics.Chapter07___Server_Controls.Lesson01___User_Controls
{
    public class TemplatedAddressDesigner : ControlDesigner
    {
        private TemplatedAddress templatedAddressControl;

        public override void Initialize(IComponent component)
        {
            this.templatedAddressControl = (TemplatedAddress)component;

            base.Initialize(component);
        }

        public override string GetDesignTimeHtml()
        {
            var sw = new StringWriter();
            var htw = new HtmlTextWriter(sw);

            this.templatedAddressControl.TemplatedAddressContainer = new TemplatedAddressContainer(
                this.templatedAddressControl.Address);

            if (this.templatedAddressControl.AddressTemplate != null)
            {
                this.templatedAddressControl.AddressTemplate.InstantiateIn(
                    this.templatedAddressControl.TemplatedAddressContainer);

                this.templatedAddressControl.DataBind();

                this.templatedAddressControl.RenderControl(htw);
            }

            return sw.ToString();
        }
    }
}
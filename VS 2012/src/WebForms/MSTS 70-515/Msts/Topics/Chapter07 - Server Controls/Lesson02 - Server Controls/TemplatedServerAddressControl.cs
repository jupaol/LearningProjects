using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Msts.Topics.Chapter07___Server_Controls.Lesson02___Server_Controls
{
    [DefaultProperty("Address")]
    [ToolboxItem(true)]
    [ToolboxData("<{0}:TemplatedServerAddressControl runate=server></{0}:TemplatedServerAddressControl>")]
    [Designer(typeof(TemplatedServerAddressDesigner))]
    //[ToolboxBitmap(typeof(TemplatedServerAddressControl), "")]
    [Description("My templated server control")]
    [ParseChildren(true)]
    public class TemplatedServerAddressControl : WebControl
    {
        private TemplatedServerAddressContainer addressContainer;

        [Bindable(true)]
        [Localizable(true)]
        [DefaultValue(null)]
        [Description("The custom address")]
        [Category("Apperance")]
        [Browsable(true)]
        public string Address
        {
            get
            {
                return (this.ViewState["Address"] ?? string.Empty).ToString();
            }
            set
            {
                this.ViewState["Address"] = value;
            }
        }

        [Browsable(false)]
        [DefaultValue(null)]
        [Description("Address template")]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [TemplateContainer(typeof(TemplatedServerAddressContainer))]
        [TemplateInstance(TemplateInstance.Multiple)]
        public ITemplate AddressTemplate { get; set; }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TemplatedServerAddressContainer AddressContainer
        {
            get
            {
                this.EnsureChildControls();

                return this.addressContainer;
            }
            internal set
            {
                this.addressContainer = value;
            }
        }

        public override ControlCollection Controls
        {
            get
            {
                this.EnsureChildControls();

                return base.Controls;
            }
        }

        public override void DataBind()
        {
            this.CreateChildControls();
            this.ChildControlsCreated = true;

            base.DataBind();
        }

        protected override void CreateChildControls()
        {
            this.Controls.Clear();

            if (this.AddressTemplate != null)
            {
                this.addressContainer = new TemplatedServerAddressContainer(this.Address);

                this.AddressTemplate.InstantiateIn(this.addressContainer);
                this.Controls.Add(this.addressContainer);
            }
        }
    }
}
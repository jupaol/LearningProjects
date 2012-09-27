using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Msts.Topics.Chapter07___Server_Controls.Lesson01___User_Controls
{
    [DefaultProperty("Address")]
    [ToolboxData("<{0}:TemplatedAddress runat=server ></{0}:TemplatedAddress>")]
    [Designer(typeof(TemplatedAddressDesigner))]
    public partial class TemplatedAddress : UserControl
    {
        private ITemplate addressTemplate;
        private TemplatedAddressContainer templatedAddressContainer;

        [Bindable(true)]
        [Category("Apperance")]
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
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TemplatedAddressContainer TemplatedAddressContainer
        {
            get
            {
                this.EnsureChildControls();

                return this.templatedAddressContainer;
            }
            internal set
            {
                this.templatedAddressContainer = value;
            }
        }

        [Browsable(false)]
        [DefaultValue(null)]
        [Description("My custom template")]
        [TemplateContainer(typeof(TemplatedAddressContainer))]
        [TemplateInstance(TemplateInstance.Multiple)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public ITemplate AddressTemplate
        {
            get
            {
                return this.addressTemplate;
            }
            set
            {
                this.addressTemplate = value;
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

            this.ClearChildViewState();
            this.TrackViewState();

            if (this.AddressTemplate != null)
            {
                this.templatedAddressContainer = new TemplatedAddressContainer(this.Address);

                this.AddressTemplate.InstantiateIn(this.templatedAddressContainer);
                this.Controls.Add(this.templatedAddressContainer);
            }
        }
    }
}
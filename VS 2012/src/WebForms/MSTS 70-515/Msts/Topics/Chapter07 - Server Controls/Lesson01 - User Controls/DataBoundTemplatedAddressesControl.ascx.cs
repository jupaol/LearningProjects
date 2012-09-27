using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Linq;

namespace Msts.Topics.Chapter07___Server_Controls.Lesson01___User_Controls
{
    [ToolboxData("<{0}:DataBoundTemplatedAddressesControl runate=server ></{0}:DataBoundTemplatedAddressesControl>")]
    [ToolboxItem(true)]
    [Description("Addresses databound templated user control")]
    public partial class DataBoundTemplatedAddressesControl : System.Web.UI.UserControl
    {
        private const string AddressesCountKey = "AddressesCount";

        private object dataSource;

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
            this.OnDataBinding(EventArgs.Empty);

            this.Controls.Clear();
            this.ClearChildControlState();
            this.ClearChildViewState();
            this.TrackViewState();

            this.CreateChildControlsHierarchy(true);

            this.ChildControlsCreated = true;
        }

        protected override void CreateChildControls()
        {
            this.Controls.Clear();

            if (this.ViewState[AddressesCountKey] != null)
            {
                this.CreateChildControlsHierarchy(false);
            }
        }

        [Browsable(false)]
        [Bindable(true)]
        [Localizable(false)]
        [Description("RSS Datasource")]
        [Category("Data")]
        [DefaultValue(null)]
        public object DataSource
        {
            get
            {
                return this.dataSource;
            }
            set
            {
                if (value is string ||
                    value is XmlDocument ||
                    value is XDocument ||
                    value is XmlReader ||
                    value is TextReader)
                {
                    this.dataSource = value;
                }
                else
                {
                    throw new ArgumentException("Not a vlaid type for DataSource. Expected: string, XmlDocument, XDocument, XmlReader or TextReader");
                }
            }
        }

        private void CreateChildControlsHierarchy(bool gatherItemsFromDataSoyrce)
        {
        }
    }
}
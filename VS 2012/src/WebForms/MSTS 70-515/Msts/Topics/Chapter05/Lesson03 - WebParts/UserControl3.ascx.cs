using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace Msts.Topics.Chapter05.Lesson03___WebParts
{
    public partial class UserControl3 : System.Web.UI.UserControl
    {
        [Personalizable]
        [WebBrowsable]
        [WebDisplayName("Postal Code")]
        [WebDescription("Personal postal code")]
        public string PostalCode { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [ConnectionConsumer("Summary Display", "Date Changed Handler")]
        public void DateChangedHandler(DateTime value)
        {
            this.msg.Text += string.Format("<br />Date changed: {0}", value.ToString());
        }

        protected void process_Click(object sender, EventArgs e)
        {
            this.PostalCode = this.postalCode.Text;
        }

        [ConnectionProvider(displayName: "Postal code changed", id: "Postal Code Changed")]
        public string PostalCodeChanged()
        {
            return this.PostalCode;
        }
    }
}
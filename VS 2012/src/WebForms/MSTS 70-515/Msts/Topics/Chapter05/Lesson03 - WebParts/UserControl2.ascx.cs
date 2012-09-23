using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace Msts.Topics.Chapter05.Lesson03___WebParts
{
    public partial class UserControl2 : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [ConnectionConsumer(displayName: "Changed Date Handler in File Upload", id: "Changed Date Handler File Upload")]
        public void ChangedDateHandler(DateTime date)
        {
            this.msg.Text += "<br />Date changed: " + date.ToString();
        }

        [ConnectionConsumer(displayName: "Changed Date Handler in File Upload2", id: "Changed Date Handler File Upload2")]
        public void ChangedDateHandler2(DateTime date)
        {
            this.msg.Text += "<br />Date changed2: " + date.ToString();
        }

        [ConnectionConsumer(displayName: "PostalCode handler from UploadFile", id: "PostalCodeHandlerFromUploadFile")]
        public void PostalCodeHandler(string postalCode)
        {
            this.msg.Text += string.Format("<br />Postal code changed from UploadFile {0}", postalCode);
        }
    }
}
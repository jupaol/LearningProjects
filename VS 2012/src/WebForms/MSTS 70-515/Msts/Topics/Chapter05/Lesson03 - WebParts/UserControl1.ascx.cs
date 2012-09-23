using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace Msts.Topics.Chapter05.Lesson03___WebParts
{
    public partial class UserControl1 : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.calendar.SelectedDate = DateTime.Now.Date;
        }

        protected void calendar_SelectionChanged(object sender, EventArgs e)
        {

        }

        [ConnectionProvider("Date Picker", "Date Changed")]
        public DateTime DateChanged()
        {
            return this.calendar.SelectedDate;
        }

        [ConnectionConsumer(displayName: "Postal code handler from date picker", id: "PostalCodeHandlerFromDatePicker")]
        public void PostalCodeHandler(string postalCode)
        {
            this.msg.Text += "<br />Postal code changed from datepicker: " + postalCode;
        }
    }
}
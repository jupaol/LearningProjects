using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Msts.Topics.Chapter05.Lesson01___Input_Validation
{
    public partial class TestingValidation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.birthdayDateRangeValidator.MinimumValue = DateTime.Today.AddYears(-100).ToShortDateString();
            this.birthdayDateRangeValidator.MaximumValue = DateTime.Today.ToShortDateString();
            this.birthdayDateRangeValidator.ToolTip = string.Format("Range allowed: {0} - {1}", this.birthdayDateRangeValidator.MinimumValue, this.birthdayDateRangeValidator.MaximumValue);
        }

        protected void sendInfo_Click(object sender, EventArgs e)
        {

        }

        protected void preferedColors_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void favoriteEmailProviderValdiator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            switch (args.Value.ToLowerInvariant())
            {
                case "google":
                case "microsoft":
                    args.IsValid = true;
                    break;
                default:
                    args.IsValid = false;
                    break;
            }
        }
    }
}
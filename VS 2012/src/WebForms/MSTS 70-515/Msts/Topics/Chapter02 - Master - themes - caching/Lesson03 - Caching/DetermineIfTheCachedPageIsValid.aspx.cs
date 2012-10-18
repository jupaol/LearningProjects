using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Msts.Topics.Chapter02.Lesson03
{
    public partial class DetermineIfTheCachedPageIsValid : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Response.Cache.AddValidationCallback(ValidateCachedOutput, null);
            this.msg2.Text = DateTime.Now.ToString();
        }

        public static void ValidateCachedOutput(HttpContext context, object data, ref HttpValidationStatus validationStatus)
        {
            var status = context.Request.QueryString["status"];

            if (!string.IsNullOrWhiteSpace(status))
            {
                switch (status)
                {
                    case "valid":
                        validationStatus = HttpValidationStatus.Valid;
                        break;
                    case "invalid":
                        validationStatus = HttpValidationStatus.Invalid;
                        break;
                    case "ignore":
                        validationStatus = HttpValidationStatus.IgnoreThisRequest;
                        break;
                    default:
                        throw new ArgumentException("status");
                }
            }
            else
            {
                validationStatus = HttpValidationStatus.Valid;
            }
        }

        public static string CurrentSubstitution(HttpContext context)
        {
            return DateTime.Now.ToString();
        }
    }
}
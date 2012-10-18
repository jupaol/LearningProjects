using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Msts.Topics.Chapter04.Lesson01___Server_Controls
{
    public partial class SpecializedServerControls : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //this.calendar.SelectedDate = DateTime.Today.AddMonths(1);
            this.calendar.VisibleDate = DateTime.Today.AddMonths(-1);

            var date = DateTime.Now.AddMonths(1);

            this.calendar.SelectedDate = date.Date;
        }

        protected void calendar_DayRender(object sender, DayRenderEventArgs e)
        {

        }

        protected void calendar_SelectionChanged(object sender, EventArgs e)
        {

        }

        protected void calendar_SelectionChanged1(object sender, EventArgs e)
        {

        }

        protected void calendar_VisibleMonthChanged(object sender, MonthChangedEventArgs e)
        {

        }

        protected void sendFile_Click(object sender, EventArgs e)
        {
            if (this.fileUpload.HasFile)
            {
                var mimeType = this.fileUpload.PostedFile.ContentType;
                var fileLength = this.fileUpload.PostedFile.ContentLength;
                var fileName = this.fileUpload.PostedFile.FileName;
                var mimeTypeAllowed = false;

                switch (mimeType.ToLowerInvariant())
                {
                    case "image/png":
                        mimeTypeAllowed = true;
                        break;
                    default:
                        mimeTypeAllowed = false;
                        break;
                }

                if (mimeTypeAllowed)
                {
                    var fileExtension = Path.GetExtension(fileName);
                    var newFileName = Path.ChangeExtension("file_" + Guid.NewGuid().ToString("N"), fileExtension);
                    var basePath = Server.MapPath("~/Files");
                    var finalPath = Path.Combine(basePath, newFileName).ToLowerInvariant();

                    this.fileUpload.SaveAs(finalPath);

                    this.msg.Text = string.Format("File saved ({0} bytes added - {1})", fileLength, this.fileUpload.FileBytes.Length);
                }
                else
                {
                    this.msg.Text = "File type not allowed";
                    return;
                }
            }
            else
            {
                this.msg.Text = "No file selected";
            }
        }

        protected void multiView_ActiveViewChanged(object sender, EventArgs e)
        {

        }

        protected void view1_Activate(object sender, EventArgs e)
        {
            this.viewMsg1.Text += "<br />" +  MethodInfo.GetCurrentMethod().Name;
        }

        protected void view1_Deactivate(object sender, EventArgs e)
        {
            this.viewMsg1.Text += "<br />" + MethodInfo.GetCurrentMethod().Name;
        }

        protected void view2_Activate(object sender, EventArgs e)
        {
            this.viewMsg2.Text += "<br />" + MethodInfo.GetCurrentMethod().Name;
        }

        protected void view2_Deactivate(object sender, EventArgs e)
        {
            this.viewMsg2.Text += "<br />" + MethodInfo.GetCurrentMethod().Name;
        }

        protected void view3_Activate(object sender, EventArgs e)
        {
            this.viewMsg3.Text += "<br />" + MethodInfo.GetCurrentMethod().Name;
        }

        protected void view3_Deactivate(object sender, EventArgs e)
        {
            this.viewMsg3.Text += "<br />" + MethodInfo.GetCurrentMethod().Name;
        }

        protected void ddlViews_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.multiView.ActiveViewIndex = this.ddlViews.SelectedIndex;
        }

        protected void view_Command(object sender, CommandEventArgs e)
        {
            var currentView = this.multiView.ActiveViewIndex;
            var maxViewIndex = this.multiView.Views.Count;
            var minViewIndex = 0;
            var newViewIndex = 0;

            switch (e.CommandName)
            {
                case "prev":
                    newViewIndex = currentView - 1;

                    if (newViewIndex < minViewIndex)
                    {
                        newViewIndex = minViewIndex;
                    }
                    break;
                case "next":
                    newViewIndex = currentView + 1;

                    if (newViewIndex >= maxViewIndex)
                    {
                        newViewIndex = maxViewIndex - 1;
                    }
                    break;
                default:
                    throw new SecurityException("Value out of range, possible page tempering");
            }

            this.multiView.ActiveViewIndex = newViewIndex;
            this.ddlViews.SelectedIndex = newViewIndex;
        }

        protected void ddlWizardSteps_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.IsValid)
            {
                this.wizard.ActiveStepIndex = this.ddlWizardSteps.SelectedIndex;
            }
            else
            {
                this.ddlWizardSteps.SelectedIndex = this.wizard.ActiveStepIndex;
            }
        }

        protected void wizard_NextButtonClick(object sender, WizardNavigationEventArgs e)
        {
            this.Validate("mywizatd");

            e.Cancel = !this.IsValid;
        }

        protected void wizard_SideBarButtonClick(object sender, WizardNavigationEventArgs e)
        {
            this.Validate("mywizatd");

            e.Cancel = !this.IsValid;
        }

        protected void wizard_ActiveStepChanged(object sender, EventArgs e)
        {
        }

        protected void wizard_FinishButtonClick(object sender, WizardNavigationEventArgs e)
        {
            this.Validate("mywizatd");

            e.Cancel = !this.IsValid;
        }
    }
}
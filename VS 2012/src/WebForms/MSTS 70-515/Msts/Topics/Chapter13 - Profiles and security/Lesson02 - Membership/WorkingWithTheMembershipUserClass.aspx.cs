using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Msts.Topics.Chapter13___Profiles_and_security.Lesson02___Membership
{
    public partial class WorkingWithTheMembershipUserClass : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            this.gv.EnableDynamicData(typeof(MembershipUser));
            this.dv.EnableDynamicData(typeof(MembershipUser));
        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IEnumerable<MembershipUser> gv_GetData(
            [Control] string emailFilter,
            [Control] string usernameFilter,
            int maximumRows, 
            int startRowIndex,
            out int totalRowCount,
            string sortByExpression)
        {
            var pageIndex = (int)Math.Ceiling((double)startRowIndex / (double)maximumRows);

            if (!string.IsNullOrWhiteSpace(emailFilter))
            {
                return Membership.FindUsersByEmail(emailFilter, pageIndex, maximumRows, out totalRowCount)
                    .OfType<MembershipUser>().AsEnumerable();
            }

            if (!string.IsNullOrWhiteSpace(usernameFilter))
            {
                return Membership.FindUsersByName(usernameFilter, pageIndex, maximumRows, out totalRowCount)
                    .OfType<MembershipUser>().AsEnumerable();
            }

            return Membership.GetAllUsers(pageIndex, maximumRows, out totalRowCount)
                .OfType<MembershipUser>().AsEnumerable();
        }

        protected void filterType_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.ConfigureFilter();
        }

        private void ConfigureFilter()
        {
            var searchType = Convert.ToInt32(this.filterType.SelectedValue);

            switch (searchType)
            {
                case 1:
                    this.usernameFilter.Text = string.Empty;
                    this.usernameFilter.Enabled = false;
                    this.emailFilter.Enabled = true;
                    break;
                case 2:
                    this.emailFilter.Text = string.Empty;
                    this.emailFilter.Enabled = false;
                    this.usernameFilter.Enabled = true;
                    break;
            }
        }

        protected void applyFilter_Click(object sender, EventArgs e)
        {
            this.gv.DataBind();
        }

        protected void clearFilter_Click(object sender, EventArgs e)
        {
            this.filterType.SelectedValue = "1";
            this.emailFilter.Text = string.Empty;
            this.ConfigureFilter();
            this.gv.SelectedIndex = -1;
            this.gv.EditIndex = -1;
            this.gv.PageIndex = 0;
            this.dv.ChangeMode(DetailsViewMode.ReadOnly);
            this.gv.DataBind();
        }

        // The id parameter should match the DataKeyNames value set on the control
        // or be decorated with a value provider attribute, e.g. [QueryString]int id
        public MembershipUser dv_GetItem([Control] string gv)
        {
            if (string.IsNullOrWhiteSpace(gv))
            {
                return null;
            }

            return Membership.FindUsersByName(gv)
                .OfType<MembershipUser>().FirstOrDefault();
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void dv_UpdateItem(string UserName)
        {
            MembershipUser item = Membership.FindUsersByName(UserName)
                .OfType<MembershipUser>().FirstOrDefault();
            // Load the item here, e.g. item = MyDataLayer.Find(id);
            if (item == null)
            {
                // The item wasn't found
                ModelState.AddModelError("", String.Format("Item with id {0} was not found", UserName));
                return;
            }
            TryUpdateModel(item);
            if (ModelState.IsValid)
            {
                // Save changes here, e.g. MyDataLayer.SaveChanges();
                Membership.UpdateUser(item);
            }
        }

        protected void dv_ItemUpdated(object sender, DetailsViewUpdatedEventArgs e)
        {
            this.gv.DataBind();
        }

        protected void gv_PageIndexChanged(object sender, EventArgs e)
        {
            this.gv.SelectedIndex = -1;
            this.gv.EditIndex = -1;
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void gv_DeleteItem(string UserName)
        {
            Membership.DeleteUser(UserName, true);
        }

        protected void gv_RowDeleted(object sender, GridViewDeletedEventArgs e)
        {
            this.gv.SelectedIndex = -1;
            this.gv.EditIndex = -1;
        }

        protected void new_Click(object sender, EventArgs e)
        {
            this.newPanel.Visible = true;
            this.newUser.Visible = false;
        }

        protected void createUser_Click(object sender, EventArgs e)
        {
            MembershipCreateStatus status;

            Membership.CreateUser(
                this.username.Text, 
                this.password.Text, 
                this.email.Text,
                this.question.Text,
                this.answer.Text,
                true,
                out status
            );
            this.clearFilter_Click(null, EventArgs.Empty);

            this.newPanel.Visible = false;
            this.newUser.Visible = true;

            this.username.Text = string.Empty;
            this.password.Text = string.Empty;
            this.email.Text = string.Empty;
            this.question.Text = string.Empty;
            this.answer.Text = string.Empty;
        }

        protected void cancelUserCreation_Click(object sender, EventArgs e)
        {
            this.newPanel.Visible = false;
            this.newUser.Visible = true;
        }
    }
}
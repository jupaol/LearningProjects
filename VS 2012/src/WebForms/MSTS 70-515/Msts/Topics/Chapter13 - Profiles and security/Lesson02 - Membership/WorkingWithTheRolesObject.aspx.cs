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
    public partial class WorkingWithTheRolesObject : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<RoleDto> gv_GetData()
        {
            return Roles.GetAllRoles().Select(x => new RoleDto { Name = x }).AsQueryable();
        }

        protected void newRole_Click(object sender, EventArgs e)
        {
            this.newRolePanel.Visible = true;
            this.newRole.Visible = false;
        }

        protected void createRole_Click(object sender, EventArgs e)
        {
            Roles.CreateRole(this.roleName.Text);

            this.newRolePanel.Visible = false;
            this.newRole.Visible = true;
            this.roleName.Text = string.Empty;
            this.gv.SelectedIndex = -1;
            this.gv.EditIndex = -1;
            this.gv.PageIndex = 0;
            this.gv.DataBind();
        }

        protected void cancelRoleCreation_Click(object sender, EventArgs e)
        {
            this.newRolePanel.Visible = false;
            this.newRole.Visible = true;
            this.roleName.Text = string.Empty;
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void gv_DeleteItem(string Name)
        {
            Roles.DeleteRole(Name);
        }

        protected void gv_RowDeleted(object sender, GridViewDeletedEventArgs e)
        {
            this.gv.SelectedIndex = -1;
            this.gv.EditIndex = -1;
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void gv_UpdateItem()
        {
            var name = this.gv.DataKeys[this.gv.EditIndex].Value.ToString();

            Roles.DeleteRole(name);

            var item = new RoleDto();

            this.TryUpdateModel(item);
            if (this.ModelState.IsValid)
            {
                Roles.CreateRole(item.Name);
            }
        }

        protected void gv_RowUpdated(object sender, GridViewUpdatedEventArgs e)
        {
            this.gv.SelectedIndex = -1;
            this.gv.EditIndex = -1;
        }
    }
}
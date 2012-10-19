using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Profile;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Msts.Topics.Chapter13___Profiles_and_security.Lesson01___Profiles
{
    public partial class WorkingWithTheProfileOnTheServerSide : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // The id parameter should match the DataKeyNames value set on the control
        // or be decorated with a value provider attribute, e.g. [QueryString]int id
        public Msts.CustomProfile dv_GetItem()
        {
            var profile = CustomProfile.GetCurrentProfile();

            return profile;
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void dv_UpdateItem(string UserName)
        {
            Msts.CustomProfile item = CustomProfile.GetCurrentProfile();
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
                item.Save();
            }
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void dv_DeleteItem(string UserName)
        {
            Msts.CustomProfile item = CustomProfile.GetCurrentProfile();

            if (item == null)
            {
                ModelState.AddModelError("", String.Format("Item with id {0} was not found", UserName));
                return;
            }

            var isAnonymous = item.IsAnonymous;

            ProfileManager.DeleteProfile(UserName);

            //if (isAnonymous)
            //{
            //    AnonymousIdentificationModule.ClearAnonymousIdentifier();
            //}
        }

        protected void dv_ItemDeleted(object sender, DetailsViewDeletedEventArgs e)
        {
            this.Response.Redirect(this.Request.RawUrl);
        }

        protected void dv_ItemUpdated(object sender, DetailsViewUpdatedEventArgs e)
        {
            this.Response.Redirect(this.Request.RawUrl);
        }
    }
}
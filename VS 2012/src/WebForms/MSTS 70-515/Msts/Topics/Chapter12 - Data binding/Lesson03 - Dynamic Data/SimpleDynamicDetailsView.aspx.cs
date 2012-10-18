using Microsoft.Practices.ServiceLocation;
using Msts.DataAccess.EFData;
using Msts.Topics.Chapter12___Data_binding.Lesson01___DataSource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Msts.Topics.Chapter12___Data_binding.Lesson03___Dynamic_Data
{
    public partial class SimpleDynamicDetailsView : System.Web.UI.Page
    {
        private IContextWrapper contextWrapper;

        public SimpleDynamicDetailsView()
        {
            this.contextWrapper = ServiceLocator.Current.GetInstance<IContextWrapper>();
        }

        public job dv_GetItem([QueryString]Int16 job_id)
        {
            var job = this.contextWrapper.GetEFContext().jobs.FirstOrDefault(x => x.job_id == job_id);

            if (job == null)
            {
                this.ModelState.AddModelError(string.Empty, string.Format("Item with id {0} not found", job_id));
            }

            return job;
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void dv_UpdateItem(Int16 job_id)
        {
            Msts.DataAccess.EFData.job item = this.contextWrapper.GetEFContext().jobs.FirstOrDefault(x => x.job_id == job_id);
            // Load the item here, e.g. item = MyDataLayer.Find(id);
            if (item == null)
            {
                // The item wasn't found
                ModelState.AddModelError("", String.Format("Item with id {0} was not found", job_id));
                return;
            }
            TryUpdateModel(item);
            if (ModelState.IsValid)
            {
                // Save changes here, e.g. MyDataLayer.SaveChanges();
                this.contextWrapper.GetEFContext().SaveChanges();
            }
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void dv_DeleteItem(Int16 job_id)
        {
            var exists = this.contextWrapper.GetEFContext().jobs.Any(x => x.job_id == job_id);

            if (!exists)
            {
                this.ModelState.AddModelError(string.Empty, string.Format("Item with id {0} not found", job_id));
                return;
            }

            this.contextWrapper.GetEFContext().Entry(new job { job_id = job_id }).State = System.Data.EntityState.Deleted;
            this.contextWrapper.GetEFContext().SaveChanges();
            this.Response.Redirect("SimpleDynamicListView.aspx");
        }

        public void dv_InsertItem()
        {
            var item = new Msts.DataAccess.EFData.job();

            TryUpdateModel(item);

            if (ModelState.IsValid)
            {
                // Save changes here
                this.contextWrapper.GetEFContext().jobs.Add(item);
                this.contextWrapper.GetEFContext().SaveChanges();
                this.Response.Redirect(this.Request.Path + "?job_id=" + item.job_id.ToString());
            }
        }
    }
}
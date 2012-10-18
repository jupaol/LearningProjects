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
    public partial class SimpleDynamicFormView : System.Web.UI.Page
    {
        private IContextWrapper contextWrapper;

        public SimpleDynamicFormView()
        {
            this.contextWrapper = ServiceLocator.Current.GetInstance<IContextWrapper>();
        }

        // The id parameter should match the DataKeyNames value set on the control
        // or be decorated with a value provider attribute, e.g. [QueryString]int id
        public job fv_GetItem([QueryString]Int16 job_id)
        {
            var job = this.contextWrapper.GetEFContext().jobs.FirstOrDefault(x => x.job_id == job_id);

            if (job == null)
            {
                this.ModelState.AddModelError(string.Empty, string.Format("Item with id {0} not found", job_id));
            }

            return job;
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void fv_UpdateItem(Int16 job_id)
        {
            var item = this.contextWrapper.GetEFContext().jobs.FirstOrDefault(x => x.job_id == job_id);

            // Load the item here, e.g. item = MyDataLayer.Find(id);
            if (item == null)
            {
                // The item wasn't found
                ModelState.AddModelError(string.Empty, String.Format("Item with id {0} was not found", job_id));
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
        public void fv_DeleteItem(Int16 job_id)
        {
            var item = this.contextWrapper.GetEFContext().jobs.FirstOrDefault(x => x.job_id == job_id);

            if (item == null)
            {
                this.ModelState.AddModelError(string.Empty, string.Format("Item with id {0} not found", job_id));
                return;
            }

            var job = new job { job_id = job_id };

            this.contextWrapper.GetEFContext().Entry(job).State = System.Data.EntityState.Deleted;
            this.contextWrapper.GetEFContext().SaveChanges();
        }

        public void fv_InsertItem()
        {
            var item = new Msts.DataAccess.EFData.job();

            TryUpdateModel(item);

            if (ModelState.IsValid)
            {
                // Save changes here
                this.contextWrapper.GetEFContext().jobs.Add(item);
                this.contextWrapper.GetEFContext().SaveChanges();
            }
        }

        protected void fv_ItemCommand(object sender, FormViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
            }
        }
    }
}
using Microsoft.Practices.ServiceLocation;
using Msts.DataAccess.EFData;
using Msts.Topics.Chapter12___Data_binding.Lesson01___DataSource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Msts.Topics.Chapter12___Data_binding.Lesson03___Dynamic_Data
{
    public partial class SimpleDynamicListView : System.Web.UI.Page
    {
        private IContextWrapper contextWrapper;

        public SimpleDynamicListView()
        {
            this.contextWrapper = ServiceLocator.Current.GetInstance<IContextWrapper>();
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            this.lv.EnableDynamicData(typeof(job));
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<job> lv_GetData()
        {
            return this.contextWrapper.GetEFContext().jobs;
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void lv_UpdateItem(Int16 job_id)
        {
            job item = this.contextWrapper.GetEFContext().jobs.FirstOrDefault(x => x.job_id == job_id);
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
        public void lv_DeleteItem(Int16 job_id)
        {
            var found = this.contextWrapper.GetEFContext().jobs.Any(x => x.job_id == job_id);

            if (!found)
            {
                this.ModelState.AddModelError(string.Empty, string.Format("Item with id {0} was not found", job_id));
                return;
            }

            var item = new job { job_id = job_id };

            this.contextWrapper.GetEFContext().Entry(item).State = System.Data.EntityState.Deleted;
            this.contextWrapper.GetEFContext().SaveChanges();
        }

        public void lv_InsertItem()
        {
            var item = new job();

            TryUpdateModel(item);

            if (ModelState.IsValid)
            {
                // Save changes here
                this.contextWrapper.GetEFContext().jobs.Add(item);
                this.contextWrapper.GetEFContext().SaveChanges();
            }
        }

        protected void lv_ItemInserted(object sender, ListViewInsertedEventArgs e)
        {
            var listView = sender as ListView;

            listView.InsertItemPosition = InsertItemPosition.None;
        }

        protected void lv_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            var listView = sender as ListView;

            switch (e.CommandName)
            {
                case "New":
                    listView.InsertItemPosition = InsertItemPosition.LastItem;
                    break;
                case "CancelInsert":
                    listView.InsertItemPosition = InsertItemPosition.None;
                    break;
            }
        }
    }
}
using log4net;
using Microsoft.Practices.ServiceLocation;
using Msts.DataAccess.EFData;
using Msts.Topics.Chapter12___Data_binding.Lesson01___DataSource;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Msts.Topics.Chapter12___Data_binding.Lesson03___Dynamic_Data
{
    public partial class SimpleDynamicDataGridView : System.Web.UI.Page
    {
        private IContextWrapper contextWrapper;

        public SimpleDynamicDataGridView()
        {
            this.contextWrapper = ServiceLocator.Current.GetInstance<IContextWrapper>();

            Global.CurrentContext = this.contextWrapper.GetEFContext();

            if (!ReferenceEquals(this.contextWrapper.GetEFContext(), ServiceLocator.Current.GetInstance<IContextWrapper>().GetEFContext()))
            {
                throw new ApplicationException("Cmooooon");
            }
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            this.gv.EnableDynamicData(typeof(job));
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
        public IQueryable<job> gv_GetData()
        {
            return this.contextWrapper.GetEFContext().jobs.OrderBy(x => x.job_id);
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void gv_UpdateItem(Int16 job_id)
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
        public void gv_DeleteItem(Int16 job_id)
        {
            var ctx = this.contextWrapper.GetEFContext();

            ctx.Entry<job>(new job { job_id = job_id }).State = EntityState.Deleted;

            ctx.SaveChanges();
        }
    }
}
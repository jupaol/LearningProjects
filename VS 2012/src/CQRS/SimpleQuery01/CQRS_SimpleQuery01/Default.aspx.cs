using Microsoft.Practices.ServiceLocation;
using QueryRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CQRS_SimpleQuery01.Models
{
    public partial class Default : System.Web.UI.Page
    {
        private IJobsRepository jobsRepository;

        public Default()
        {
            this.jobsRepository = ServiceLocator.Current.GetInstance<IJobsRepository>();
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            this.gv.EnableDynamicData(typeof(JobDto));
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
            }
        }

        private void SimulateController()
        {
        }

        protected void ods_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
        }

        protected void ods_ObjectCreating(object sender, ObjectDataSourceEventArgs e)
        {

        }

        protected void ods_ObjectCreated(object sender, ObjectDataSourceEventArgs e)
        {
            
        }

        protected void ods_ObjectDisposing(object sender, ObjectDataSourceDisposingEventArgs e)
        {
            
        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<JobDto> gv_GetData()
        {
            return this.jobsRepository.GetJobs();
        }
    }
}
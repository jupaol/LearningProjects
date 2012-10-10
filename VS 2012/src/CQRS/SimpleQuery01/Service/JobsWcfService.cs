using Microsoft.Practices.ServiceLocation;
using QueryRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Text;
using System.Web;

namespace ExternalQueryService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "JobsWcfService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select JobsWcfService.svc or JobsWcfService.svc.cs at the Solution Explorer and start debugging.
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class JobsWcfService : IJobsWcfService
    {
        private IJobsRepository jobsRepository;

        public JobsWcfService()
        {
            //this.jobsRepository = ServiceLocator.Current.GetInstance<IJobsRepository>();
            this.jobsRepository = new JobsRepository(new EntityContextResolver(new HttpContextWrapper(HttpContext.Current)));
        }

        //public void DoSomething()
        //{
        //return this.jobsRepository.GetJobs().Select(x => new NewJobDto
        //    {
        //        Description = x.Description,
        //        ID = x.ID,
        //        Maximum = x.Maximum,
        //        Minimum = x.Minimum
        //    }).ToList();
        //}

        public IQueryable<JobDto> GetJobs()
        {
            return this.jobsRepository.GetJobs();
        }
    }
}

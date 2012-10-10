using ExternalQueryService;
using QueryRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ClientProxy
{
    public class Proxy : ClientBase<IJobsWcfService>, IJobsWcfService
    {
        //return new ChannelFactory<IJobsWcfService>().CreateChannel().GetJobs().ToList();

        public IQueryable<JobDto> GetJobs()
        {
            return this.Channel.GetJobs();
        }
    }
}

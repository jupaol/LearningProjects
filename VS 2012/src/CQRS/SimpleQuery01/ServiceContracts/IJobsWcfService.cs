using QueryRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ExternalQueryService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IJobsWcfService" in both code and config file together.
    [ServiceContract(SessionMode = SessionMode.Allowed)]
    public interface IJobsWcfService
    {
        [OperationContract]
        IQueryable<JobDto> GetJobs();

    }
}

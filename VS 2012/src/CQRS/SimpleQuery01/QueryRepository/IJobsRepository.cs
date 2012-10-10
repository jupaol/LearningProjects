using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryRepository
{
    public interface IJobsRepository
    {
        IQueryable<JobDto> GetJobs();

        JobDto GetJobByID(Int16 id);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryRepository
{
    public class JobsRepository : IJobsRepository
    {
        private IEntityContextResolver contextResolver;

        public JobsRepository(IEntityContextResolver contextResolver)
        {
            this.contextResolver = contextResolver;
        }

        public IQueryable<JobDto> GetJobs()
        {
            var ctx = this.contextResolver.GetCurrentContext<pubsEntities>();

            return ctx.jobs.Select(x => new JobDto
                {
                    Description = x.job_desc,
                    ID = x.job_id,
                    Maximum = x.max_lvl,
                    Minimum = x.min_lvl
                });
        }

        public JobDto GetJobByID(short id)
        {
            var ctx = this.contextResolver.GetCurrentContext<pubsEntities>();

            var job = ctx.jobs.FirstOrDefault(x => x.job_id == id);

            if (job != null)
            {
                return new JobDto
                {
                    Description = job.job_desc,
                    ID = job.job_id,
                    Maximum = job.max_lvl,
                    Minimum = job.min_lvl
                };
            }

            return null;
        }
    }
}

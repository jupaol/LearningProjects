using Msts.DataAccess.EFData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Linq;
using System.Data.Entity;
using System.Data.Objects;

namespace Msts.Topics.Chapter11___LINQ.Lesson02___LINQ_to_SQL
{
    public class ObjectDataSourceProvider
    {
        public IEnumerable<JobDTO> GetJobs(int startRow, int maximumRows)
        {
            var ctx = new PubsEntities();

            var q = ctx.jobs.AsEnumerable();

            q = q.Skip(startRow).Take(maximumRows);

            return q.Select(x => new JobDTO
                {
                    Description = x.job_desc,
                    ID = x.job_id,
                    Maximum = x.max_lvl,
                    Minimum = x.min_lvl
                });
        }

        public int GetJobsCount()
        {
            var ctx = new PubsEntities();

            var q = ctx.jobs.AsEnumerable();

            return q.Count();
        }

        public void UpdateJob(Int16 ID, string Description, byte Minimum, byte Maximum)
        {
            var ctx = new PubsEntities();
            var job = new job();

            job.job_id = ID;
            job.job_desc = Description;
            job.min_lvl = Minimum;
            job.max_lvl = Maximum;

            ctx.jobs.Attach(job);
            ctx.Entry(job).State = System.Data.EntityState.Modified;
            ctx.ChangeTracker.DetectChanges();

            ctx.SaveChanges();
        }

        public void DeleteJob(Int16 ID)
        {
            var ctx = new PubsEntities();

            var job = ctx.jobs.First(x => x.job_id == ID);

            ctx.jobs.Remove(job);

            ctx.SaveChanges();
        }
    }
}
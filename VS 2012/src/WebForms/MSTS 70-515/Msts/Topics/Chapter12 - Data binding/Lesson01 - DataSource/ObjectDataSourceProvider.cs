using AutoMapper;
using Msts.DataAccess.EFData;
using System;
using System.Collections.Generic;
using System.Data.Linq.SqlClient;
using System.Linq;
using System.Web;
//using Msts.ExtenssionMethods;
using System.Linq.Dynamic;

namespace Msts.Topics.Chapter12___Data_binding.Lesson01___DataSource
{
    public class ObjectDataSourceProvider
    {
        private PubsEntities context;

        public ObjectDataSourceProvider()
        {
            var wrapper = new ContextWrapper(new HttpContextWrapper(HttpContext.Current));

            this.context = wrapper.GetEFContext();
        }

        private IQueryable<JobDTO> ApplySort(IQueryable<JobDTO> source, string sortCriteria)
        {
            if (string.IsNullOrWhiteSpace(sortCriteria))
            {
                return source.OrderBy(x => x.ID);
            }

            string[] sortValues = sortCriteria.Split(' ');
            var desceding = false;

            if (sortValues.Length > 1)
            {
                if (sortValues[1].ToUpper() == "DESC")
                {
                    desceding = true;
                }
            }

            if (desceding)
            {
                return source.OrderBy(sortValues[0] + " descending");
            }
            else
            {
                return source.OrderBy(sortValues[0]);
            }
        }

        public IEnumerable<JobDTO> GetJobs(string description, byte? minimum, byte? maximum, int rowIndex, int pageSize, string sortCriteria)
        {
            var q = this.FindJobs(description, minimum, maximum);

            var res = q.Select(x => new JobDTO
                {
                    Description = x.job_desc,
                    ID = x.job_id,
                    Maximum = x.max_lvl,
                    Minimum = x.min_lvl
                });

            res = this.ApplySort(res, sortCriteria);
            res = res.Skip(rowIndex).Take(pageSize);

            return res;
        }

        public int GetJobsCount(string description, byte? minimum, byte? maximum)
        {
            return this.FindJobs(description, minimum, maximum).Count();
        }

        public IQueryable<JobDTO> GetJob(Int16 jobID)
        {
            return this.context.jobs.Where(x => x.job_id == jobID).Select(x => new JobDTO
            {
                Description = x.job_desc,
                ID = x.job_id,
                Maximum = x.max_lvl,
                Minimum = x.min_lvl
            });
        }

        public void AddJob(JobDTO job)
        {
            this.context.jobs.Add(Mapper.Map<job>(job));

            this.context.SaveChanges();
        }

        public void UpdateJob(JobDTO jobDto)
        {
            var job = Mapper.Map<job>(jobDto);

            this.context.jobs.Attach(job);
            this.context.Entry(job).State = System.Data.EntityState.Modified;
            this.context.ChangeTracker.DetectChanges();
            this.context.SaveChanges();
        }

        public void DeleteJob(JobDTO jobDto)
        {
            this.context.jobs.Remove(this.context.jobs.First(x => x.job_id == jobDto.ID));

            this.context.SaveChanges();
        }

        private IQueryable<job> FindJobs(string description, byte? minimum, byte? maximum)
        {
            var q = this.context.jobs.AsQueryable();

            if (!string.IsNullOrWhiteSpace(description))
            {
                q = q.Where(x => x.job_desc.ToLower().Contains(description.ToLower()));
            }

            if (minimum.HasValue)
            {
                q = q.Where(x => x.min_lvl >= minimum.Value);
            }

            if (maximum.HasValue)
            {
                q = q.Where(x => x.max_lvl <= maximum.Value);
            }

            return q;
        }
    }
}
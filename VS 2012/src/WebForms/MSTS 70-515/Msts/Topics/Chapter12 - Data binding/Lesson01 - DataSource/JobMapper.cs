using AutoMapper;
using Msts.DataAccess.EFData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Omu.ValueInjecter;

namespace Msts.Topics.Chapter12___Data_binding.Lesson01___DataSource
{
    public class JobMapper
    {
        public JobMapper()
        {
            Mapper.CreateMap<JobDTO, job>()
                .ForMember(x => x.job_desc, o => o.MapFrom(x => x.Description))
                .ForMember(x => x.job_id, o => o.MapFrom(x => x.ID))
                .ForMember(x => x.max_lvl, o => o.MapFrom(x => x.Maximum))
                .ForMember(x => x.min_lvl, o => o.MapFrom(x => x.Minimum))
                .ForMember(x => x.employees, o => o.Ignore());

            Mapper.CreateMap<job, JobDTO>()
                .ForMember(x => x.Description, o => o.MapFrom(x => x.job_desc))
                .ForMember(x => x.ID, o => o.MapFrom(x => x.job_id))
                .ForMember(x => x.Maximum, o => o.MapFrom(x => x.max_lvl))
                .ForMember(x => x.Minimum, o => o.MapFrom(x => x.min_lvl));
        }
    }
}
using QueryRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CQRS_SimpleQuery01.Models
{
    public class ViewModel
    {
        public IQueryable<JobDto> Jobs { get; set; }

        public ViewModel()
        {
        }
    }
}
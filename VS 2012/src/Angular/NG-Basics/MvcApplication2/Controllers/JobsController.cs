using System;
using System.Collections.Generic;
using System.Web.Http;
using MvcApplication2.DataAccess;
using MvcApplication2.Models;

namespace MvcApplication2.Controllers
{
    public class JobsController : ApiController
    {
        static readonly JobRepository _repo = new JobRepository();

        public IEnumerable<JobModel> Get(Int16 id)
        {
            return _repo.GetData(id);
        }
    }
}
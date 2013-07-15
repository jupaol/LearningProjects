using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using MvcApplication2.DataAccess;
using MvcApplication2.Models;
using Omu.ValueInjecter;

namespace MvcApplication2.Controllers
{
    public class ValuesController : ApiController
    {
        public IEnumerable<JobModel> Get()
        {
            var ctx = new PubsEntities();

            return
                ctx.jobs.ToList().Select(x => (JobModel) new JobModel().InjectFrom(x)).ToList();
        }
    }
}

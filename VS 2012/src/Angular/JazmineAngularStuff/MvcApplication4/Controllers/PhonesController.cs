using System.Collections.Generic;
using System.Threading;
using System.Web.Http;
using MvcApplication4.Data;
using MvcApplication4.Models.Phones;

namespace MvcApplication4.Controllers
{
    public class PhonesController : ApiController
    {
        private readonly IQueryRepository _queryRepository;

        public PhonesController(IQueryRepository queryRepository)
        {
            _queryRepository = queryRepository;
        }

        public IList<Phone> Get()
        {
            Thread.Sleep(3000);
            return _queryRepository.GetPhones();
        }
    }
}
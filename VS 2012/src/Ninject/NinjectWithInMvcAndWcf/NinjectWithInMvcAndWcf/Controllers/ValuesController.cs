using System.Collections.Generic;
using System.Web.Http;
using NinjectWithInMvcAndWcf.Models;
using Ploeh.AutoFixture;

namespace NinjectWithInMvcAndWcf.Controllers
{
    public class ValuesController : ApiController
    {
        public IList<Person> Get()
        {
            var fixture = new Fixture();

            return new[]
                {
                    fixture.Create<Person>(),
                    fixture.Create<Person>(),
                    fixture.Create<Person>()
                };
        }
    }
}
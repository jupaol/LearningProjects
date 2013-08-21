using System;
using System.Collections.Generic;
using System.Web.Http;
using NinjectWithInMvcAndWcf.Models;
using NinjectWithInMvcAndWcf.Services;
using Ploeh.AutoFixture;

namespace NinjectWithInMvcAndWcf.Controllers
{
    public class ValuesController : ApiController
    {
        private readonly IContextResolver _contextResolver;

        public ValuesController(IContextResolver contextResolver)
        {
            _contextResolver = contextResolver;
        }

        public IList<Person> Get()
        {
            if (_contextResolver == null)
            {
                throw new ArgumentNullException("_contextResolver");
            }

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
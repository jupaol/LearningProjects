using System.Collections.Generic;
using MvcApplication4.Models.Phones;
using Ploeh.AutoFixture;

namespace MvcApplication4.Data
{
    public class QueryRepository : IQueryRepository
    {
        private readonly IFixtureFactory _fixtureFactory;

        public QueryRepository(IFixtureFactory fixtureFactory)
        {
            _fixtureFactory = fixtureFactory;
        }

        public IList<Phone> GetPhones()
        {
            var fixture = _fixtureFactory.Create();

            var phones = new[]
                {
                    fixture.Create<Phone>(),
                    fixture.Create<Phone>(),
                    fixture.Create<Phone>(),
                    fixture.Create<Phone>(),
                    fixture.Create<Phone>()
                };

            foreach (var phone in phones)
            {
                phone.ImageUrl = "/Content/images/samsung-galaxy-tab.0.jpg";
            }

            return phones;
        }
    }
}
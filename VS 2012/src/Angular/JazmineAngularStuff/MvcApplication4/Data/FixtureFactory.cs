using Ploeh.AutoFixture;
using Ploeh.AutoFixture.AutoMoq;

namespace MvcApplication4.Data
{
    public class FixtureFactory : IFixtureFactory
    {
        public IFixture Create()
        {
            var fixture = new Fixture().Customize(new AutoMoqCustomization());

            return fixture;
        }
    }
}
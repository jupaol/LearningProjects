using Ploeh.AutoFixture;

namespace MvcApplication4.Data
{
    public interface IFixtureFactory
    {
        IFixture Create();
    }
}

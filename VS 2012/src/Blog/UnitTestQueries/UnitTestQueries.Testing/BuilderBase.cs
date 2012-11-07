using Moq;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.AutoMoq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestQueries.Testing
{
    public abstract class BuilderBase<TTarget>
    {
        public BuilderBase()
        {
            this.fixture = new Fixture().Customize(new AutoMoqCustomization());
            this.Mocks = new Dictionary<Type, object>();
        }

        public IFixture fixture { get; protected set; }
        public IDictionary<Type, object> Mocks { get; private set; }

        public virtual TTarget Build()
        {
            return this.fixture.CreateAnonymous<TTarget>();
        }

        protected Mock<TMock> AddMock<TMock>() where TMock : class
        {
            if (!this.Mocks.ContainsKey(typeof(TMock)))
            {
                var mock = this.fixture.Freeze<Mock<TMock>>();

                this.Mocks.Add(typeof(TMock), mock);

                return mock;
            }
            else
            {
                throw new InvalidOperationException("The specified key is already registered: " + typeof(TMock).ToString());
            }
        }

        protected Mock<TMock> GetMock<TMock>() where TMock : class
        {
            if (this.Mocks.ContainsKey(typeof(TMock)))
            {
                return (Mock<TMock>)this.Mocks[typeof(TMock)];
            }

            return null;
        }

        public static implicit operator TTarget(BuilderBase<TTarget> target)
        {
            return target.Build();
        }
    }
}

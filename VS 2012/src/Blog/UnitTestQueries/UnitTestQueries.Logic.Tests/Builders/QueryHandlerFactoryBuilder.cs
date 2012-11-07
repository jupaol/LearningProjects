using Microsoft.Practices.ServiceLocation;
using Moq;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.AutoMoq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestQueries.Data;
using UnitTestQueries.Testing;

namespace UnitTestQueries.Logic.Tests.Builders
{
    public class QueryHandlerFactoryBuilder : BuilderBase<QueryHandlerFactory>
    {
        private object queryHandler;

        public QueryHandlerFactoryBuilder()
        {
            this.AddMock<IServiceLocator>();
        }

        public QueryHandlerFactoryBuilder SetupServiceLocatorReturningAQueryHandlerObject<TQuery, TQueryResult>(
            IQueryHandler<TQuery, TQueryResult> result)
            where TQuery : IQuery
        {
            this.GetMock<IServiceLocator>().Setup(x => x.GetInstance<IQueryHandler<TQuery, TQueryResult>>())
                .Returns(result);

            return this;
        }

        public QueryHandlerFactoryBuilder SetupServiceLocatorReturningAQueryHandlerObjectWithAnonymous<TQuery, TQueryResult>()
            where TQuery : IQuery
        {
            this.queryHandler = this.fixture.CreateAnonymous<IQueryHandler<TQuery, TQueryResult>>();

            return this.SetupServiceLocatorReturningAQueryHandlerObject<TQuery, TQueryResult>(this.GetQueryHandler<TQuery, TQueryResult>());
        }

        public IQueryHandler<TQuery, TQueryResult> GetQueryHandler<TQuery, TQueryResult>()
            where TQuery : IQuery
        {
            var res = default(IQueryHandler<TQuery, TQueryResult>);

            if (this.queryHandler != null)
            {
                res = (IQueryHandler<TQuery, TQueryResult>)this.queryHandler;
            }

            return res;
        }
    }
}

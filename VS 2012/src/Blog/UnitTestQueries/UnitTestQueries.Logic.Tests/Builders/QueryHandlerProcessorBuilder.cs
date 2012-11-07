using Moq;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.AutoMoq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestQueries.Testing;

namespace UnitTestQueries.Logic.Tests.Builders
{
    public class QueryHandlerProcessorBuilder : BuilderBase<QueryHandlerProcessor>
    {
        private object queryResult;

        public QueryHandlerProcessorBuilder()
        {
            this.AddMock<IQueryHandlerFactory>();
        }

        public QueryHandlerProcessorBuilder SetupQueryHandlerFactoryMock<TQuery, TQueryResult>(
            IQueryHandler<TQuery, TQueryResult> result)
            where TQuery : IQuery
        {
            this.GetMock<IQueryHandlerFactory>().Setup(x => x.Create<TQuery, TQueryResult>()).Returns(result);
            return this;
        }

        public QueryHandlerProcessorBuilder SetupQueryHandlerFactoryMockWithConfiguredMock<TQuery, TQueryResult>()
            where TQuery : IQuery
        {
            var result = this.GetMock<IQueryHandler<TQuery, TQueryResult>>().Object;

            return this.SetupQueryHandlerFactoryMock<TQuery, TQueryResult>(result);
        }

        public QueryHandlerProcessorBuilder SetupQueryHandlerMock<TQuery, TQueryResult>(
            QueryResults<TQueryResult> result)
            where TQuery : IQuery
        {
            this.AddMock<IQueryHandler<TQuery, TQueryResult>>().Setup(x => x.HandleQuery(It.IsAny<TQuery>(), It.IsAny<PagingAndSortingInfo>()))
                .Returns(result);
            return this;
        }

        public QueryResults<TQueryResult> GetQueryResult<TQueryResult>()
        {
            var res = default(QueryResults<TQueryResult>);

            if (this.queryResult != null)
            {
                res = (QueryResults<TQueryResult>)this.queryResult;
            }

            return res;
        }

        public QueryHandlerProcessorBuilder SetupQueryHandlerMockWithAnonymous<TQuery, TQueryResult>()
            where TQuery : IQuery
        {
            this.queryResult = this.fixture.CreateAnonymous<QueryResults<TQueryResult>>();

            return this.SetupQueryHandlerMock<TQuery, TQueryResult>(this.GetQueryResult<TQueryResult>());
        }
    }
}

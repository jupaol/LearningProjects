using CuttingEdge.Conditions;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestQueries.Logic
{
    public class QueryHandlerFactory : IQueryHandlerFactory
    {
        private IServiceLocator serviceLocator;

        public QueryHandlerFactory(IServiceLocator serviceLocator)
        {
            this.serviceLocator = serviceLocator;
        }

        public IQueryHandler<TQuery, TQueryResult> Create<TQuery, TQueryResult>() where TQuery : IQuery
        {
            var instance = this.serviceLocator.GetInstance<IQueryHandler<TQuery, TQueryResult>>();
            Condition.Ensures(instance).IsNotNull();

            return instance;
        }
    }
}

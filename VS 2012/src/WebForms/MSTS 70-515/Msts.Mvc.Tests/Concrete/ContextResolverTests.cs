using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Msts.Mvc.Concrete;
using System.Configuration;
using Msts.Mvc.Tests.DataAccess;
using System.Linq;
using FluentAssertions;
using System.Threading;
using System.Data.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;
using Moq;
using CuttingEdge.Conditions;
using System.Collections.Concurrent;

namespace Msts.Mvc.Tests.Concrete
{
    [TestClass]
    public class ContextResolverTests
    {
        [TestClass]
        public class TheCreateContextInstanceMethod
        {
            [TestMethod]
            public void it_should_resolve_a_valid_instance()
            {
                ContextResolver sut = new ConcreteResolverBuilder().Initialize();
                var res = sut.GetCurrentContext<PubsContext>();

                res.Should().NotBeNull().And.BeOfType<PubsContext>();
            }

            [TestMethod]
            public void it_should_return_the_same_instance_even_when_calling_it_from_different_threads()
            {
                ContextResolver sut = new ConcreteResolverBuilder().Initialize();
                var firstResolvedContext = sut.GetCurrentContext<PubsContext>();
                var numberOfConcurrentProcess = 10000;
                var contextResolverInstances = new BlockingCollection<DbContext>();
                var tasks = new Task[numberOfConcurrentProcess];

                Console.WriteLine("Initial Thread ID: {0}", Thread.CurrentThread.ManagedThreadId);

                for (int i = 0; i < numberOfConcurrentProcess; i++)
                {
                    tasks[i] = Task.Factory.StartNew(() =>
                    {
                        var context = new ConcreteResolverBuilder().Initialize().Build().GetCurrentContext<PubsContext>();

                        contextResolverInstances.Add(context);

                        Console.WriteLine("Task - Thread ID: {0}", Thread.CurrentThread.ManagedThreadId);
                    }, TaskCreationOptions.LongRunning);
                }

                Task.WaitAll(tasks);

                contextResolverInstances
                    .Should()
                        .NotBeNull()
                    .And
                        .NotBeEmpty()
                    .And
                        .HaveCount(numberOfConcurrentProcess)
                    .And
                        .ContainItemsAssignableTo<DbContext>()
                    .And
                        .NotContainNulls();

                var firstResolvedContextHashCode = (firstResolvedContext as object).GetHashCode();

                firstResolvedContextHashCode.Should().NotBe(default(int));

                foreach (var item in contextResolverInstances)
                {
                    var itemHashCode = (item as object).GetHashCode();

                    itemHashCode.Should().NotBe(default(int));

                    itemHashCode.Should().Be(firstResolvedContextHashCode);
                    item.Should().Be(firstResolvedContext);

                    var areReferenceEquals = ReferenceEquals(item, firstResolvedContext);

                    areReferenceEquals.Should().BeTrue();
                }
            }
        }
    }

    public class ConcreteResolverBuilder
    {
        private ContextResolver Instance { get; set; }

        private static volatile HttpContextBase httpContextBase;
        private static volatile Dictionary<string, object> items;
        private static object syncRoot = new Object();

        public static HttpContextBase HttpContextBase
        {
            get
            {
                if (httpContextBase == null)
                {
                    lock (syncRoot)
                    {
                        if (httpContextBase == null)
                        {
                            var mock = new Mock<HttpContextBase>();

                            items = new Dictionary<string, object>();
                            mock.Setup(x => x.Items).Returns(items);

                            httpContextBase = mock.Object;
                        }
                    }
                }

                httpContextBase.Should().NotBeNull();
                return httpContextBase;
            }
        }

        public ConcreteResolverBuilder Initialize()
        {
            this.Instance = new ContextResolver(
                HttpContextBase,
                ConfigurationManager.ConnectionStrings["Msts"].ConnectionString);

            return this;
        }

        public ContextResolver Build()
        {
            this.Instance.Should().NotBeNull();
            return this.Instance;
        }

        public static implicit operator ContextResolver(ConcreteResolverBuilder builder)
        {
            return builder.Build();
        }
    }
}

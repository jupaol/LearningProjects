using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web;
using System.Collections.Generic;
using Moq;
using FluentAssertions;
using System.Linq;
using System.Configuration;
using System.Data.Entity;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.AutoMoq;

namespace UnitTestQueries.Data.Tests
{
    [TestClass]
    public class ContextManagerTests
    {
        [TestClass]
        public class TheGetCurrentContextMethod
        {
            [TestMethod]
            public void it_should_resolve_a_valid_instance_when_the_connection_string_is_not_specified()
            {
                ContextManager sut = new ContextManagerBuilder();
                var res = sut.GetCurrentContext<MoviesContext>();

                res.Should().NotBeNull().And.BeOfType<MoviesContext>();
            }

            [TestMethod]
            public void it_should_resolve_a_valid_instance_when_the_connection_string_is_specified()
            {
                ContextManager sut = new ContextManagerBuilder().SetConnectionString("some cnn");
                var res = sut.GetCurrentContext<MoviesContext>();

                res.Should().NotBeNull().And.BeOfType<MoviesContext>();
            }

            [TestMethod]
            public void it_should_return_the_same_instance_even_when_calling_it_from_different_threads()
            {
                ContextManager sut = new ContextManagerBuilder();
                var firstResolvedContext = sut.GetCurrentContext<MoviesContext>();
                var numberOfConcurrentProcess = 10000;
                var contextResolverInstances = new BlockingCollection<DbContext>();
                var tasks = new Task[numberOfConcurrentProcess];

                Console.WriteLine("Initial Thread ID: {0}", Thread.CurrentThread.ManagedThreadId);

                for (int i = 0; i < numberOfConcurrentProcess; i++)
                {
                    tasks[i] = Task.Factory.StartNew(() =>
                    {
                        var context = new ContextManagerBuilder().Build().GetCurrentContext<MoviesContext>();

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

        [TestClass]
        public class TheReleaseContextMethod
        {
            [TestMethod]
            public void it_should_not_throw_an_exception_if_the_current_context_is_null()
            {
                ContextManager sut = new ContextManagerBuilder();

                sut.Invoking(x => x.ReleaseContext()).ShouldNotThrow();
            }

            [TestMethod]
            public void it_should_dispose_the_current_context_when_it_is_not_null()
            {
                ContextManager sut = new ContextManagerBuilder();
                var initialContext = sut.GetCurrentContext<MoviesContext>();

                sut.Invoking(x => x.ReleaseContext()).ShouldNotThrow();

                Thread.Sleep(2000);

                initialContext.Invoking(x => x.GetValidationErrors())
                    .ShouldThrow<InvalidOperationException>()
                    .WithMessage("The operation cannot be completed because the DbContext has been disposed.", ComparisonMode.Exact);
            }
        }
    }

    public class ContextManagerBuilder
    {
        private ContextManager Instance { get; set; }
        private string connectionString;

        private static volatile HttpContextBase httpContextBase;
        private static volatile Dictionary<string, object> items;
        private static object syncRoot = new Object();

        public ContextManagerBuilder()
        {
            this.connectionString = string.Empty;
        }

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

        public ContextManagerBuilder SetConnectionString(string connectionString)
        {
            this.connectionString = connectionString;
            return this;
        }

        public ContextManager Build()
        {
            this.Instance = new ContextManager(
                HttpContextBase,
                this.connectionString);

            this.Instance.Should().NotBeNull();
            return this.Instance;
        }

        public static implicit operator ContextManager(ContextManagerBuilder builder)
        {
            return builder.Build();
        }
    }
}

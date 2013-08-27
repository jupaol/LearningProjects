using System;
using Ninject.Extensions.Logging;

namespace NLogBasic
{
    public class MyComponent : IMyComponent
    {
        private readonly ILogger _logger;

        public MyComponent(ILogger logger)
        {
            _logger = logger;
        }

        public string DoSomething()
        {
            _logger.Debug("Injected and from service");

            return DateTime.Now.ToString();
        }
    }
}
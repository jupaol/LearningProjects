using slf4net;

namespace NLogNinjectSlf.Services
{
    public class MyService : IMyService
    {
        private readonly ILogger _logger;

        public MyService(ILogger logger)
        {
            _logger = logger;
        }

        public void DoSomething()
        {
            _logger.Debug("Using NLog as the backend logger through the SLF abstraction and injected using Ninject");
        }
    }
}
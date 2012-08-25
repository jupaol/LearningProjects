using Bootstrap.Extensions.StartupTasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportsStore.UI.BootstrapInitialization.CustomStartupTasks
{
    [Task(DelayStartBy = 1000, PositionInSequence = 10)]
    public class RunMeFirst : IStartupTask
    {
        public void Reset()
        {
        }

        public void Run()
        {
        }
    }
}
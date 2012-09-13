using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportsStore.UI.BootstrapInitialization
{
    public class ForTesting : IForTesting
    {
        public string GetMessage()
        {
            return "Hello World";
        }
    }
}
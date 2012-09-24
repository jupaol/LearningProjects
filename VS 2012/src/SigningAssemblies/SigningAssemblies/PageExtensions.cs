using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;

namespace SigningAssemblies
{
    public static class PageExtensions
    {
        public static string GetDateTime(this Page page)
        {
            return DateTime.Now.ToString();
        }
    }
}

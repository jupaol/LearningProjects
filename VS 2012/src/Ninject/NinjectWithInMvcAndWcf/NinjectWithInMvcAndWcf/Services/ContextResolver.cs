using System;
using System.Web;

namespace NinjectWithInMvcAndWcf.Services
{
    public class ContextResolver : IContextResolver
    {
        private readonly HttpContextBase _httpContextBase;

        public ContextResolver(HttpContextBase httpContextBase)
        {
            _httpContextBase = httpContextBase;
        }

        public string Resolve()
        {
            if (_httpContextBase == null)
            {
                throw new ArgumentNullException("_httpContextBase");
            }

            return "Okas from resolver";
        }
    }
}
using System;
using System.Web;

namespace NinjectWithInMvcAndWcf.Services
{
    public class ContextResolver : IContextResolver
    {
        private readonly HttpContextBase _httpContext;

        public ContextResolver(HttpContextBase httpContext)
        {
            _httpContext = httpContext;
        }

        public string Resolve()
        {
            if (_httpContext == null)
            {
                throw new ArgumentNullException("_httpContextBase");
            }

            return "Okas from resolver";
        }
    }
}
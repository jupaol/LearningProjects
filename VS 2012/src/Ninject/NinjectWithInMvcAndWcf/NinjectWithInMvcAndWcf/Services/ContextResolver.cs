using System;
using System.Web;
using NinjectWithInMvcAndWcf.Data;

namespace NinjectWithInMvcAndWcf.Services
{
    public class ContextResolver : IContextResolver
    {
        private readonly HttpContextBase _httpContext;
        private readonly MyDataContext _myDataContext;

        public ContextResolver(HttpContextBase httpContext, MyDataContext myDataContext)
        {
            _httpContext = httpContext;
            _myDataContext = myDataContext;
        }

        public string Resolve()
        {
            if (_httpContext == null)
            {
                throw new ArgumentNullException("_httpContextBase");
            }

            if (_myDataContext == null)
            {
                throw new ArgumentNullException("_myDataContext");
            }

            return "Okas from resolver";
        }
    }
}
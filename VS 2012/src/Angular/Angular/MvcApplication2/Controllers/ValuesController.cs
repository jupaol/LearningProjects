using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using MvcApplication2.DataAccess;
using MvcApplication2.Models;
using Omu.ValueInjecter;

namespace MvcApplication2.Controllers
{
    public class ValuesController : ApiController
    {
        public IEnumerable<ProductModel> Get()
        {
            var ctx = new DeploymentConfigurationsEntities();

            return
                ctx.Products.ToList().Select(x => (ProductModel) new ProductModel().InjectFrom(x)).ToList();
        }
    }
}

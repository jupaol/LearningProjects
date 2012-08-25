using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStore.Domain.Concrete
{
    public class ProductRepository : IProductRepository
    {
        private EFDbContext context;

        public ProductRepository()
        {
            this.context = new EFDbContext();
        }

        public IQueryable<Entities.Product> GetProducts()
        {
            return this.context.Products;
        }
    }
}

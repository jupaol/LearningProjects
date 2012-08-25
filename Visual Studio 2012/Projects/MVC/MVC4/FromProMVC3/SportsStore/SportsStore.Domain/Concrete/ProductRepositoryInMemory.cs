using FizzWare.NBuilder;
using SportsStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStore.Domain.Concrete
{
    public class ProductRepositoryInMemory : IProductRepository
    {
        public IQueryable<Product> GetProducts()
        {
            return Builder<Product>.CreateListOfSize(10).Build().AsQueryable();
        }
    }
}

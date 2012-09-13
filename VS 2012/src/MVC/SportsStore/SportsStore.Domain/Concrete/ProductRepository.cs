using SportsStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Objects;
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

        public IQueryable<Product> GetProducts()
        {
            return this.context.Products;
        }

        public void UpdateProduct(Product product)
        {
            var exisitingProduct = this.GetProducts().FirstOrDefault(x => x.ProductID == product.ProductID);

            if (exisitingProduct == null)
            {
                throw new IndexOutOfRangeException("Product not found");
            }

            this.context.Entry(exisitingProduct).State = System.Data.EntityState.Detached;

            this.context.Entry(product).State = System.Data.EntityState.Modified;
            this.context.SaveChanges();
        }

        public void Delete(int productID)
        {
            var product = this.GetProducts().FirstOrDefault(x => x.ProductID == productID);

            if (product == null)
            {
                throw new IndexOutOfRangeException("Product not found");
            }

            this.context.Entry(product).State = System.Data.EntityState.Deleted;
            this.context.SaveChanges();
        }


        public void Add(Product product)
        {
            this.context.Products.Add(product);
            this.context.SaveChanges();
        }
    }
}

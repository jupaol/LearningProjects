using System;
using System.Data.Entity.Migrations;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ForeignKeys
{
    [TestClass]
    public class ForeignKeyTests
    {
        [TestMethod]
        public void it_should_map_a_foreign_key()
        {
            var ctx = new MyContext();

            ctx.Categories.ToList();
            ctx.Products.ToList();
        }

        [TestMethod]
        public void it_should_add_a_category_and_products()
        {
            var ctx = new MyContext();

            ctx.Categories.AddOrUpdate(x => x.Name ,new Category
                {
                    Name = "Electronics",
                    CategoryId = Guid.NewGuid()
                });

            ctx.SaveChanges();

            var category = ctx.Categories.First(x => x.Name.Equals("Electronics"));

            ctx.Products.Add(new Product
                {
                    Category = category,
                    Name = "Play Station 3",
                    ProductId = Guid.NewGuid()
                });
            ctx.Products.Add(new Product
                {
                    Category = category,
                    Name = "XBox 360",
                    ProductId = Guid.NewGuid()
                });

            ctx.SaveChanges();
        }

        [TestMethod]
        public void it_should_update_a_category()
        {
            var ctx = new MyContext();
            Category category;

            category = ctx.Categories.First(x => x.Name.Equals("Electronics"));
            category.Name = "Electronics1";
            ctx.SaveChanges();

            category = ctx.Categories.First(x => x.Name.Equals("Electronics1"));
            category.Name = "Electronics";
            ctx.SaveChanges();

            category = ctx.Categories.First(x => x.Name.Equals("Electronics"));
        }

        [TestMethod]
        [Ignore]
        public void it_should_update_a_product()
        {
            var ctx = new MyContext();
            const string productName = "XBox 360";
            Product product;

            product = ctx.Products.First(x => x.Name.Equals(productName));
            product.Name = string.Format("{0}1", productName);
            try
            {
                ctx.SaveChanges();
            }
            catch (Exception exception)
            {
                throw;
            }

            product = ctx.Products.First(x => x.Name.Equals(string.Format("{0}1", productName)));
            product.Name = productName;
            ctx.SaveChanges();

            product = ctx.Products.First(x => x.Name.Equals(productName));
        }
    }
}

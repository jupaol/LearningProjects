using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SportsStore.Domain.Entities;
using FizzWare.NBuilder;
using System.Linq;
using FluentAssertions;

namespace SportsStore.UnitTests.Domain
{
    [TestClass]
    public class CartTests
    {
        [TestClass]
        public class TheAddProductMethod
        {
            [TestMethod]
            public void can_add_a_new_product()
            {
                var sut = new Cart();
                var product = Builder<Product>.CreateNew()
                    .With(x => x.ProductID == 2)
                    .Build();

                sut.AddProduct(product, 23);

                sut.Lines.Should().HaveCount(1);
            }

            public void can_add_an_exiting_product()
            {
                var sut = new Cart();
                var product = Builder<Product>.CreateNew()
                    .With(x => x.ProductID == 2)
                    .Build();

                sut.AddProduct(product, 23);
                sut.AddProduct(product, 27);

                sut.Lines.Should().HaveCount(1);
                sut.Lines.First(x => x.Product.ProductID == 2).Quantity.Should().Be(30);
            }
        }

        [TestClass]
        public class TheRemoveProductMethod
        {
            [TestMethod]
            public void can_remove_an_item()
            {
                var sut = new Cart();
                var product = Builder<Product>.CreateNew().With(x => x.ProductID, 1).Build();

                sut.AddProduct(product, 5);
                sut.RemoveProduct(product);

                sut.Lines.Should().BeEmpty();
            }
        }

        [TestClass]
        public class TheClearMethod
        {
            [TestMethod]
            public void can_clear_all_existing_products()
            {
                var sut = new Cart();
                var product = Builder<Product>.CreateNew().With(x => x.ProductID, 2).Build();

                sut.AddProduct(product, 2);
                sut.Clear();

                sut.Lines.Should().BeEmpty();
            }
        }

        [TestClass]
        public class TheComputeTotalCostMethod
        {
            [TestMethod]
            public void can_calculate_cost_when_the_cart_is_empty()
            {
                var sut = new Cart();

                var res = sut.ComputeTotalCost();

                res.Should().Be(0);
            }

            [TestMethod]
            public void can_calculate_cost_when_the_cart_contains_products()
            {
                var sut = new Cart();
                var product = Builder<Product>.CreateListOfSize(3)
                    .TheFirst(1)
                        .With(x => x.Price, 23)
                    .TheNext(2)
                        .With(x => x.Price, 34)
                    .Build().ToList();

                product.ForEach(x => sut.AddProduct(x, 4));

                var res = sut.ComputeTotalCost();

                res.Should().Be(364);
            }
        }

        [TestClass]
        public class TheComputeSubTotalMethod
        {
            [TestMethod]
            public void can_calculate_the_subtotal_for_a_product()
            {
                var sut = new Cart();
                var product = Builder<Product>.CreateListOfSize(3)
                    .TheFirst(1)
                        .With(x => x.Price, 23)
                        .With(x => x.ProductID, 5)
                    .TheNext(2)
                        .With(x => x.Price, 34)
                    .Build().ToList();

                product.ForEach(x => sut.AddProduct(x, 4));

                var res = sut.ComputeSubTotal(5);

                res.Should().Be(92);
            }
        }
    }
}

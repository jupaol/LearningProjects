using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStore.Domain.Entities
{
    public class Cart
    {
        private List<CartLine> cartLines;

        public Cart()
        {
            this.cartLines = new List<CartLine>();
        }

        public IEnumerable<CartLine> Lines
        {
            get
            {
                return this.cartLines.AsEnumerable();
            }
        }

        public void AddProduct(Product product, int quentity)
        {
            var current = this.cartLines.FirstOrDefault(x => x.Product.ProductID == product.ProductID);

            if (current == null)
            {
                this.cartLines.Add(new CartLine { Product = product, Quantity = quentity });
            }
            else
            {
                current.Quantity += quentity;
            }
        }

        public void RemoveProduct(Product product)
        {
            this.cartLines.RemoveAll(x => x.Product.ProductID == product.ProductID);
        }

        public decimal ComputeSubTotal(int productID)
        {
            var line = this.cartLines.FirstOrDefault(x => x.Product.ProductID == productID);

            if (line == null)
            {
                return 0;
            }

            return line.Product.Price * line.Quantity;
        }

        public decimal ComputeTotalCost()
        {
            return this.cartLines.Sum(x => this.ComputeSubTotal(x.Product.ProductID));
        }

        public void Clear()
        {
            this.cartLines.Clear();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace tugas1.Models
{
    public class Cart
    {
        public string ProductId { set; get; }
        public int Qty { set; get; }
        public double SubTotal { set; get; }

        public Product GetProduct()
        {
            if(this.ProductId == "")
            {
                return new Product {
                    ProductId = "",
                    ProductName = "",
                    ProductPrice = 0,
                    ProductStock = 0
                };
            }
            Product product = new Product();
            return product.GetListProduct().Find(p => p.ProductId.Equals(this.ProductId));
        }
    }
}
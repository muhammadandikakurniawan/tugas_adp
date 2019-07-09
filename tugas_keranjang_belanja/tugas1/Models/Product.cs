using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace tugas1.Models
{
    public class Product
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public double ProductPrice { get; set; }
        public int ProductStock { get; set; }

        private List<Product> ListProduct =new List<Product>();
        
        public List<Product> GetListProduct()
        {
            this.ListProduct.Add(new Product { ProductId = "P01", ProductName = "Ram DDR4 2gb", ProductPrice = 800000, ProductStock = 20 });
            this.ListProduct.Add(new Product { ProductId = "P02", ProductName = "Hardisk Saegate 1Tb", ProductPrice = 2500000, ProductStock = 15 });
            this.ListProduct.Add(new Product { ProductId = "P03", ProductName = "AMD Richland A4-7300 ", ProductPrice = 500000, ProductStock = 30 });
            this.ListProduct.Add(new Product { ProductId = "P04", ProductName = "Ati Radeon R7 250 2GB GDDR5", ProductPrice = 900000, ProductStock = 10 });
            this.ListProduct.Add(new Product { ProductId = "P05", ProductName = "AMD A8", ProductPrice = 800000, ProductStock = 50 });

            this.ListProduct.Add(new Product { ProductId = "P06", ProductName = "Monitor Samsung CHG90", ProductPrice = 18000000, ProductStock = 10 });
            this.ListProduct.Add(new Product { ProductId = "P07", ProductName = "Keyboard Rexus Warfraction VR1", ProductPrice = 175000, ProductStock = 23 });
            this.ListProduct.Add(new Product { ProductId = "P08", ProductName = "LOGITECH Wireless Mouse B175  ", ProductPrice = 130000, ProductStock = 25 });
            this.ListProduct.Add(new Product { ProductId = "P09", ProductName = "Laptop ASUS ZenBook 13 UX331UAL", ProductPrice = 12000000, ProductStock = 14 });
            this.ListProduct.Add(new Product { ProductId = "P10", ProductName = "Motherboard Asus B150M-C D3 (LGA1151,B150, DDR3)", ProductPrice = 840000, ProductStock = 50 });

            return this.ListProduct;
        }
    }
}
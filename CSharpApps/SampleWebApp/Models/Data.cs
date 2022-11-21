using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleWebApp.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
    }

    public static class Database
    {
        public static List<Product> AllProducts { get; set; }

        static Database()
        {
            AllProducts = new List<Product>()
            {
                new Product{ ProductId = 111, ProductName="Adidas Shoes", Price = 4200, Quantity = 100 },
                new Product{ ProductId = 112, ProductName="Nike Mens Shoes", Price = 7200, Quantity = 100 },
                new Product{ ProductId = 113, ProductName="M&S Sweater", Price = 4200, Quantity = 10 },
                new Product{ ProductId = 114, ProductName="Sparx Shoes Mens", Price = 1200, Quantity = 10 },
                new Product{ ProductId = 115, ProductName="Cricket Bat", Price = 1200, Quantity = 50 },
                new Product{ ProductId = 116, ProductName="Cricket Ball Red", Price = 200, Quantity = 50 },
                new Product{ ProductId = 117, ProductName="Tennis Raquet", Price = 5000, Quantity = 50 },
                new Product{ ProductId = 118, ProductName="Tennis Ball", Price = 100, Quantity = 60 },
                new Product{ ProductId = 119, ProductName="TT Bat", Price = 400, Quantity = 70 },
                new Product{ ProductId = 120, ProductName="Badminton Raquet", Price = 6500, Quantity = 100 },
                new Product{ ProductId = 121, ProductName="Puma Football Shoes", Price = 4200, Quantity = 100 },
                new Product{ ProductId = 122, ProductName="Nike Cap", Price = 700, Quantity = 100 },
                new Product{ ProductId = 123, ProductName="M&S Jacket", Price = 7200, Quantity = 10 },
                new Product{ ProductId = 124, ProductName="Woodland Sandals Camel", Price = 3200, Quantity = 10 },
                new Product{ ProductId = 125, ProductName="WildCraft Laptop Bag", Price = 1200, Quantity = 50 },
                new Product{ ProductId = 126, ProductName="WildCraft Sling Bag", Price = 200, Quantity = 50 },
                new Product{ ProductId = 127, ProductName="Sparx Ladies Shoes", Price = 1000, Quantity = 50 },
                new Product{ ProductId = 128, ProductName="Bata Ladies Sandals", Price = 700, Quantity = 60 },
                new Product{ ProductId = 129, ProductName="Boat Ear Plugs", Price = 1400, Quantity = 70 },
                new Product{ ProductId = 130, ProductName="JBL Wireless Ear Plugs", Price = 6500, Quantity = 100 },
                new Product{ ProductId = 131, ProductName="Straplt Laptop Sleeve Case", Price = 360, Quantity = 50 },
                new Product{ ProductId = 132, ProductName="Asian Shoes Men", Price = 500, Quantity = 50 },
                new Product{ ProductId = 133, ProductName="Sako Keyboard Protector", Price = 240, Quantity = 60 },
                new Product{ ProductId = 134, ProductName="Protronics Optical Mouse", Price = 850, Quantity = 70 },
                new Product{ ProductId = 135, ProductName="Mens Socks", Price = 170, Quantity = 100 }
            };
        }
    }
}
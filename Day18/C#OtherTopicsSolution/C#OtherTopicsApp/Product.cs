using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_OtherTopicsApp
{
    internal class Product
    {
        public float Price { get; set; }
        public int Id{ get; set; }
        public string Name { get; set; }

        public static Product operator +(Product product1, Product product2)
        {
            Product product = new Product();
            product.Id = product1.Id ;
            product.Name = product1.Name + " " + product2.Name;
            product.Price = product1.Price + product2.Price;
            return product;
        }
        public override string ToString()
        {
            return "Id: " + Id + " Name: " + Name + " Price: $" + Price;
        }
    }
}

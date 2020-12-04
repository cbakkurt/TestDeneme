using System;
using System.Collections.Generic;
using System.Text;

namespace CicekSepeti.Domain.Entities
{
    public class Product
    {
        //public Product()
        //{

        //}
        //public Product(string name, int count, decimal price)
        //{
        //    Id = Guid.NewGuid();
        //    Name = name;
        //    Count = count;
        //    Price = price;
        //}
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
        public decimal Price { get; set; }

       
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace ONLINE_RESELLING_PLATFORM.Initialize
{
    public class Product
    {
        private static int _nextId = 1;
        public int Id { get; private set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public string Category { get; set; }
        public decimal OriginalPrice { get; set; }
        public decimal DiscountedPrice { get; set; }
        public string Description { get; set; }
        public string Owner { get; set; }
        public List<string> Reviews { get; set; } = new List<string>();
        public double Rating { get; set; } = 0;
    

        public Product(string name, string model, string category, decimal originalPrice, decimal discountedPrice, string description, string owner)
        {
            Id = _nextId++;
            Name = name;
            Model = model;
            Category = category;
            OriginalPrice = originalPrice;
            DiscountedPrice = discountedPrice;
            Description = description;
            Owner = owner;
        }
    }
}

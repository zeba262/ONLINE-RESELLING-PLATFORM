using System;
using System.Collections.Generic;
using System.Linq;
using ONLINE_RESELLING_PLATFORM.Initialize;
using ONLINE_RESELLING_PLATFORM.Interfaces;

namespace ONLINE_RESELLING_PLATFORM.ManageProduct
{
    public class ViewProducts : IUserAction
    {
        private List<Product> products;

        public ViewProducts(List<Product> products)
        {
            this.products = products;
        }

        public void Execute()
        {
            Console.WriteLine("\nAvailable Products:");
            foreach (var product in products)
            {
                Console.WriteLine($"PId:{product.Id}  ->  Product Name: {product.Name} , Model:{product.Model} , Category: {product.Category} , {product.DiscountedPrice}rs ,  Sold By: {product.Owner}");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

using ONLINE_RESELLING_PLATFORM.Initialize;
using ONLINE_RESELLING_PLATFORM.Interfaces;

namespace ONLINE_RESELLING_PLATFORM.ManageProduct
{
    public class UpdateProduct : IUserAction
    {
        private List<Product> products;

        public UpdateProduct(List<Product> products)
        {
            this.products = products;
        }

        public void Execute()
        {
            Console.Write("Enter Product ID to Update: ");
            int productId = Convert.ToInt32(Console.ReadLine());
            Product product = products.FirstOrDefault(p => p.Id == productId);
            if (product != null)
            {
                Console.Write("Enter New Product Name: ");
                product.Name = Console.ReadLine();
                Console.Write("Enter New Model: ");
                product.Model = Console.ReadLine();
                Console.Write("Enter New Category: ");
                product.Category = Console.ReadLine();
                Console.Write("Enter New Discounted Price: ");
                product.DiscountedPrice = Convert.ToDecimal(Console.ReadLine());
                Console.WriteLine("Product updated successfully!");
            }
            else
            {
                Console.WriteLine("\nProduct not found!");
            }
        }
    }
}

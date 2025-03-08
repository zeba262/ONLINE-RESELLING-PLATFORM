using System;
using System.Collections.Generic;
using System.Linq;

using ONLINE_RESELLING_PLATFORM.Initialize;
using ONLINE_RESELLING_PLATFORM.Interfaces;

namespace ONLINE_RESELLING_PLATFORM.ManageProduct
{
    public class AddProduct : IUserAction
    {
        private List<Product> products;
        private string sellerUsername; // Store seller's username

        public AddProduct(List<Product> products, string sellerUsername)
        {
            this.products = products;
            this.sellerUsername = sellerUsername;
        }
        public void Execute()
        {
            Console.Write("Enter Product Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Model: ");
            string model = Console.ReadLine();
            Console.Write("Enter Category: ");
            string category = Console.ReadLine();
            Console.Write("Enter Original Price (INR): ");
            decimal originalPrice = Convert.ToDecimal(Console.ReadLine());
            Console.Write("Enter Discounted Price (INR): ");
            decimal discountedPrice = Convert.ToDecimal(Console.ReadLine());
            Console.Write("Enter Description: ");
            string description = Console.ReadLine();

            products.Add(new Product(name, model, category, originalPrice, discountedPrice, description, sellerUsername));
            Console.WriteLine("\nProduct added successfully!");
        }
    }
}

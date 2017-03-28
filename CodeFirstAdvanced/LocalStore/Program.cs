using LocalStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalStore
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new LocalContext();

            //InitializeDatabaseAndAddProducts(context);

            LocalStoreImprovement(context);
            
        }

        private static void LocalStoreImprovement(LocalContext context)
        {
            context.Database.Initialize(true);

            var product1 = new Product()
            {
                Name = "Bread",
                DistributorName = "Dobrudja",
                Description = "Food used in everyday life.",
                Price = 0.99,
                Weight = 1,
                Quantity = 40
            };

            var product2 = new Product()
            {
                Name = "Zagorka",
                DistributorName = "Top Drinks",
                Description = "Beer",
                Price = 1.99,
                Weight = 0.5,
                Quantity = 20
            };

            var product3 = new Product()
            {
                Name = "Strawberries",
                DistributorName = "Green Day",
                Description = "Red delicious vegetables.",
                Price = 0.99,
                Weight = 0.3,
                Quantity = 65
            };
            context.Products.AddRange(new[] { product1, product2, product3 });
            context.SaveChanges();
        }

        private static void InitializeDatabaseAndAddProducts(LocalContext context)
        {
            context.Database.Initialize(true);

            var product1 = new Product()
            {
                Name = "Bread",
                DistributorName = "Dobrudja",
                Description = "Food used in everyday life.",
                Price = 0.99
            };

            var product2 = new Product()
            {
                Name = "Zagorka",
                DistributorName = "Top Drinks",
                Description = "Beer",
                Price = 1.99
            };

            var product3 = new Product()
            {
                Name = "Strawberries",
                DistributorName = "Green Day",
                Description = "Red delicious vegetables.",
                Price = 0.99
            };
            context.Products.AddRange(new[] { product1, product2, product3 });
            context.SaveChanges();
        }
    }
}

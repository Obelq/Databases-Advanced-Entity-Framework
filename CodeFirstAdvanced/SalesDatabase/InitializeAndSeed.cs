using SalesDatabase.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesDatabase
{
    public class InitializeAndSeed : DropCreateDatabaseAlways<SalesContext>
    {
        protected override void Seed(SalesContext context)
        {
            Customer customer1 = new Customer()
            {
                CreditCardNumber = "1234567",
                Email = "user@test.com",
                FirstName = "User",
                LastName = "Userov"
            };

            Customer customer2 = new Customer()
            {
                CreditCardNumber = "0123456",
                Email = "user2@test.com",
                FirstName = "User2",
                LastName = "Userov2"
            };

            Customer customer3 = new Customer()
            {
                CreditCardNumber = "11111",
                Email = "user3@test.com",
                FirstName = "User3",
                LastName = "Userov3"
            };

            Customer customer4 = new Customer()
            {
                CreditCardNumber = "4444",
                Email = "user4@test.com",
                FirstName = "User4",
                LastName = "Userov4"
            };

            Customer customer5 = new Customer()
            {
                CreditCardNumber = "5555",
                Email = "user5@test.com",
                FirstName = "User5",
                LastName = "Userov5"
            };
            context.Customers.Add(customer1);
            context.Customers.Add(customer2);
            context.Customers.Add(customer3);
            context.Customers.Add(customer4);
            context.Customers.Add(customer5);

            Product product1 = new Product()
            {
                Name = "Milk",
                Price = 10.00m,
                Quantity = 1
            };

            Product product2 = new Product()
            {
                Name = "Eggs",
                Price = 12.00m,
                Quantity = 12
            };

            Product product3 = new Product()
            {
                Name = "Salt",
                Price = 110.00m,
                Quantity = 1
            };

            Product product4 = new Product()
            {
                Name = "Ice",
                Price = 0.09m,
                Quantity = 11232
            };

            Product product5 = new Product()
            {
                Name = "Sugar",
                Price = 9.99m,
                Quantity = 1
            };

            context.Products.Add(product1);
            context.Products.Add(product2);
            context.Products.Add(product3);
            context.Products.Add(product4);
            context.Products.Add(product5);

            StoreLocation location1 = new StoreLocation()
            {
                LocationName = "Billa"
            };

            StoreLocation location2 = new StoreLocation()
            {
                LocationName = "Kaufland"
            };

            StoreLocation location3 = new StoreLocation()
            {
                LocationName = "FantastiKo"
            };

            StoreLocation location4 = new StoreLocation()
            {
                LocationName = "Lidle"
            };

            StoreLocation location5 = new StoreLocation()
            {
                LocationName = "Lelq Gosho"
            };

            context.StoreLocations.Add(location1);
            context.StoreLocations.Add(location2);
            context.StoreLocations.Add(location3);
            context.StoreLocations.Add(location4);
            context.StoreLocations.Add(location5);


            Sale sale1 = new Sale()
            {
                Customer = customer1,
                Date = new DateTime(2017, 03, 03),
                Product = product1,
                StoreLocation = location1
            };

            Sale sale2 = new Sale()
            {
                Customer = customer1,
                Date = new DateTime(2017, 03, 03),
                Product = product2,
                StoreLocation = location1
            };

            Sale sale3 = new Sale()
            {
                Customer = customer2,
                Date = new DateTime(2016, 03, 03),
                Product = product1,
                StoreLocation = location2
            };

            Sale sale4 = new Sale()
            {
                Customer = customer2,
                Date = new DateTime(2016, 03, 03),
                Product = product2,
                StoreLocation = location2
            };

            Sale sale5 = new Sale()
            {
                Customer = customer1,
                Date = new DateTime(2016, 03, 03),
                Product = product3,
                StoreLocation = location1
            };

            context.Sales.Add(sale1);
            context.Sales.Add(sale2);
            context.Sales.Add(sale3);
            context.Sales.Add(sale4);
            context.Sales.Add(sale5);

            context.SaveChanges();
            base.Seed(context);
        }
    }
}

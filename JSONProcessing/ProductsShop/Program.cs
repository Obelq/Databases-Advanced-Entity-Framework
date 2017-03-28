using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ProductsShop.Models;

namespace ProductsShop
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new ProductsContext();
            //context.Database.Initialize(true);

            //ImportUsers(context);
            //ImportProducts(context);
            //ImportCatgories(context);

            //ProductsInRange(context);

            //SuccessfullySoldProducts(context);

            //CategoriesByProductsCount(context);

            UsersAndProducts(context);

        }

        private static void UsersAndProducts(ProductsContext context)
        {
            var users = context.Users
                .Where(u => u.SoldProducts.Count >= 1)
                .Select(u => new
                {
                    firstName = u.FirstName,
                    lastName = u.LastName,
                    age = u.Age,
                    soldProducts = u.SoldProducts.Select(p => new
                    {
                        name = p.Name,
                        price = p.Price
                    })
                })
                .OrderByDescending(u => u.soldProducts.Count())
                .ThenBy(u => u.lastName);
            var usersAndCounter = new
            {
                usersCount = users.Count(),
                users = users
            };
            var usersJson = JsonConvert.SerializeObject(usersAndCounter, Formatting.Indented);
            File.WriteAllText(@"../../Results/usersAndCount.json", usersJson);
        }


        private static void CategoriesByProductsCount(ProductsContext context)
        {
            var categories = context.Categories
                .Select(c => new
                {
                    category = c.Name,
                    productsCount = c.Products.Count,
                    averagePrice = c.Products.Select(x => x.Price).DefaultIfEmpty(0).Average(),
                    totalRevenue = c.Products.Where(p => p.BuyerId != null).Select(x => x.Price).DefaultIfEmpty(0).Sum()
                })
                .OrderBy(c => c.category);
            var categoriesJson = JsonConvert.SerializeObject(categories, Formatting.Indented);
            Console.WriteLine(categoriesJson);
        }


        private static void SuccessfullySoldProducts(ProductsContext context)
        {
            var users = context.Users
                .Where(u => u.SoldProducts.Count >= 1)
                .Select(u => new
                {
                    firstName = u.FirstName,
                    lastName = u.LastName,
                    soldProducts = u.SoldProducts.Select(p => new
                    {
                        name = p.Name,
                        price = p.Price,
                        buyerFirstName = p.Buyer.FirstName,
                        buyerLastName = p.Buyer.LastName
                    })
                })
                .OrderBy(u => u.lastName)
                .ThenBy(u => u.firstName);
            var usersJSON = JsonConvert.SerializeObject(users, Formatting.Indented);
            Console.WriteLine(usersJSON);
        }

        private static void ProductsInRange(ProductsContext context)
        {
            var products = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .Select(p => new
                {
                    name = p.Name,
                    price = p.Price,
                    seller = string.Concat(p.Seller.FirstName, " ", p.Seller.LastName)
                }).OrderBy(p => p.price);
            var jsonProducts = JsonConvert.SerializeObject(products, Formatting.Indented);
            Console.WriteLine(jsonProducts);
        }

        private static void ImportCatgories(ProductsContext context)
        {
            string categoriesJson = File.ReadAllText("../../Import/categories.json");
            var categories = JsonConvert.DeserializeObject<List<Category>>(categoriesJson);

            int number = 0;
            int productCount = context.Products.Count();
            foreach (var c in categories)
            {
                int categoryProductsCount = number % 3 + 1;
                for (int i = 0; i < number % categoryProductsCount; i++)
                {
                    c.Products.Add(context.Products.Find((number % productCount) + 1));
                }
                number++;
            }
            context.Categories.AddRange(categories);
            context.SaveChanges();
        }

        private static void ImportProducts(ProductsContext context)
        {
            string productsJson = File.ReadAllText("../../Import/products.json");
            List<Product> products =
                JsonConvert.DeserializeObject<List<Product>>(productsJson);


            int number = 0;
            int totalUsers = context.Users.Count();
            foreach (var p in products)
            {
                p.SellerId = number % totalUsers + 1;
                if (number % 3 != 0)
                {
                    p.BuyerId = (number * 2 % totalUsers) + 1;
                }
                number++;
            }
            context.Products.AddRange(products);
            context.SaveChanges();
        }

        private static void ImportUsers(ProductsContext context)
        {
            string usersJson = File.ReadAllText("../../Import/users.json");
            List<User> users =
                JsonConvert.DeserializeObject<List<User>>(usersJson);
            context.Users.AddRange(users);
            context.SaveChanges();
        }
    }
}

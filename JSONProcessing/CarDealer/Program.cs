using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarDealer.Models;
using Newtonsoft.Json;

namespace CarDealer
{
    class Program
    {
        public static Random random = new Random();
        static void Main(string[] args)
        {
            var context = new CarDealerContext();

            //context.Database.Initialize(true);

            //ImportSuppliers(context);
            //ImportParts(context);
            //ImportCars(context);
            //ImportCustomers(context);

            //OrderedCustomers(context);

            //CarsFromToyota(context);

            //LocalSuppliers(context);

            //CarsWithTheirParts(context);

            //TotalSalesByCustomer(context);

            SalesWithAppliedDiscount(context);

        }

        private static void SalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context.Sales
                .Select(s => new
                {
                    car = new
                    {
                        s.Car.Make,
                        s.Car.Model,
                        s.Car.TravelledDistance
                    },
                    customerName = s.Customer.Name,
                    discount = s.DiscountPercentage,
                    price = s.Car.Parts.Select(p => p.Price).Sum(),
                    priceWithDiscount =
                    (1 - s.DiscountPercentage / 100.0) * (double) s.Car.Parts.Select(p => p.Price).Sum()
                });
            var salesJson = JsonConvert.SerializeObject(sales, Formatting.Indented);
            File.WriteAllText("../../Results/salesWithAppliedDiscount.json", salesJson);
        }

        private static void TotalSalesByCustomer(CarDealerContext context)
        {
            var customers = context.Customers
                .Where(c => c.Sales.Count >= 1)
                .Select(c => new
                {
                    fullName = c.Name,
                    boughtCars = c.Sales.Count,
                    spentMoney = c.Sales
                    .Select(s => s.Car.Parts
                    .Select(p => (double)p.Price).Sum() * (1 - s.DiscountPercentage / 100.0)).Sum()
                })
                .OrderByDescending(c => c.spentMoney)
                .ThenByDescending(c => c.boughtCars);
            var customersJson = JsonConvert.SerializeObject(customers, Formatting.Indented);
            File.WriteAllText("../../Results/totalSalesByCustomer.json", customersJson);
        }

        private static void CarsWithTheirParts(CarDealerContext context)
        {
            var cars = context.Cars
                .Select(c => new
                {
                    c.Make,
                    c.Model,
                    c.TravelledDistance,
                    Parts = c.Parts.Select(p => new
                    {
                        p.Name,
                        p.Price
                    })
                });
            var carsJson = JsonConvert.SerializeObject(cars, Formatting.Indented);
            File.WriteAllText("../../Results/carsParts.json", carsJson);
        }

        private static void LocalSuppliers(CarDealerContext context)
        {
            var suppliers = context.Suppliers
                .Where(s => s.IsImporter == false)
                .Select(s => new
                {
                    s.Id,
                    s.Name,
                    PartsCount = s.Parts.Count
                });
            var suppliersJson = JsonConvert.SerializeObject(suppliers, Formatting.Indented);
            File.WriteAllText("../../Results/localSuppliers.json", suppliersJson);
        }

        private static void CarsFromToyota(CarDealerContext context)
        {
            var cars = context.Cars
                .Select(c => new
                {
                    c.Id,
                    c.Make,
                    c.Model,
                    c.TravelledDistance
                })
                .Where(c => c.Make == "Toyota")
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance);
            var carsJson = JsonConvert.SerializeObject(cars, Formatting.Indented);

            File.WriteAllText("../../Results/toyotaCars.json", carsJson);
        }

        private static void OrderedCustomers(CarDealerContext context)
        {
            var customers = context.Customers
                .Select(c => new
                {
                    c.Id,
                    c.Name,
                    c.BirthDate,
                    c.IsYoungDriver,
                    Sales = c.Sales.Select(s => new
                    {
                        Make = s.Car.Make,
                        Model = s.Car.Model,
                        TravelledDistance = s.Car.TravelledDistance
                    })
                })
            .OrderBy(c => c.BirthDate)
            .ThenBy(c => c.IsYoungDriver);
            var customersJson = JsonConvert.SerializeObject(customers, Formatting.Indented);
            Console.WriteLine(customersJson);
        }

        private static void ImportCustomers(CarDealerContext context)
        {
            var customersJson = File.ReadAllText("../../Import/customers.json");
            var customers = JsonConvert.DeserializeObject<List<Customer>>(customersJson);

            context.Customers.AddRange(customers);
            context.SaveChanges();

            var sales = new List<Sale>();
            var discounts = new int[] { 0, 5, 10, 15, 20, 30, 40, 50 };
            var customersCount = context.Customers.Count();
            var carsCount = context.Cars.Count();

            for (int i = 0; i < 360 + random.Next(1, 400); i++)
            {
                var sale = new Sale()
                {
                    Customer = context.Customers.Find(random.Next(1, customersCount + 1)),
                    Car = context.Cars.Find(random.Next(1, carsCount + 1)),
                    DiscountPercentage = discounts[random.Next(0, discounts.Length)]
                };
                sales.Add(sale);
            }
            context.Sales.AddRange(sales);
            context.SaveChanges();

        }

        private static void ImportCars(CarDealerContext context)
        {
            var carsJson = File.ReadAllText("../../Import/cars.json");
            var cars = JsonConvert.DeserializeObject<List<Car>>(carsJson);
            var partsCount = context.Parts.Count();
            foreach (var car in cars)
            {
                var alreadyAdded = new List<int>();
                for (int i = 0; i < 10 + random.Next(1, 11); i++)
                {
                    var currentId = random.Next(1, partsCount + 1);

                    if (!alreadyAdded.Contains(currentId))
                    {
                        alreadyAdded.Add(currentId);
                        car.Parts.Add(context.Parts.Find(currentId));
                    }
                }
            }


            context.Cars.AddRange(cars);
            context.SaveChanges();
        }

        private static void ImportParts(CarDealerContext context)
        {
            var partsJson = File.ReadAllText("../../Import/parts.json");
            var parts = JsonConvert.DeserializeObject<List<Part>>(partsJson);

            var suppliersCount = context.Suppliers.Count();
            foreach (var part in parts)
            {
                part.Supplier = context.Suppliers.Find(random.Next(1, suppliersCount + 1));
            }
            context.Parts.AddRange(parts);
            context.SaveChanges();
        }

        private static void ImportSuppliers(CarDealerContext context)
        {
            var suppliersJson = File.ReadAllText("../../Import/suppliers.json");
            var suppliers = JsonConvert.DeserializeObject<List<Supplier>>(suppliersJson);
            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();
        }
    }
}

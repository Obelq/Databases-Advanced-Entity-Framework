using CarDealer.Models;

namespace CarDealer
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class CarDealerContext : DbContext
    {
        
        public CarDealerContext()
            : base("name=CarDealerContext")
        {
            //Database.SetInitializer(new DropCreateDatabaseAlways<CarDealerContext>());
        }

        
        public virtual DbSet<Supplier> Suppliers { get; set; }

        public virtual DbSet<Car> Cars { get; set; }

        public virtual DbSet<Part> Parts { get; set; }

        public virtual DbSet<Sale> Sales { get; set; }

        public virtual DbSet<Customer> Customers { get; set; }
    }

    
}
namespace LocalStore
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class LocalContext : DbContext
    {
        // Your context has been configured to use a 'LocalContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'LocalStore.LocalContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'LocalContext' 
        // connection string in the application configuration file.
        public LocalContext()
            : base("name=LocalContext")
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<LocalContext>());
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Product> Products { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}
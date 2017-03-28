using ProductsShop.Models;

namespace ProductsShop
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class ProductsContext : DbContext
    {
        
        public ProductsContext()
            : base("name=ProductsContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasKey(u => u.Id)
                .Property(u => u.LastName).IsRequired();
            modelBuilder.Entity<Product>()
                .HasOptional(p => p.Buyer)
                .WithMany(b => b.BoughtProducts);
            modelBuilder.Entity<Product>()
                .HasRequired(p => p.Seller)
                .WithMany(b => b.SoldProducts);
            modelBuilder.Entity<User>()
                .HasMany(s => s.Friends)
                .WithMany()
                .Map(uf =>
                {
                    uf.ToTable("UserFriends");
                    uf.MapLeftKey("UserId");
                    uf.MapRightKey("FriendId");
                });
            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Category> Categories { get; set; }
        
    }
    

    
}
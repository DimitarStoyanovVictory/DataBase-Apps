using System.Data.Entity;
using ProductsShop.Data.Migrations;
using ProductsShop.Models;

namespace ProductsShop.Data
{
    public class ProductShopDbContext : DbContext
    {
        public ProductShopDbContext()
            : base("ProductShopDbContext")
        {
            Database.SetInitializer(new 
                MigrateDatabaseToLatestVersion<ProductShopDbContext, Configuration>());
        }

        public DbSet<Product> Prodcuts { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasOptional(x => x.Seller)
                .WithMany()
                .Map(m =>
                {
                    m.MapKey("BuyerId");
                })
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
               .HasRequired(x => x.Buyer)
               .WithMany()
               .Map(m =>
               {
                   m.MapKey("SellerId");
               })
               .WillCascadeOnDelete(false);

            modelBuilder.Entity<Category>().HasMany(c => c.Products).WithMany().Map(m =>
            {
                m.MapLeftKey("Category_Id");
                m.MapRightKey("Product_Id");
                m.ToTable("CategoryProducts");
            });

            modelBuilder.Entity<User>().HasMany(u => u.Friedns).WithMany().Map(m =>
            {
                m.MapLeftKey("UserId");
                m.MapRightKey("ParoductId");
                m.ToTable("UserFriends");
            });
        }
    }
}
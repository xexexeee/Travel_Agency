using Microsoft.EntityFrameworkCore;
using OnlineStore.Storage.MS_SQL.DataBase.Interfaces;
using OnlineStore.Storage.MS_SQL.Entities;

namespace OnlineStore.Storage.MS_SQL
{
    public class Context : DbContext, IContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Cart> Carts{ get; set; }
        public DbSet<RouteEntity> RouteEntities { get; set; }
        public DbSet<CartToProduct> CartToProducts{ get; set; }
        //public DbSet<ProductToSales> ProductToSales { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<RouteEntity>()
            //    .HasData
            //    (
            //    new RouteEntity() { searchText = "Главная", controllerName = "Index", route = "" }

            //    );

            modelBuilder.Entity<Cart>()
                .HasMany(c => c.Products)
                .WithMany()
                .UsingEntity<CartToProduct>();
                //.UsingEntity(с => с.ToTable("CartToProducts");

            modelBuilder.Entity<Cart>()
                .HasOne(c => c.Client);

            modelBuilder.Entity<Client>()
                .HasMany(c => c.Sales)
                .WithOne(Sale => Sale.Client)
                .HasForeignKey(Sale => Sale.ClientId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ProductType>()
                .HasMany(p => p.Products)
                .WithOne(p => p.ProductType)
                .HasForeignKey(p => p.ProductTypeId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Sale>()
                .HasMany(s => s.Products)
                .WithMany(p => p.Sales)
                .UsingEntity(j => j.ToTable("ProductsToSales"));
        }

    }
}

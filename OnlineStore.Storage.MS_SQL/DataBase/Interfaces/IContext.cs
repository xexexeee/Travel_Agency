using Microsoft.EntityFrameworkCore;
using OnlineStore.Storage.MS_SQL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Storage.MS_SQL.DataBase.Interfaces
{
    public interface IContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<RouteEntity> RouteEntities { get; set; }
        public DbSet<CartToProduct> CartToProducts { get; set; }


        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        
    }
}

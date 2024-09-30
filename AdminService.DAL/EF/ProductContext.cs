using AdminService.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace AdminService.DAL.EF
{
    public class ProductContext : DbContext
    {
        public DbSet<ProductOrder> productOrders { get; set; } = null!;
        public DbSet<ClientOrder> clientOrders { get; set; } = null!;
        public DbSet<ClientData> clientsData { get; set; } = null!;
        public ProductContext(DbContextOptions<ProductContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductOrderConfig());
            modelBuilder.ApplyConfiguration(new ClientOrderConfig());
            modelBuilder.ApplyConfiguration(new ClientDataConfig());

            base.OnModelCreating(modelBuilder);
        }
    }
}

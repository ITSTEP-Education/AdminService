using AdminService.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace AdminService.DAL.EF
{
    public class ProductContext : DbContext
    {
        public DbSet<ProductOrder> productOrders { get; set; } = null!;

        public ProductContext(DbContextOptions<ProductContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductOrderConfig());
            base.OnModelCreating(modelBuilder);
        }
    }
}

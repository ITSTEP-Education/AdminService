using AdminService.DAL.EF;
using AdminService.DAL.Entities;
using AdminService.DAL.Interfaces;

namespace AdminService.DAL.Repositories
{
    public class ProductOrderRepository : IRepository<ProductOrder>
    {
        public ProductContext context;

        public ProductOrderRepository(ProductContext context)
        {
            this.context = context;
        }

        public IEnumerable<ProductOrder>? getAllItems() => context.productOrders;

    }
}

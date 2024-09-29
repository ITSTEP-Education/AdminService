using AdminService.DAL.EF;
using AdminService.DAL.Entities;
using AdminService.DAL.Infrastructures;
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

        public void deleteItem(string guid)
        {  
            ProductOrder? productOrder = this.context.productOrders.FirstOrDefault(o => o.guid.Equals(guid));
            if (productOrder == null) throw new StatusCode404("productorders");

            this.context.productOrders.Remove(productOrder);
        }
    }
}

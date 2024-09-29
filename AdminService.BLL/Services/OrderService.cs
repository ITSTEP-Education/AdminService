using AdminService.BLL.Infrastructures;
using AdminService.BLL.Interfaces;
using AdminService.DAL.Entities;
using AdminService.DAL.Interfaces;

namespace AdminService.BLL.Services
{
    public class OrderService : IOrderService
    {
        public IUnitOfWork db { get; }

        public OrderService(IUnitOfWork db)
        {
            this.db = db;
        }

        public IEnumerable<ProductOrder> getAllOrders()
        {
            var orders = db.productOrders.getAllItems();
            if (orders == null) throw new AdminServiceException("absent in db table", "productorders");
            else if (orders.Count() == 0) throw new AdminServiceException("absent in any records", "productorders");

            return orders;
        }

        public void Dispose()
        {
            db?.Dispose();
        }
    }
}

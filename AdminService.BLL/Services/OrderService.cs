using AdminService.BLL.Infrastructures;
using AdminService.BLL.Interfaces;
using AdminService.DAL.Entities;
using AdminService.DAL.Infrastructures;
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
            var productOrders = db.productOrders.getAllItems();

            if (productOrders == null || productOrders.Count() == 0) throw new StatusCode404("productorders");

            return productOrders;
        }

        public void deleteOrder(string guid)
        {
            if (guid == null || guid == string.Empty) throw new ArgumentNullException(nameof(guid));

            db.productOrders.deleteItem(guid);
            db.Save();
        }

        public void Dispose()
        {
            db?.Dispose();
        }
    }
}

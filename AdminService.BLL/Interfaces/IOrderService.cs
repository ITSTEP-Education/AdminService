using AdminService.DAL.Entities;
using AdminService.DAL.Interfaces;

namespace AdminService.BLL.Interfaces
{
    public interface IOrderService
    {
        IUnitOfWork db { get; }

        IEnumerable<ProductOrder> getAllOrders();

        ProductOrder getProductOrder(string? guid);

        void deleteOrder(string guid);

        void Dispose();
    }
}

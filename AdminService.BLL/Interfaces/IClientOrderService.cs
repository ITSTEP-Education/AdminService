using AdminService.DAL.Entities;
using AdminService.DAL.Interfaces;

namespace AdminService.BLL.Interfaces
{
    public interface IClientOrderService
    {
        IUnitOfWork db { get; }

        void addClientOrder(ClientOrder? clientOrder);

        void Dispose();
    }
}

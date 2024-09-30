using AdminService.BLL.Interfaces;
using AdminService.DAL.Entities;
using AdminService.DAL.Interfaces;

namespace AdminService.BLL.Services
{
    public class ClientOrderService : IClientOrderService
    {
        public IUnitOfWork db { get; }

        public ClientOrderService(IUnitOfWork db)
        {
            this.db = db;
        }

        public void addClientOrder(ClientOrder? clientOrder)
        {
            if (clientOrder == null)
            {
                throw new ArgumentNullException(nameof(clientOrder));
            }

            db.clientOrders.addItem(clientOrder);

            db.Save();
        }

        public void Dispose()
        {
            db?.Dispose();
        }
    }
}

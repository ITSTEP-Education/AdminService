using AdminService.DAL.Entities;

namespace AdminService.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        public IRepository<ProductOrder> productOrders { get; }
        public IRepository<ClientData> clientsData { get; }
        public IRepository<ClientOrder> clientOrders { get; }

        public void Save();
    }
}

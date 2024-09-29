using AdminService.DAL.Entities;

namespace AdminService.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        public IRepository<ProductOrder> productOrders { get; }

        public void Save();
    }
}

using AdminService.DAL.EF;
using AdminService.DAL.Entities;
using AdminService.DAL.Interfaces;

namespace AdminService.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private ProductContext context;
        private ProductOrderRepository productOrderRepository = null!;
        private ClientDataRepository clientDataRepository = null!;

        private bool disposed = false;

        public UnitOfWork(ProductContext context)
        {
            this.context = context;
        }

        public IRepository<ProductOrder> productOrders
        {
            get
            {
                if (productOrderRepository == null)
                    productOrderRepository = new ProductOrderRepository(context);
                return productOrderRepository;
            }
        }

        public IRepository<ClientData> clientsData
        {
            get
            {
                if (clientDataRepository == null)
                    clientDataRepository = new ClientDataRepository(context);
                return clientDataRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

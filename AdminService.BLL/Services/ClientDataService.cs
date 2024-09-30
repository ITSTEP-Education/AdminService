using AdminService.BLL.Interfaces;
using AdminService.DAL.Entities;
using AdminService.DAL.Interfaces;

namespace AdminService.BLL.Services
{
    public class ClientDataService : IClientDataService
    {
        public IUnitOfWork db { get; }

        public ClientDataService(IUnitOfWork db)
        {
            this.db = db;
        }

        public ClientData getClientData(string? name)
        {
            if (name == null || name == string.Empty) throw new ArgumentNullException(nameof(name));

            return db.clientsData.getItem(name);
        }

        public void addClientData(ClientData? clientData)
        {
            if (clientData == null){
                throw new ArgumentNullException(nameof(clientData));
            }

            db.clientsData.addItem(clientData);
            //db.Save();
        }

        public void deleteClientData(string? name)
        {
            if (name == null || name == string.Empty) throw new ArgumentNullException(nameof(name));

            db.clientsData.deleteItem(name);
            db.Save();
        }

        public void Dispose()
        {
            db?.Dispose();
        }
    }
}

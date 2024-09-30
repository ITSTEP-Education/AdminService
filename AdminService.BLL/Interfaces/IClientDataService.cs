using AdminService.DAL.Entities;
using AdminService.DAL.Interfaces;

namespace AdminService.BLL.Interfaces
{
    public interface IClientDataService
    {
        IUnitOfWork db { get; }

        ClientData getClientData(string? name);

        void addClientData(ClientData? clientData);

        void deleteClientData(string? name);

        void Dispose();
    }
}

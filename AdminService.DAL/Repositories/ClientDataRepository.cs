using AdminService.DAL.EF;
using AdminService.DAL.Entities;
using AdminService.DAL.Infrastructures;
using AdminService.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AdminService.DAL.Repositories
{
    public class ClientDataRepository : IRepository<ClientData>
    {
        public ProductContext context;

        public ClientDataRepository(ProductContext context)
        {
            this.context = context;
        }

        public IEnumerable<ClientData>? getAllItems() 
        { 
            throw new NotImplementedException("blank method of IRepository<ClientData>");
        }

        public ClientData getItem(string name)
        {
            (string firstName, string lastName) = getFirstLastName(name);

            ClientData? clientData = this.context.clientsData.FirstOrDefault(cd => (cd.firstName.Equals(firstName) && cd.lastName.Equals(lastName)));
            if (clientData == null) throw new StatusCode404(name);

            return clientData;
        }

        public void deleteItem(string name)
        {
            (string firstName, string lastName) = getFirstLastName(name);

            var clientData = this.context.clientsData.FirstOrDefault(cd => (cd.firstName.Equals(firstName) && cd.lastName.Equals(lastName)));
            if (clientData == null) throw new StatusCode404(name);

            this.context.clientsData.Remove(clientData);
        }

        private (string, string) getFirstLastName(string name)
        {
            var names = name.ToLower().Split('-');

            if(names.Length != 2) throw new StatusCode400(name);

            return (names[0], names[1]);
        }
    }
}

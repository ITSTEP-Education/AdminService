using AdminService.DAL.EF;
using AdminService.DAL.Entities;
using AdminService.DAL.Infrastructures;
using AdminService.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminService.DAL.Repositories
{
    public class ClientDataRepository : IRepository<ClientData>
    {
        public ProductContext context;

        public ClientDataRepository(ProductContext context)
        {
            this.context = context;
        }

        public IEnumerable<ClientData>? getAllItems() { 
            throw new NotImplementedException("blank method of IRepository<ClientData>");
        }

        public void deleteItem(string name)
        {
            ClientData? clientData = this.context.clientsData.FirstOrDefault(o => o.firstName.Equals(name));
            if (clientData == null) throw new StatusCode404(name);

            this.context.clientsData.Remove(clientData);
        }
    }
}

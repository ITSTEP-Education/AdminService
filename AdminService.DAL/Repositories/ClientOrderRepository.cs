using AdminService.DAL.EF;
using AdminService.DAL.Entities;
using AdminService.DAL.Infrastructures;
using AdminService.DAL.Interfaces;
using System;
using System.Collections.Generic;

namespace AdminService.DAL.Repositories
{
    public class ClientOrderRepository : IRepository<ClientOrder>
    {
        public ProductContext context;

        public ClientOrderRepository(ProductContext context)
        {
            this.context = context;
        }

        public IEnumerable<ClientOrder>? getAllItems(){
            throw new NotImplementedException("blank method of IRepository<ClientOrder>");
        }

        public ClientOrder getItem(string name)
        {
            throw new NotImplementedException("blank method of IRepository<ClientOrder>");
        }

        public void addItem(ClientOrder clientOrder) => this.context.clientOrders.Add(clientOrder);

        public void deleteItem(string name)
        {
            throw new NotImplementedException("blank method of IRepository<ClientOrder>");
        }
    }
}

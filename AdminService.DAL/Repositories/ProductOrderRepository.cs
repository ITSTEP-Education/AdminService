﻿using AdminService.DAL.EF;
using AdminService.DAL.Entities;
using AdminService.DAL.Infrastructures;
using AdminService.DAL.Interfaces;
using Microsoft.Identity.Client;

namespace AdminService.DAL.Repositories
{
    public class ProductOrderRepository : IRepository<ProductOrder>
    {
        public ProductContext context;

        public ProductOrderRepository(ProductContext context)
        {
            this.context = context;
        }

        public IEnumerable<ProductOrder>? getAllItems() => context.productOrders;

        public ProductOrder getItem(string guid)
        {
            ProductOrder? productOrder = this.context.productOrders.FirstOrDefault(cd => (cd.guid.Equals(guid)));
            if (productOrder == null) throw new StatusCode404(guid);

            return productOrder;
        }

        public void addItem(ProductOrder productOrder)
        {
            throw new NotImplementedException("blank method of IRepository<ProductOrder>");
        }

        public void deleteItem(string guid)
        {  
            ProductOrder? productOrder = this.context.productOrders.FirstOrDefault(o => o.guid.Equals(guid));
            if (productOrder == null) throw new StatusCode404(guid);

            this.context.productOrders.Remove(productOrder);
        }
    }
}

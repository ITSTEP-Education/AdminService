using AdminService.DAL.Entities;
using AdminService.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminService.BLL.Interfaces
{
    public interface IClientDataService
    {
        IUnitOfWork db { get; }

        void deleteClient(string name);

        void Dispose();
    }
}

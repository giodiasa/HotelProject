using HotelProject.Models;
using HotelProject.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.Repository
{
    public class ManagerRepositoryEF : IManagerRepository
    {
        public Task AddManager(Manager manager)
        {
            throw new NotImplementedException();
        }

        public Task DeleteManager(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Manager>> GetManagers()
        {
            throw new NotImplementedException();
        }

        public Task<Manager> GetSingleManager(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateManager(Manager manager)
        {
            throw new NotImplementedException();
        }
    }
}

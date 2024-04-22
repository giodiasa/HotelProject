using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.Repository.Interfaces
{
    public interface IFullyUpdatable <T> where T : class
    {
        Task<T> Update(T entity);
    }
}

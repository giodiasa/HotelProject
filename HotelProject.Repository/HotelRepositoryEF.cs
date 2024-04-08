using HotelProject.Models;
using HotelProject.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.Repository
{
    public class HotelRepositoryEF : IHotelRepository
    {
        public Task AddHotel(Hotel hotel)
        {
            throw new NotImplementedException();
        }

        public Task DeleteHotel(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Hotel>> GetHotels()
        {
            throw new NotImplementedException();
        }

        public Task<List<Hotel>> GetHotelsWithoutManager()
        {
            throw new NotImplementedException();
        }

        public Task<Hotel> GetSingleHotel(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateHotel(Hotel hotel)
        {
            throw new NotImplementedException();
        }
    }
}

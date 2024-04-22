using HotelProject.Data;
using HotelProject.Models;
using HotelProject.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.Repository
{
    public class HotelRepositoryEF : RepositoryBase<Hotel>, IHotelRepository
    {
        private readonly ApplicationDbContext _context;
        public HotelRepositoryEF(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Hotel> Update(Hotel entity)
        {
            var entityFromDb = await _context.Hotels.FirstOrDefaultAsync(x => x.Id == entity.Id);

            if (entityFromDb == null)
            {
                throw new InvalidOperationException("Entity not found");
            }
            else
            {
                entityFromDb.Name = entity.Name;
                entityFromDb.Rating = entity.Rating;
                entityFromDb.Country = entity.Country;
                entityFromDb.City = entity.City;
                entityFromDb.PhysicalAddress = entity.PhysicalAddress;

            }

            _context.Hotels.Update(entityFromDb);
            return entityFromDb;
        }
    }
}

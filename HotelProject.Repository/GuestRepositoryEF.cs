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
    public class GuestRepositoryEF : RepositoryBase<Guest>, IGuestRepository
    {
        private readonly ApplicationDbContext _context;
        public GuestRepositoryEF(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Guest> Update(Guest guest)
        {
            if (guest == null || guest.Id <= 0)
            {
                throw new ArgumentNullException("Invalid argument passed");
            }

            var entity = await _context.Guests.FirstOrDefaultAsync(x => x.Id == guest.Id);

            if (entity == null)
            {
                throw new NullReferenceException("Entity not found");
            }

            entity.FirstName = guest.FirstName;
            entity.LastName = guest.LastName;
            entity.PhoneNumber = guest.PhoneNumber;
            entity.PersonalNumber = guest.PersonalNumber;

            _context.Guests.Update(entity);
            return entity;
        }
    }
}

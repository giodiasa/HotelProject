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
    public class GuestReservationRepositoryEF : RepositoryBase<GuestReservation>, IGuestReservationRepository
    {
        private readonly ApplicationDbContext _context;
        public GuestReservationRepositoryEF(ApplicationDbContext context) : base (context)
        {
            _context = context;
        }

        public async Task<GuestReservation> Update(GuestReservation guestReservation)
        {
            if (guestReservation == null || guestReservation.Id <= 0)
            {
                throw new ArgumentNullException("Invalid argument passed");
            }

            var entity = await _context.GuestReservations.FirstOrDefaultAsync(x => x.Id == guestReservation.Id);

            if (entity == null)
            {
                throw new NullReferenceException("Entity not found");
            }

            entity.ReservationId = guestReservation.ReservationId;
            entity.GuestId = guestReservation.GuestId;

            _context.GuestReservations.Update(entity);
            return entity;
        }
    }
}

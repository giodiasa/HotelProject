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
    public class ReservationRepositoryEF : RepositoryBase<Reservation>, IReservationRepository
    {
        private readonly ApplicationDbContext _context;
        public ReservationRepositoryEF(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
       
        public async Task<Reservation> Update(Reservation reservation)
        {
            if (reservation == null || reservation.Id <= 0)
            {
                throw new ArgumentNullException("Invalid argument passed");
            }

            var entity = await _context.Reservations.FirstOrDefaultAsync(x => x.Id == reservation.Id);

            if (entity == null)
            {
                throw new NullReferenceException("Entity not found");
            }

            entity.CheckInDate = reservation.CheckInDate;
            entity.CheckOutDate = reservation.CheckOutDate;

            _context.Reservations.Update(entity);
            return entity;
        }
    }
}

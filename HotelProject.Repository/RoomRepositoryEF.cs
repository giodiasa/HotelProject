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
    public class RoomRepositoryEF : RepositoryBase<Room>, IRoomRepository
    {
        private readonly ApplicationDbContext _context;

        public RoomRepositoryEF(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Room> Update(Room room)
        {
            if (room == null || room.Id <= 0)
            {
                throw new ArgumentNullException("Invalid argument passed");
            }

            var entity = await _context.Rooms.FirstOrDefaultAsync(x => x.Id == room.Id);

            if (entity == null)
            {
                throw new NullReferenceException("Entity not found");
            }

            entity.Name = room.Name;
            entity.DailyPrice = room.DailyPrice;
            entity.IsFree = room.IsFree;
            entity.HotelId = room.HotelId;

            _context.Rooms.Update(entity);
            return entity;
        }
    }
}

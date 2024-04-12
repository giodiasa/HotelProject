﻿using HotelProject.Data;
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
    public class RoomRepositoryEF : IRoomRepository
    {
        private readonly ApplicationDbContext _context;

        public RoomRepositoryEF(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddRoom(Room room)
        {
            if(room == null)
            {
                throw new ArgumentNullException("Invalid argument passed");
            }
            await _context.Rooms.AddAsync(room);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRoom(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentNullException("Invalid argument passed");
            }
            var entity = await _context.Rooms.FirstOrDefaultAsync(x => x.Id == id);

            if (entity == null)
            {
                throw new NullReferenceException("Entity not found");
            }

            _context.Rooms.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Room>> GetRooms()
        {
            var entities = await _context.Rooms.ToListAsync();

            if (entities == null)
            {
                throw new NullReferenceException("Entities not found");
            }

            return entities;
        }

        public async Task<Room> GetSingleRoom(int id)
        {
            var entity = await _context.Rooms.FirstOrDefaultAsync(x => x.Id == id);

            if (entity == null)
            {
                throw new NullReferenceException("Entity not found");
            }

            return entity;
        }

        public async Task UpdateRoom(Room room)
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
            await _context.SaveChangesAsync();
        }
    }
}

using HotelProject.Models;
using HotelProject.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.tests
{
    public class RoomShould
    {
        private readonly RoomRepository _roomRepository;
        public RoomShould()
        {
            _roomRepository = new();
        }
        [Fact]
        public async void Return_All_Rooms_From_Database()
        {
            var result = await _roomRepository.GetRooms();
        }

        [Fact]
        public async void Add_New_Room_In_Database()
        {
            Room newRoom = new()
            {
                Name = "Standard Room",
                IsFree = true,
                HotelId = 6,
                DailyPrice = 150
            };

            await _roomRepository.AddRoom(newRoom);
        }

        [Fact]
        public async void Update_Room_In_Database()
        {
            Room updatedRoom = new()
            {
                Id = 1,
                Name = "Standard Room",
                IsFree = true,
                HotelId = 13,
                DailyPrice = 180
            };

            await _roomRepository.UpdateRoom(updatedRoom);
        }

        [Fact]
        public async void Delete_Room_from_Database()
        {
            int id = 3;

            await _roomRepository.DeleteRoom(id);
        }
    }
}

﻿using HotelProject.Models;
using HotelProject.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.tests
{
    public class HotelShould
    {
        private readonly HotelRepository _hotelRepository;
        public HotelShould()
        {
            _hotelRepository = new();
        }
        [Fact]
        public async void Return_All_Hotels_From_Database()
        {
            var result = await _hotelRepository.GetHotels();
        }

        [Fact]
        public async void Add_New_Hotel_In_Database()
        {
            Hotel newHotel = new()
            {
                Name = "Radisson",
                Rating = 8.7,
                Country = "Georgia",
                City = "Tbilisi",
                PhysicalAddress = "1 Rose Revolution Square",
                ManagerId = 4
            };

            await _hotelRepository.AddHotel(newHotel);
        }

        [Fact]
        public async void Update_Hotel_In_Database()
        {
            Hotel updatedHotel = new()
            {
                Id = 11,
                Name = "Stamba",
                Rating = 8.9,
                Country = "Georgia",
                City = "Tbilisi",
                PhysicalAddress = "14, 0108 Merab Kostava St",
                ManagerId = 12
            };

            await _hotelRepository.UpdateHotel(updatedHotel);
        }

        [Fact]
        public async void Delete_Hotel_from_Database()
        {
            int id = 11;

            await _hotelRepository.DeleteHotel(id);
        }
    }
}

using HotelProject.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace HotelProject.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hotel>().HasData(
                new Hotel() 
                {
                    Id = 1,
                    Name = "პირველი სასტუმრო",
                    Country = "საქართველო",
                    City = "თბილისი",
                    PhysicalAddress = "რუსთაველის 4",
                    Rating = 10.0
                },
                new Hotel()
                {
                    Id = 2,
                    Name = "მეორე სასტუმრო",
                    Country = "საქართველო",
                    City = "თბილისი",
                    PhysicalAddress = "პეკინის 13",
                    Rating = 8.0
                },
                new Hotel()
                {
                    Id = 3,
                    Name = "მესამე სასტუმრო",
                    Country = "საქართველო",
                    City = "ბათუმი",
                    PhysicalAddress = "გამსახურდიას 12",
                    Rating = 7.7
                }
                );

            modelBuilder.Entity<Manager>().HasData(
                    new Manager()
                    {
                        Id = 1,
                        HotelId = 1,
                        FirstName = "გიორგი",
                        LastName = "გიორგაძე"
                    },
                    new Manager()
                    {
                        Id = 2,
                        HotelId = 2,
                        FirstName = "თამაზი",
                        LastName = "გოდერძიშვილი"
                    },
                    new Manager()
                    {
                        Id = 3,
                        HotelId = 3,
                        FirstName = "გოირგი",
                        LastName = "გუჯარელიძე"
                    }
                );

            modelBuilder.Entity<Room>().HasData(
                    new Room() { Id = 1, Name = "A-100", IsFree = false, HotelId = 1, DailyPrice = 50 },
                    new Room() { Id = 2, Name = "A-200", IsFree = false, HotelId = 1, DailyPrice = 50 },
                    new Room() { Id = 3, Name = "A-300", IsFree = true, HotelId = 1, DailyPrice = 50 },
                    new Room() { Id = 4, Name = "B-100", IsFree = true, HotelId = 1, DailyPrice = 100 },
                    new Room() { Id = 5, Name = "B-200", IsFree = false, HotelId = 1, DailyPrice = 100 },
                    new Room() { Id = 6, Name = "B-300", IsFree = false, HotelId = 1, DailyPrice = 100 },
                    new Room() { Id = 7, Name = "C-100", IsFree = true, HotelId = 1, DailyPrice = 200 },
                    new Room() { Id = 8, Name = "C-200", IsFree = false, HotelId = 1, DailyPrice = 200 },
                    new Room() { Id = 9, Name = "C-300", IsFree = false, HotelId = 1, DailyPrice = 200 },
                    new Room() { Id = 10, Name = "100", IsFree = true, HotelId = 2, DailyPrice = 25 },
                    new Room() { Id = 11, Name = "101", IsFree = true, HotelId = 2, DailyPrice = 25 },
                    new Room() { Id = 12, Name = "102", IsFree = false, HotelId = 2, DailyPrice = 25 },
                    new Room() { Id = 13, Name = "200", IsFree = true, HotelId = 2, DailyPrice = 50 },
                    new Room() { Id = 14, Name = "201", IsFree = false, HotelId = 2, DailyPrice = 50 },
                    new Room() { Id = 15, Name = "202", IsFree = false, HotelId = 2, DailyPrice = 50 },
                    new Room() { Id = 16, Name = "300", IsFree = true, HotelId = 2, DailyPrice = 75 },
                    new Room() { Id = 17, Name = "301", IsFree = true, HotelId = 2, DailyPrice = 75 },
                    new Room() { Id = 18, Name = "302", IsFree = true, HotelId = 2, DailyPrice = 75 },
                    new Room() { Id = 19, Name = "A-10", IsFree = false, HotelId = 3, DailyPrice = 150 },
                    new Room() { Id = 20, Name = "A-20", IsFree = true, HotelId = 3, DailyPrice = 150 },
                    new Room() { Id = 21, Name = "A-30", IsFree = true, HotelId = 3, DailyPrice = 150 },
                    new Room() { Id = 22, Name = "B-10", IsFree = false, HotelId = 3, DailyPrice = 150 },
                    new Room() { Id = 23, Name = "B-20", IsFree = false, HotelId = 3, DailyPrice = 150 },
                    new Room() { Id = 24, Name = "B-30", IsFree = true, HotelId = 3, DailyPrice = 150 },
                    new Room() { Id = 25, Name = "C-10", IsFree = true, HotelId = 3, DailyPrice = 150 },
                    new Room() { Id = 26, Name = "C-20", IsFree = false, HotelId = 3, DailyPrice = 150 },
                    new Room() { Id = 27, Name = "C-30", IsFree = true, HotelId = 3, DailyPrice = 150 }
                );
        }

        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public static string ConnectionString { get; } = "Server=LAPTOP-6UBPTAP2;Database=DOITHotel_BCTFO;Trusted_Connection=True;TrustServerCertificate=True";
    }
}


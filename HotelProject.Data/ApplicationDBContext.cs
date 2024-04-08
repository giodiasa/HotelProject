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

        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public static string ConnectionString { get; } = "Server=LAPTOP-6UBPTAP2;Database=DOITHotel_BCTFO;Trusted_Connection=True;TrustServerCertificate=True";
    }
}


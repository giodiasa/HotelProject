using HotelProject.Data;
using HotelProject.Repository.Interfaces;
using HotelProject.Repository;
using Microsoft.EntityFrameworkCore;
using HotelProject.Repository.MicrosoftDataSQLClient;

namespace HotelProject.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("SQLServerLocalConnection")));

            builder.Services.AddScoped<IHotelRepository, HotelRepositoryEF>();
            builder.Services.AddScoped<IManagerRepository, ManagerRepositoryEF>();
            builder.Services.AddScoped<IRoomRepository, RoomRepositoryEF>();

            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}

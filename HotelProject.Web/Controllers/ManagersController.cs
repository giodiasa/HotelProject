using HotelProject.Models;
using HotelProject.Repository;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.Web.Controllers
{
    public class ManagersController : Controller
    {
        private readonly ManagerRepository _managerRepository;
        private readonly HotelRepository _hotelRepository;
        public ManagersController()
        {
            _managerRepository = new ManagerRepository();
            _hotelRepository = new HotelRepository();
        }
        public async Task<IActionResult> Index()
        {
            var result = await _managerRepository.GetManagers();
            var hotels = await _hotelRepository.GetHotels();
            ViewBag.HotelNames = hotels.ToDictionary(h => h.Id, h => h.Name);
            return View(result);
        }
    }
}

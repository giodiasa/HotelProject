using HotelProject.Repository;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.Web.Controllers
{
    public class RoomsController : Controller
    {
        private readonly RoomRepository _roomRepository;
        private readonly HotelRepository _hotelRepository;
        public RoomsController()
        {
            _roomRepository = new RoomRepository();
            _hotelRepository = new HotelRepository();
        }
        public async Task<IActionResult> Index()
        {
            var result = await _roomRepository.GetRooms();
            var hotels = await _hotelRepository.GetHotels();
            ViewBag.HotelNames = hotels.ToDictionary(h => h.Id, h => h.Name);
            return View(result);
        }
    }
}

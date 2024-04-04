using HotelProject.Models;
using HotelProject.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HotelProject.Web.Controllers
{
    public class RoomsController : Controller
    {
        private readonly RoomRepository _roomRepository;
        private readonly HotelRepository _hotelRepository;
        public RoomsController(RoomRepository roomRepository, HotelRepository hotelRepository)
        {
            _roomRepository = roomRepository;
            _hotelRepository = hotelRepository;
        }
        public async Task<IActionResult> Index()
        {
            var result = await _roomRepository.GetRooms();
            var hotels = await _hotelRepository.GetHotels();
            ViewBag.HotelNames = hotels.ToDictionary(h => h.Id, h => h.Name);
            return View(result);
        }

        public async Task<IActionResult> Create()
        {
            var hotels = await _hotelRepository.GetHotels();
            ViewBag.Hotels = hotels.Select(h => new SelectListItem
            {
                Value = h.Id.ToString(),
                Text = h.Name
            }).ToList();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Room room)
        {
            await _roomRepository.AddRoom(room);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var result = await _roomRepository.GetSingleRoom(id);
            return View(result);
        }


        [HttpPost]
        public async Task<IActionResult> DeletePOST(int id)
        {
            await _roomRepository.DeleteRoom(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int id)
        {
            var hotels = await _hotelRepository.GetHotels();
            ViewBag.Hotels = hotels.Select(h => new SelectListItem
            {
                Value = h.Id.ToString(),
                Text = h.Name
            }).ToList();
            var result = await _roomRepository.GetSingleRoom(id);
            return View(result);
        }


        [HttpPost]
        public async Task<IActionResult> UpdatePOST(Room model)
        {
            await _roomRepository.UpdateRoom(model);
            return RedirectToAction("Index");
        }
    }
}

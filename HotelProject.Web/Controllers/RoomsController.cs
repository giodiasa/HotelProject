using HotelProject.Data;
using HotelProject.Models;
using HotelProject.Repository.Interfaces;
using HotelProject.Repository.MicrosoftDataSQLClient;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HotelProject.Web.Controllers
{
    public class RoomsController : Controller
    {
        private readonly IRoomRepository _roomRepository;
        private readonly IHotelRepository _hotelRepository;
        private readonly ApplicationDbContext _context;
        public RoomsController(IRoomRepository roomRepository, IHotelRepository hotelRepository, ApplicationDbContext context)
        {
            _roomRepository = roomRepository;
            _hotelRepository = hotelRepository;
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var result = await _roomRepository.GetAllAsync("Hotel");
            return View(result);
        }

        public async Task<IActionResult> Create()
        {
            var hotels = await _hotelRepository.GetAllAsync();
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
            if(ModelState.IsValid)
            {
                await _roomRepository.CreateAsync(room);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            var hotels = await _hotelRepository.GetAllAsync();
            ViewBag.Hotels = hotels.Select(h => new SelectListItem
            {
                Value = h.Id.ToString(),
                Text = h.Name
            }).ToList();
            return View(room);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var result = await _roomRepository.GetAsync(x => x.Id == id);
            return View(result);
        }


        [HttpPost]
        public async Task<IActionResult> DeletePOST(int id)
        {
            var result = await _roomRepository.GetAsync(x => x.Id == id);
            _roomRepository.Delete(result);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int id)
        {
            var hotels = await _hotelRepository.GetAllAsync();
            ViewBag.Hotels = hotels.Select(h => new SelectListItem
            {
                Value = h.Id.ToString(),
                Text = h.Name
            }).ToList();
            var result = await _roomRepository.GetAsync(x => x.Id == id);
            return View(result);
        }


        [HttpPost]
        public async Task<IActionResult> Update(Room model)
        {
            if(ModelState.IsValid)
            {
                await _roomRepository.Update(model);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            var hotels = await _hotelRepository.GetAllAsync();
            ViewBag.Hotels = hotels.Select(h => new SelectListItem
            {
                Value = h.Id.ToString(),
                Text = h.Name
            }).ToList();
            return View(model);
        }
    }
}

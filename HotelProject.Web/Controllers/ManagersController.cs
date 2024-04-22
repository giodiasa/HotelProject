using HotelProject.Data;
using HotelProject.Models;
using HotelProject.Repository.Interfaces;
using HotelProject.Repository.MicrosoftDataSQLClient;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HotelProject.Web.Controllers
{
    public class ManagersController : Controller
    {
        private readonly IManagerRepository _managerRepository;
        private readonly IHotelRepository _hotelRepository;
        private readonly ApplicationDbContext _context;
        public ManagersController(IManagerRepository managerRepository, IHotelRepository hotelRepository, ApplicationDbContext context)
        {
            _managerRepository = managerRepository;
            _hotelRepository = hotelRepository;
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var result = await _managerRepository.GetAllAsync("Hotel");
            var hotels = await _hotelRepository.GetAllAsync();
            ViewBag.HotelNames = hotels.ToDictionary(h => h.Id, h => h.Name);
            return View(result);
        }
        public async Task<IActionResult> Create()
        {
            var hotelsWithoutManager = await _hotelRepository.GetAllAsync(x=> x.Manager == null);
            ViewBag.HotelsWithoutManager = hotelsWithoutManager.Select(h => new SelectListItem
            {
                Value = h.Id.ToString(),
                Text = h.Name
            }).ToList();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Manager manager)
        {
            if (ModelState.IsValid)
            {
                await _managerRepository.CreateAsync(manager);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            var hotelsWithoutManager = await _hotelRepository.GetAllAsync(x => x.Manager == null);
            ViewBag.HotelsWithoutManager = hotelsWithoutManager.Select(h => new SelectListItem
            {
                Value = h.Id.ToString(),
                Text = h.Name
            }).ToList();
            return View(manager);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var hotels = await _hotelRepository.GetAllAsync();
            ViewBag.HotelNames = hotels.ToDictionary(h => h.Id, h => h.Name);
            var result = await _managerRepository.GetAsync(x => x.Id == id);
            return View(result);
        }


        [HttpPost]
        public async Task<IActionResult> DeletePOST(int id)
        {
            var result = await _managerRepository.GetAsync(x => x.Id == id, "Hotel");
            _managerRepository.Delete(result);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int id)
        {
            var result = await _managerRepository.GetAsync(x => x.Id == id, "Hotel");
            var hotelsWithoutManager = await _hotelRepository.GetAllAsync(x => x.Manager == null);
            var currentHotel = await _hotelRepository.GetAsync(x => x.Id == result.HotelId);
            hotelsWithoutManager.Add(currentHotel);
            ViewBag.HotelsWithoutManager = hotelsWithoutManager.Select(h => new SelectListItem
            {
                Value = h.Id.ToString(),
                Text = h.Name
            }).ToList();
            return View(result);
        }


        [HttpPost]
        public async Task<IActionResult> Update(Manager model)
        {
            if (ModelState.IsValid)
            {
                await _managerRepository.Update(model);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            var result = await _managerRepository.GetAsync(x => x.Id == model.Id, "Hotel");
            var hotelsWithoutManager = await _hotelRepository.GetAllAsync(x => x.Manager == null);
            var currentHotel = await _hotelRepository.GetAsync(x => x.Id == result.HotelId);
            hotelsWithoutManager.Add(currentHotel);
            ViewBag.HotelsWithoutManager = hotelsWithoutManager.Select(h => new SelectListItem
            {
                Value = h.Id.ToString(),
                Text = h.Name
            }).ToList();
            return View(model);
        }
    }
}

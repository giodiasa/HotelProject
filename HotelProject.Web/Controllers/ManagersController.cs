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
        public ManagersController(IManagerRepository managerRepository, IHotelRepository hotelRepository)
        {
            _managerRepository = managerRepository;
            _hotelRepository = hotelRepository;
        }
        public async Task<IActionResult> Index()
        {
            var result = await _managerRepository.GetManagers();
            var hotels = await _hotelRepository.GetHotels();
            ViewBag.HotelNames = hotels.ToDictionary(h => h.Id, h => h.Name);
            return View(result);
        }
        public async Task<IActionResult> Create()
        {
            var hotelsWithoutManager = await _hotelRepository.GetHotelsWithoutManager();
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
                await _managerRepository.AddManager(manager);
                return RedirectToAction("Index");
            }
            var hotelsWithoutManager = await _hotelRepository.GetHotelsWithoutManager();
            ViewBag.HotelsWithoutManager = hotelsWithoutManager.Select(h => new SelectListItem
            {
                Value = h.Id.ToString(),
                Text = h.Name
            }).ToList();
            return View(manager);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var hotels = await _hotelRepository.GetHotels();
            ViewBag.HotelNames = hotels.ToDictionary(h => h.Id, h => h.Name);
            var result = await _managerRepository.GetSingleManager(id);
            return View(result);
        }


        [HttpPost]
        public async Task<IActionResult> DeletePOST(int id)
        {
            await _managerRepository.DeleteManager(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int id)
        {
            var result = await _managerRepository.GetSingleManager(id);
            var hotelsWithoutManager = await _hotelRepository.GetHotelsWithoutManager();
            var currentHotel = await _hotelRepository.GetSingleHotel(result.HotelId);
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
                await _managerRepository.UpdateManager(model);
                return RedirectToAction("Index");
            }
            var result = await _managerRepository.GetSingleManager(model.Id);
            var hotelsWithoutManager = await _hotelRepository.GetHotelsWithoutManager();
            var currentHotel = await _hotelRepository.GetSingleHotel(result.HotelId);
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

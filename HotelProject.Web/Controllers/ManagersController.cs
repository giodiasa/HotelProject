using HotelProject.Models;
using HotelProject.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HotelProject.Web.Controllers
{
    public class ManagersController : Controller
    {
        private readonly ManagerRepository _managerRepository;
        private readonly HotelRepository _hotelRepository;
        public ManagersController(ManagerRepository managerRepository, HotelRepository hotelRepository)
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
            await _managerRepository.AddManager(manager);
            return RedirectToAction("Index");
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
            var hotelsWithoutManager = await _hotelRepository.GetHotelsWithoutManager();
            ViewBag.HotelsWithoutManager = hotelsWithoutManager.Select(h => new SelectListItem
            {
                Value = h.Id.ToString(),
                Text = h.Name
            }).ToList();
            var result = await _managerRepository.GetSingleManager(id);
            return View(result);
        }


        [HttpPost]
        public async Task<IActionResult> UpdatePOST(Manager model)
        {
            await _managerRepository.UpdateManager(model);
            return RedirectToAction("Index");
        }
    }
}

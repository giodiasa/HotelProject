﻿using HotelProject.Models;
using HotelProject.Repository.Interfaces;
using HotelProject.Repository.MicrosoftDataSQLClient;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HotelProject.Web.Controllers
{
    public class HotelsController : Controller
    {
        private readonly IHotelRepository _hotelRepository;
        public HotelsController(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }
        public async Task<IActionResult> Index()
        {
            var result = await _hotelRepository.GetHotels();
            return View(result);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Hotel model)
        {
            if(ModelState.IsValid)
            {
                await _hotelRepository.AddHotel(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }


        public async Task<IActionResult> Delete(int id)
        {
            var result = await _hotelRepository.GetSingleHotel(id);
            return View(result);
        }


        [HttpPost]
        public async Task<IActionResult> DeletePOST(int id)
        {
            await _hotelRepository.DeleteHotel(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int id)
        {
            var result = await _hotelRepository.GetSingleHotel(id);
            return View(result);
        }


        [HttpPost]
        public async Task<IActionResult> Update(Hotel model)
        {
            if (ModelState.IsValid)
            {
                await _hotelRepository.UpdateHotel(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}

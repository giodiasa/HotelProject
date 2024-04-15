﻿using HotelProject.Models;
using HotelProject.Repository.Interfaces;
using HotelProject.Repository.MicrosoftDataSQLClient;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.Web.Controllers
{
    public class GuestsController : Controller
    {
        private readonly IGuestRepository _guestRepository;
        public GuestsController(IGuestRepository guestRepository)
        {
            _guestRepository = guestRepository;
        }
        public async Task<IActionResult> Index()
        {
            var result = await _guestRepository.GetGuests();
            return View(result);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Guest model)
        {
            if (ModelState.IsValid)
            {
                await _guestRepository.AddGuest(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }


        public async Task<IActionResult> Delete(int id)
        {
            var result = await _guestRepository.GetSingleGuest(id);
            return View(result);
        }


        [HttpPost]
        public async Task<IActionResult> DeletePOST(int id)
        {
            await _guestRepository.DeleteGuest(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int id)
        {
            var result = await _guestRepository.GetSingleGuest(id);
            return View(result);
        }


        [HttpPost]
        public async Task<IActionResult> Update(Guest model)
        {
            if (ModelState.IsValid)
            {
                await _guestRepository.UpdateGuest(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}

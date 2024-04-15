using HotelProject.Models;
using HotelProject.Repository.Interfaces;
using HotelProject.Repository.MicrosoftDataSQLClient;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HotelProject.Web.Controllers
{
    public class GuestReservationsController : Controller
    {
        private readonly IGuestReservationRepository _guestReservationRepository;
        private readonly IGuestRepository _guestRepository;
        private readonly IReservationRepository _reservationRepository;
        public GuestReservationsController(IGuestReservationRepository guestReservationRepository, IGuestRepository guestRepository, IReservationRepository reservationRepository)
        {
            _guestReservationRepository = guestReservationRepository;
            _guestRepository = guestRepository;
            _reservationRepository = reservationRepository;
        }
        public async Task<IActionResult> Index()
        {
            var guests = await _guestRepository.GetGuests();
            ViewBag.GuestFirstName = guests.ToDictionary(h => h.Id, h => h.FirstName);
            ViewBag.GuestLastName = guests.ToDictionary(h => h.Id, h => h.LastName);
            ViewBag.GuestPersonalNumber = guests.ToDictionary(h => h.Id, h => h.PersonalNumber);
            var reservations = await _reservationRepository.GetReservations();
            ViewBag.CheckIn = reservations.ToDictionary(h => h.Id, h => h.CheckInDate);
            ViewBag.CheckOut = reservations.ToDictionary(h => h.Id, h => h.CheckOutDate);
            var result = await _guestReservationRepository.GetGuestReservations();
            return View(result);
        }

        public async Task<IActionResult> Create()
        {
            var guests = await _guestRepository.GetGuests();
            ViewBag.Guests = guests.Select(gr => new SelectListItem
            {
                Value = gr.Id.ToString(),
                Text = $"{gr.FirstName} {gr.LastName} - {gr.PersonalNumber}"
            }).ToList();
            var reservations = await _reservationRepository.GetReservations();
            ViewBag.Reservations = reservations.Select(gr => new SelectListItem
            {
                Value = gr.Id.ToString(),
                Text = $"{gr.CheckInDate} --- {gr.CheckOutDate}"
            }).ToList();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(GuestReservation model)
        {
            var guests = await _guestRepository.GetGuests();
            ViewBag.Guests = guests.Select(gr => new SelectListItem
            {
                Value = gr.Id.ToString(),
                Text = $"{gr.FirstName} {gr.LastName} - {gr.PersonalNumber}"
            }).ToList();
            var reservations = await _reservationRepository.GetReservations();
            ViewBag.Reservations = reservations.Select(gr => new SelectListItem
            {
                Value = gr.Id.ToString(),
                Text = $"{gr.CheckInDate} --- {gr.CheckOutDate}"
            }).ToList();
            if (ModelState.IsValid)
            {
                await _guestReservationRepository.AddGuestReservation(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }


        public async Task<IActionResult> Delete(int id)
        {
            var guests = await _guestRepository.GetGuests();
            ViewBag.Guests = guests.Select(gr => new SelectListItem
            {
                Value = gr.Id.ToString(),
                Text = $"{gr.FirstName} {gr.LastName} - {gr.PersonalNumber}"
            }).ToList();
            var reservations = await _reservationRepository.GetReservations();
            ViewBag.Reservations = reservations.Select(gr => new SelectListItem
            {
                Value = gr.Id.ToString(),
                Text = $"{gr.CheckInDate} --- {gr.CheckOutDate}"
            }).ToList();
            var result = await _guestReservationRepository.GetSingleGuestReservation(id);
            return View(result);
        }


        [HttpPost]
        public async Task<IActionResult> DeletePOST(int id)
        {
            await _guestReservationRepository.DeleteGuestReservation(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int id)
        {
            var guests = await _guestRepository.GetGuests();
            ViewBag.Guests = guests.Select(gr => new SelectListItem
            {
                Value = gr.Id.ToString(),
                Text = $"{gr.FirstName} {gr.LastName} - {gr.PersonalNumber}"
            }).ToList();
            var reservations = await _reservationRepository.GetReservations();
            ViewBag.Reservations = reservations.Select(gr => new SelectListItem
            {
                Value = gr.Id.ToString(),
                Text = $"{gr.CheckInDate} --- {gr.CheckOutDate}"
            }).ToList();
            var result = await _guestReservationRepository.GetSingleGuestReservation(id);
            return View(result);
        }


        [HttpPost]
        public async Task<IActionResult> Update(GuestReservation model)
        {
            var guests = await _guestRepository.GetGuests();
            ViewBag.Guests = guests.Select(gr => new SelectListItem
            {
                Value = gr.Id.ToString(),
                Text = $"{gr.FirstName} {gr.LastName} - {gr.PersonalNumber}"
            }).ToList();
            var reservations = await _reservationRepository.GetReservations();
            ViewBag.Reservations = reservations.Select(gr => new SelectListItem
            {
                Value = gr.Id.ToString(),
                Text = $"{gr.CheckInDate} --- {gr.CheckOutDate}"
            }).ToList();
            if (ModelState.IsValid)
            {
                await _guestReservationRepository.UpdateGuestReservation(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}

using AutoMapper;
using HotelProject.Models;
using HotelProject.Models.DTOs;
using HotelProject.Repository.Interfaces;
using HotelProject.Repository.MicrosoftDataSQLClient;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HotelProject.Web.Controllers
{
    public class GuestsController : Controller
    {
        private readonly IGuestRepository _guestRepository;
        private readonly IReservationRepository _reservationRepository;
        private readonly IGuestReservationRepository _guestReservationRepository;
        private readonly IMapper _mapper;

        public GuestsController(IGuestRepository guestRepository, IReservationRepository reservationRepository, IGuestReservationRepository guestReservationRepository, IMapper mapper)
        {
            _guestRepository = guestRepository;
            _reservationRepository = reservationRepository;
            _guestReservationRepository = guestReservationRepository;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            List<GuestReservation> rawData = await _guestReservationRepository.GetGuestReservations();
            List<GuestReservationDTO> result = _mapper.Map<List<GuestReservationDTO>>(rawData);
            return View(result);
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(GuestReservationForCreatingDTO model)
        {
            if(ModelState.IsValid)
            {
                Guest newGuest = _mapper.Map<Guest>(model);
                Reservation newReservation = _mapper.Map<Reservation>(model);

                await _guestRepository.AddGuest(newGuest);
                await _reservationRepository.AddReservation(newReservation);

                var newGuestFromDb = await _guestRepository.GetByPN(model.PersonalNumber);
                var newReservationFromDb = await _reservationRepository.GetByCheckInCheckOutDate(model.CheckInDate, model.CheckOutDate);

                model.GuestId = newGuestFromDb.Id;
                model.ReservationId = newReservationFromDb.Id;

                await _guestReservationRepository.AddGuestReservation(_mapper.Map<GuestReservation>(model));
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var result = await _guestReservationRepository.GetSingleGuestReservation(id);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> DeletePOST(int id, int guestId, int reservationId)
        {
            await _guestReservationRepository.DeleteGuestReservation(id);
            await _guestRepository.DeleteGuest(guestId);
            await _reservationRepository.DeleteReservation(reservationId);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int id)
        {            
            var rawData = await _guestReservationRepository.GetSingleGuestReservation(id);
            var result = _mapper.Map<GuestReservationForUpdatingDTO>(rawData);
            return View(result);
        }


        [HttpPost]
        public async Task<IActionResult> Update(GuestReservationForUpdatingDTO model)
        {
            if (ModelState.IsValid)
            {
                Guest updatedGuest = _mapper.Map<Guest>(model);
                Reservation updatedReservation = _mapper.Map<Reservation>(model);

                await _guestRepository.UpdateGuest(updatedGuest);
                await _reservationRepository.UpdateReservation(updatedReservation);
                await _guestReservationRepository.UpdateGuestReservation(_mapper.Map<GuestReservation>(model));
                return RedirectToAction("Index");
            }            
            return View(model);
        }
    }
}

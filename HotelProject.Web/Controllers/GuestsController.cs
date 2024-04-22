using AutoMapper;
using HotelProject.Data;
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
        private readonly ApplicationDbContext _context;

        public GuestsController(IGuestRepository guestRepository, IReservationRepository reservationRepository, IGuestReservationRepository guestReservationRepository, IMapper mapper, ApplicationDbContext context)
        {
            _guestRepository = guestRepository;
            _reservationRepository = reservationRepository;
            _guestReservationRepository = guestReservationRepository;
            _mapper = mapper;
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            List<GuestReservation> rawData = await _guestReservationRepository.GetAllAsync("Guest, Reservation");
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

                await _guestRepository.CreateAsync(newGuest);
                await _reservationRepository.CreateAsync(newReservation);
                await _context.SaveChangesAsync();

                var newGuestFromDb = await _guestRepository.GetAsync(x => x.PersonalNumber == model.PersonalNumber);
                var newReservationFromDb = await _reservationRepository.GetAsync(x => x.CheckInDate == model.CheckInDate && x.CheckOutDate == model.CheckOutDate);

                model.GuestId = newGuestFromDb.Id;
                model.ReservationId = newReservationFromDb.Id;

                await _guestReservationRepository.CreateAsync(_mapper.Map<GuestReservation>(model));
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var result = await _guestReservationRepository.GetAsync(x => x.Id == id, "Guest, Reservation");
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> DeletePOST(int id, int guestId, int reservationId)
        {
            var resultGuestReservation = await _guestReservationRepository.GetAsync(x => x.Id == id);
            var resultGuest = await _guestRepository.GetAsync(x => x.Id == guestId);
            var resultReservation = await _reservationRepository.GetAsync(x => x.Id == reservationId);
            _guestReservationRepository.Delete(resultGuestReservation);
            _guestRepository.Delete(resultGuest);
            _reservationRepository.Delete(resultReservation);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int id)
        {            
            var rawData = await _guestReservationRepository.GetAsync(x => x.Id == id, "Guest, Reservation");
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

                await _guestRepository.Update(updatedGuest);
                await _reservationRepository.Update(updatedReservation);
                await _guestReservationRepository.Update(_mapper.Map<GuestReservation>(model));
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }            
            return View(model);
        }
    }
}

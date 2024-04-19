namespace HotelProject.Models.DTOs
{
    public class GuestReservationDTO
    {
        public int Id { get; set; }
        public int GuestId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string PersonalNumber { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public int ReservationId { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
    }
}

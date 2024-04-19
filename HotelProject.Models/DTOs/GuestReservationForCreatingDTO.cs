using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.Models.DTOs
{
    public class GuestReservationForCreatingDTO
    {
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [StringLength(11)]
        public string PersonalNumber { get; set; } = string.Empty;

        [Required]
        [MaxLength(25)]
        [Phone]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required]
        public DateTime CheckInDate { get; set; }

        [Required]
        public DateTime CheckOutDate { get; set; }

        public int GuestId { get; set; }
        public int ReservationId { get; set; }
    }
}

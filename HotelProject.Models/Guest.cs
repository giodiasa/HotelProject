using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelProject.Models
{
    public class Guest
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

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

        public ICollection<GuestReservation>? GuestReservations { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace HotelProject.Models
{
    public class Manager
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "შეიყვანეთ სახელი")]
        public string FirstName { get; set; } = string.Empty;
        [Required(ErrorMessage = "შეიყვანეთ გვარი")]
        public string LastName { get; set; } = string.Empty;
        [Required(ErrorMessage = "შეიყვანეთ სასტუმრო")]
        public int HotelId { get; set; }
    }
}

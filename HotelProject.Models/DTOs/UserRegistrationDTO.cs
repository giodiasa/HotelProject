using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.Models.DTOs
{
    public class UserRegistrationDTO
    {
        [Required]
        [DisplayName("სახელი")]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [DisplayName("გვარი")]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        [DisplayName("ელ-ფოსტა")]
        public string Email { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Password)]
        [DisplayName("პაროლი")]
        public string Password { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The password and confirmation password don't match")]
        [DisplayName("გაიმეორეთ პაროლი")]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}

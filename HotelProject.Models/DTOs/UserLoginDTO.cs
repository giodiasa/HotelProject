using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.Models.DTOs
{
    public class UserLoginDTO
    {
        [Required]
        [EmailAddress]
        [DisplayName("ელ-ფოსტა")]
        public string Email { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Password)]
        [DisplayName("პაროლი")]
        public string Password { get; set; } = string.Empty;

        [DisplayName("დამახსოვრება")]
        public bool RememberMe { get; set; }
    }
}

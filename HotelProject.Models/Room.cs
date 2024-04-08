using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.Models
{
    public class Room
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "შეიყვანეთ სახელი")]
        public string Name { get; set; } = string.Empty;
        [Required(ErrorMessage = "შეიყვანეთ სტატუსი")]
        public bool IsFree { get; set; }
        [Required(ErrorMessage = "შეიყვანეთ სასტუმრო")]
        public int HotelId { get; set; }
        [Required(ErrorMessage = "შეიყვანეთ ფასი")]
        public decimal DailyPrice {  get; set; }
    }
}

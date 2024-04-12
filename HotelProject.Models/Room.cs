using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.Models
{
    public class Room
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "შეიყვანეთ სახელი")]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "შეიყვანეთ სტატუსი")]
        public bool IsFree { get; set; }

        [Required(ErrorMessage = "შეიყვანეთ სასტუმრო")]
        [ForeignKey("Hotel")]
        public int HotelId { get; set; }

        [Required(ErrorMessage = "შეიყვანეთ ფასი")]
        public double DailyPrice {  get; set; }
        public Hotel? Hotel { get; set; }
    }
}

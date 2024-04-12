using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.Models
{
    public class Hotel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "შეიყვანეთ სახელი")]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "შეიყვანეთ რეიტინგი")]
        [Range(1, 10)]
        public double Rating { get; set; }

        [Required(ErrorMessage = "შეიყვანეთ ქვეყანა")]
        [MaxLength(50)]
        public string Country { get; set; } = string.Empty;

        [Required(ErrorMessage = "შეიყვანეთ ქალაქი")]
        [MaxLength(50)]
        public string City { get; set; } = string.Empty;

        [Required(ErrorMessage = "შეიყვანეთ მისამართი")]
        [MaxLength(50)]
        public string PhysicalAddress { get; set; } = string.Empty;
        public Manager? Manager { get; set; }
        public ICollection<Room>? Rooms { get; set; }
    }
}

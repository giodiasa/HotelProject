using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.Models
{
    public class Hotel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "შეიყვანეთ სახელი")]
        public string Name { get; set; } = string.Empty;
        [Required(ErrorMessage = "შეიყვანეთ რეიტინგი")]
        public double Rating { get; set; }
        [Required(ErrorMessage = "შეიყვანეთ ქვეყანა")]
        public string Country { get; set; } = string.Empty;
        [Required(ErrorMessage = "შეიყვანეთ ქალაქი")]
        public string City { get; set; } = string.Empty;
        [Required(ErrorMessage = "შეიყვანეთ მისამართი")]
        public string PhysicalAddress { get; set; } = string.Empty;
    }
}

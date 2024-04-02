using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.Models
{
    public class Room
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool IsFree { get; set; }
        public int HotelId { get; set; }
        public decimal DailyPrice {  get; set; }
    }
}

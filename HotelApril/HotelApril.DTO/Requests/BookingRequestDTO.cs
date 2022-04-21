using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelApril.DTO.Requests
{
   public class BookingRequestDTO
    {

        [Required]
        public DateTime CheckIn { get; set; }
        [Required]
        public DateTime CheckOut { get; set; }
        [Required]
        public int NumberOfGuests { get; set; }
        [Required]
        public string Requests { get; set; }
    }
}

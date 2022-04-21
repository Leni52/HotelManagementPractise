using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelApril.DTO.Requests
{
  public class RoomRequestDTO
    {
        [MaxLength(50)]
        public string Number { get; set; }
        [Required]
        public bool Available { get; set; }
        [Required]
        [StringLength(500)]
        public string Description { get; set; }
        [Required]
        public int MaximumGuests { get; set; }

    }
}

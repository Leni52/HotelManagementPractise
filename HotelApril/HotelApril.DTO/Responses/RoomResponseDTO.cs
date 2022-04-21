using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelApril.DTO.Responses
{
   public class RoomResponseDTO
    {
     
        public string Number { get; set; }
        public bool Available { get; set; }
        public string Description { get; set; }
        public int MaximumGuests { get; set; }
    }
}

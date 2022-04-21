using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelApril.DAL.Entities
{
   public class Booking:Entity
    {
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public int NumberOfGuests { get; set; }
        public bool Paid { get; set; }

        //customer info
        public string Requests { get; set; }
        [ForeignKey("User")]
        public virtual ExternalUser Customer { get; set; }
    }
}

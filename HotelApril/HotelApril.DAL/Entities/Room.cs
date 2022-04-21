using HotelApril.DAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelApril.DAL.Entities
{
   public class Room:Entity
    {
        public int Number { get; set; }
        public virtual RoomType Type{ get; set; }
        public int Price { get; set; }
        public bool Available { get; set; }
        public string Description { get; set; }
        public int MaximumGuests { get; set; }
        public virtual ExternalUser RoomCreator { get; set; }
        public virtual List<Booking> Bookings { get; set; }
    }
}

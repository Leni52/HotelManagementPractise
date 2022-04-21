using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace HotelApril.DAL.Entities
{
    public class ExternalUser:Entity
    {
        public ExternalUser()
        {
            Bookings = new List<Booking>();
            Rooms = new List<Room>();
        }
        public string Name { get; set; }
        public string ExternalUserId { get; set; }
        public virtual List<Booking> Bookings { get; set; }
        public virtual List<Room> Rooms { get; set; }
    }
}

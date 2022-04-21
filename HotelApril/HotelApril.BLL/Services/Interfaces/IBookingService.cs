using HotelApril.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelApril.BLL.Services.Interfaces
{
   public interface IBookingService
    {
        Task CreateBooking(Booking booking, ExternalUser currentUser);
        Task<List<Booking>> GetAllBookings();
        Task<Booking> GetBooking(Guid id);
        Task DeleteBooking(Guid id);
        Task<Booking> UpdateBooking(Guid id, Booking booking, string currentUserId);
    }
}

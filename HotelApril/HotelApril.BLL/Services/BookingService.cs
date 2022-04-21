using HotelApril.BLL.Services.Interfaces;
using HotelApril.DAL.Entities;
using HotelApril.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelApril.BLL.Services
{
    public class BookingService : IBookingService
    {
        private readonly IRepository<Booking> _bookingRepository;
        public BookingService(IRepository<Booking> bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }
        public async Task CreateBooking(Booking booking, ExternalUser currentUser)
        {
            await _bookingRepository.CreateOrUpdate(booking);
        }

        public async Task DeleteBooking(Guid id)
        {
            var booking = await _bookingRepository.Get(id);
            if (booking != null)
            {
                await _bookingRepository.Remove(booking);
            }
            else
                throw new ItemDoesNotExistException();
        }

        public async Task<List<Booking>> GetAllBookings()
        {
            return await _bookingRepository.All();
        }

        public async Task<Booking> GetBooking(Guid id)
        {
            return await _bookingRepository.Get(id);
        }

        public async Task<Booking> UpdateBooking(Guid id, Booking booking, string currentUserId)
        {
            var bookingToUpdate = await _bookingRepository.Get(id);
            bookingToUpdate.ChangeDate = DateTime.Now;
            bookingToUpdate.CheckIn = booking.CheckIn;
            bookingToUpdate.CheckOut = booking.CheckOut;
            bookingToUpdate.NumberOfGuests = booking.NumberOfGuests;
            bookingToUpdate.Paid = booking.Paid;
            bookingToUpdate.UpdaterId = currentUserId;
            await _bookingRepository.CreateOrUpdate(booking);
            return booking;
        }
    }
}

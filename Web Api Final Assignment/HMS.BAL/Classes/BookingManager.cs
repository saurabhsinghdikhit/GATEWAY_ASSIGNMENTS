using HMS.BAL.Interfaces;
using HMS.DAL.Repository.Interfaces;
using HMS.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.BAL.Classes
{
    public class BookingManager : IBookingManager
    {
        private readonly IBookingRepository _bookingRepository;
        public BookingManager(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        public string deleteBooking(Booking model)
        {
            return _bookingRepository.deleteBooking(model);
        }

        public List<Booking> getAllBooking()
        {
            return _bookingRepository.getAllBooking();
        }

        public string updateBooking(Booking model)
        {
            return _bookingRepository.updateBooking(model);
        }

        public string updateBookingStatus(Booking model)
        {
            return _bookingRepository.updateBookingStatus(model);
        }
    }
}

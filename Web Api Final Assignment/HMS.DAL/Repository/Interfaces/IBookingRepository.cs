using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HMS.Models.Models;

namespace HMS.DAL.Repository.Interfaces
{
    public interface IBookingRepository
    {
        List<Booking> getAllBooking();
        string updateBooking(Booking model);

        string updateBookingStatus(Booking model);
        string deleteBooking(Booking model);
    }
}

using HMS.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.BAL.Interfaces
{
    public interface IBookingManager
    {
        List<Booking> getAllBooking();
        string updateBooking(Booking model);

        string updateBookingStatus(Booking model);
        string deleteBooking(Booking model);
    }
}

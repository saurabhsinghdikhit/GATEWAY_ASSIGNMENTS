using BookingEntities.BookingEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingAPI.Service
{
    public class BookingService
    {
        public List<Booking> getBookings()
        {
            var bookings = new List<Booking>();
            for (int i = 1; i <= 10; i++)
            {
                var customer = new CustomerService().getCustomers().Find(r => r.Id == i);
                var show = new ShowService().getShows().Find(r => r.Id == i);
                bookings.Add(new Booking
                {
                    Id = i,
                    ShowId = show.Id,
                    CustomerId=customer.Id,
                    Show=show,
                    Customer=customer,
                    Tickets=i+2,
                    Price=show.Price*(i+2)
                });
            }
            return bookings;
        }
        public Booking GetBooking(int Id)
        {
            return getBookings().Find(r => r.Id == Id);
        }
    }
}

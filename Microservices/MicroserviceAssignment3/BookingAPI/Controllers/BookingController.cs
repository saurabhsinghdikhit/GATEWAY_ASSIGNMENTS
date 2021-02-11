using BookingAPI.Service;
using BookingAPI.ThrottleConfiguration;
using BookingEntities.BookingEntities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    //[Throttle(Name = "Limit Request Number", Seconds = 5)]
    public class BookingController : ControllerBase
    {
        private readonly ILogger<BookingController> _logger;

        public BookingController(ILogger<BookingController> logger)
        {
            _logger = logger;
        }
        /// <summary>
        /// Get bookings
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("GetBookings")]
        public IEnumerable<Booking> Get()
        {
            return new BookingService().getBookings();
        }
        /// <summary>
        /// Get booking by Id
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("GetBooking/{id}")]
        public Booking GetBooking(int id)
        {
            return new BookingService().GetBooking(id);
        }
    }
}

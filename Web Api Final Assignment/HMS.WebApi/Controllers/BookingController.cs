using HMS.BAL.Interfaces;
using HMS.Models.Models;
using HMS.WebApi.AuthenticationFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HMS.WebApi.Controllers
{
    [AuthenticationFilter]
    public class BookingController : ApiController
    {
        private readonly IBookingManager _bookingManager;
        public BookingController(IBookingManager bookingManager)
        {
            _bookingManager = bookingManager;
        }

        [HttpGet]
        [Route("api/booking/allBooking")]
        public IHttpActionResult changeBooking()
        {
            return Ok(_bookingManager.getAllBooking());
        }

        [HttpPut]
        [Route("api/booking/updateBooking")]
        public IHttpActionResult changeBooking([FromBody]Booking model)
        {
            return Ok(_bookingManager.updateBooking(model));
        }

        [HttpPut]
        [Route("api/booking/updateStatus")]
        public IHttpActionResult changeBookingStatus([FromBody]Booking model)
        {
            return Ok(_bookingManager.updateBookingStatus(model));
        }

        [HttpPut]
        [Route("api/booking/deleteBooking")]
        public IHttpActionResult deleteBooking([FromBody]Booking model)
        {
            return Ok(_bookingManager.deleteBooking(model));
        }
    }
}

using BookingAPI.Service;
using BookingAPI.ThrottleConfiguration;
using CommonObject.Models;
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
    public class DropdownController : ControllerBase
    {
        private readonly ILogger<DropdownController> _logger;

        public DropdownController(ILogger<DropdownController> logger)
        {
            _logger = logger;
        }
        /// <summary>
        /// Get bookings
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("GetBookingsDropdown")]
        public IEnumerable<AllDropdownDTO> Get()
        {
            return new BookingService().getBookings().Select(r => new AllDropdownDTO { Id = r.Id, Name = "Show_"+r.CustomerId });
        }
    }
}

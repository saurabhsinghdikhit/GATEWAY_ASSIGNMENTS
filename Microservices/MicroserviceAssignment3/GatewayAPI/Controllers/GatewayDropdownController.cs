using CommonObject.Models;
using GatewayAPI.ThrottlingConfiguration;
using GatewayAPI.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GatewayAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Throttle(Name = "Limit Request Number", Seconds = 10)]
    public class GatewayDropdownController : ControllerBase
    {
        private readonly ILogger<GatewayDropdownController> _logger;

        public GatewayDropdownController(ILogger<GatewayDropdownController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Get Theater Dropdown
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("GetTheaterDropdown")]
        public async Task<IEnumerable<AllDropdownDTO>> GetTheatersAsync()
        {
            return await WebClient.GetRequest<List<AllDropdownDTO>>("https://localhost:44397/AllDropdown/GetTheaterDropdown");

        }
        /// <summary>
        /// Get Bookings dropdown
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("GetBookingDropdown")]
        public async Task<IEnumerable<AllDropdownDTO>> GetBookingsAsync()
        {
            return await WebClient.GetRequest<List<AllDropdownDTO>>("https://localhost:44322/Dropdown/GetBookingsDropdown");
            
        }
        /// <summary>
        ///  Get Booking and movie dropdown both
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("GetMovieBookingDropdown")]
        public async Task<IEnumerable<AllDropdownDTO>> GetMovieBookingDropdown()
        {
            var movies = await WebClient.GetRequest<List<AllDropdownDTO>>("https://localhost:44397/AllDropdown/GetMovieDropdown");
            var bookings = await WebClient.GetRequest<List<AllDropdownDTO>>("https://localhost:44322/Dropdown/GetBookingsDropdown");
            
            movies.AddRange(bookings);
            return movies;
        }
    }
}

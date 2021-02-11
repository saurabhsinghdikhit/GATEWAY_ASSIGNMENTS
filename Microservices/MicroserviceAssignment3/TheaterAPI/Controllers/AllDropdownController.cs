using CommonObject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheaterAPI.Service;
using TheaterAPI.ThrottleConfiguration;

namespace TheaterAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    //[Throttle(Name = "Limit Request Number", Seconds = 5)]
    public class AllDropdownController : ControllerBase
    {
        private readonly ILogger<AllDropdownController> _logger;

        public AllDropdownController(ILogger<AllDropdownController> logger)
        {
            _logger = logger;
        }
        /// <summary>
        /// Get Theater values
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("GetTheaterDropdown")]
        public IEnumerable<AllDropdownDTO> GetTheater()
        {
            return new TheaterService().GetTheaters().Select(r => new AllDropdownDTO { Id = r.Id, Name = r.Name });
        }
        /// <summary>
        /// Get Movie values
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("GetMovieDropdown")]
        public IEnumerable<AllDropdownDTO> GetMovie()
        {
            return new MovieService().GetMovies().Select(r => new AllDropdownDTO { Id = r.Id, Name = r.Name });
        }
        /// <summary>
        /// Get Theater values
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("GetShowDropdown")]
        public IEnumerable<AllDropdownDTO> GetShow()
        {
            return new ShowService().getShows().Select(r => new AllDropdownDTO { Id = r.Id, Name = r.Name });
        }

    }
}

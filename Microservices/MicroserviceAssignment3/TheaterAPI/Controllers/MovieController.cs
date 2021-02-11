using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheaterAPI.Service;
using TheaterAPI.ThrottleConfiguration;
using TheaterEntities.Entities;

namespace TheaterAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    //[Throttle(Name = "Limit Request Number", Seconds = 5)]
    public class MovieController : ControllerBase
    {
        private readonly ILogger<MovieController> _logger;

        public MovieController(ILogger<MovieController> logger)
        {
            _logger = logger;
        }
        /// <summary>
        /// Get movie
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("GetMovies")]
        public IEnumerable<Movie> Get()
        {
            return new MovieService().GetMovies();
        }
        /// <summary>
        /// Get movie by Id
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("GetMovie/{id}")]
        public Movie GetTheater(int id)
        {
            return new MovieService().GetMovie(id);
        }
    }
}

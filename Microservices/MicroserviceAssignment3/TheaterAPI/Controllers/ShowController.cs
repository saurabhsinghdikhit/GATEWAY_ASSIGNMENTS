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
    public class ShowController : ControllerBase
    {
        private readonly ILogger<ShowController> _logger;

        public ShowController(ILogger<ShowController> logger)
        {
            _logger = logger;
        }
        /// <summary>
        /// Get shows
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("GetShows")]
        public IEnumerable<Show> Get()
        {
            return new ShowService().getShows();
        }
        /// <summary>
        /// Get show by Id
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("GetShow/{id}")]
        public Show GetShow(int id)
        {
            return new ShowService().GetShow(id);
        }
    }
}

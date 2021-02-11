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
    public class TheaterController : ControllerBase
    {
        private readonly ILogger<TheaterController> _logger;

        public TheaterController(ILogger<TheaterController> logger)
        {
            _logger = logger;
        }
        /// <summary>
        /// Get theaters
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("GetTheaters")]
        public IEnumerable<Theater> Get()
        {
            return new TheaterService().GetTheaters();
        }
        /// <summary>
        /// Get theater by Id
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("GetTheater/{id}")]
        public Theater GetTheater(int id)
        {
            return new TheaterService().GetTheater(id);
        }
    }
}

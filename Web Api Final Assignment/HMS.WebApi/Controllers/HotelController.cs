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
    public class HotelController : ApiController
    {
        private readonly IHotelManager _hotelManager;
        public HotelController(IHotelManager hotelManager)
        {
            _hotelManager = hotelManager;   
        }

        [HttpGet]
        [Route("api/hotel/AllHotels")]
        public IHttpActionResult Hotels()
        {
            return Ok(_hotelManager.getAllHolels());
        }

        [HttpGet]
        [Route("api/hotel/name")]
        public string names(string name)
        {
            return name;
        }

        [HttpGet]
        [Route("api/hotel/findHotel/{id}")]
        public IHttpActionResult Hotel(int id)
        {
            return Ok(_hotelManager.getHotel(id));
        }

        [HttpPost]
        [Route("api/hotel/createHotel")]
        public IHttpActionResult makeAhotel([FromBody]Hotel model)
        {
            return Ok(_hotelManager.createHotel(model));
        }

    }
}

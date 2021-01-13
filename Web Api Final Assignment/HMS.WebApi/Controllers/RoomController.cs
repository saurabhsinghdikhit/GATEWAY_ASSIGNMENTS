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
    public class RoomController : ApiController
    {
        private readonly IRoomManager _roomManager;
        public RoomController(IRoomManager roomManager)
        {
            _roomManager = roomManager;
        }

        [HttpGet]
        [Route("api/room/sortAllRoom/{sortby?}")]
        public IHttpActionResult sortAllRooms(string sortby="price")
        {
            return Ok(_roomManager.sortRoom(sortby));
        }

        [HttpPost]
        [Route("api/room/createRoom")]
        public IHttpActionResult makeARoom([FromBody]Room model)
        {
            return Ok(_roomManager.createRoom(model));
        }

        [HttpGet]
        [Route("api/room/checkRoom/{id}/{date}")]
        public IHttpActionResult makeARoom(int id,DateTime date)
        {
            return Ok(_roomManager.checkRoomAvailability(id,date));
        }

        [HttpPost]
        [Route("api/room/bookRoom")]
        public IHttpActionResult bookARoom([FromBody]Booking model)
        {
            return Ok(_roomManager.bookRoom(model));
        }
    }
}

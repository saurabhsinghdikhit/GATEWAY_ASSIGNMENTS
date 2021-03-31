using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TESTING.CLPMT.BAL.Interfaces;
using TESTING.CLPMT.BE;

namespace TESTING.CLPMT.WEPAPI.Controllers
{
    public class PassengerController : ApiController
    {
        private readonly IPassengerManager _passengerManager;
        public PassengerController(IPassengerManager passengerManager)
        {
            _passengerManager = passengerManager;
        }
        // GET: api/Passenger
        public IHttpActionResult Get()
        {
            var passengers = _passengerManager.GetPassengersList();
            if (passengers == null)
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.BadRequest, "passengers list is null"));
            else
                return Ok(passengers);
        }

        // GET: api/Passenger/5
        public IHttpActionResult Get(Guid id)
        {
            var passenger = _passengerManager.GetPassenger(id);
            if (passenger == null)
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.BadRequest, "could not find the passenger with Id"+id));
            else
                return Ok(passenger);
        }

        // POST: api/Passenger
        public IHttpActionResult Post([FromBody]Passenger passenger)
        {
            var _passenger = _passengerManager.AddPassenger(passenger); ;
            if (_passenger == null)
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.BadRequest, "not able to add passenger"));
            else
                return Ok(_passenger);
            
        }

        // PUT: api/Passenger/5
        public IHttpActionResult Put([FromBody]Passenger passenger)
        {
            var _passenger = _passengerManager.UpdatePassenger(passenger);
            if (_passenger == null)
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.BadRequest, "not able to update passenger"));
            else
                return Ok(_passenger);
        }

        // DELETE: api/Passenger/5
        public IHttpActionResult Delete(Guid id)
        {
            if (!_passengerManager.RemovePassenger(id))
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.BadRequest, "passenger deleted successfully"));
            else
                return Ok(true);
        }
    }
}

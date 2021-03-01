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
        public IList<Passenger> Get()
        {
            return _passengerManager.GetPassengersList();
        }

        // GET: api/Passenger/5
        public IHttpActionResult Get(Guid id)
        {
            return Ok(_passengerManager.GetPassenger(id));
        }

        // POST: api/Passenger
        public Passenger Post([FromBody]Passenger passenger)
        {
            return _passengerManager.AddPassenger(passenger);
        }

        // PUT: api/Passenger/5
        public Passenger Put([FromBody]Passenger passenger)
        {
            return _passengerManager.UpdatePassenger(passenger);
        }

        // DELETE: api/Passenger/5
        public bool Delete(Guid id)
        {
            return _passengerManager.RemovePassenger(id);
        }
    }
}

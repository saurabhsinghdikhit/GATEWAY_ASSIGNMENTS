using BookingAPI.Service;
using BookingAPI.ThrottleConfiguration;
using BookingEntities.BookingEntities;
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
    public class CustomerController : ControllerBase
    {
        private readonly ILogger<CustomerController> _logger;

        public CustomerController(ILogger<CustomerController> logger)
        {
            _logger = logger;
        }
        /// <summary>
        /// Get customer
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("GetCustomer")]
        public IEnumerable<Customer> Get()
        {
            return new CustomerService().getCustomers();
        }
        /// <summary>
        /// Get customer by Id
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("GetCustomer/{id}")]
        public Customer GetCustomer(int id)
        {
            return new CustomerService().GetCustomer(id);
        }
    }
}

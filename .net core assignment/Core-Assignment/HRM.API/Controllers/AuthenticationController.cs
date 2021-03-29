using HRM.API.Services;
using HRM.BE.BussinessEntities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRM.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private IAuthenticateService _authenticateService;
        public AuthenticationController(IAuthenticateService authenticateService)
        {
            _authenticateService = authenticateService;
        }
        /// <summary>
        /// Post request for admin login
        /// </summary>
        /// <param name="admin"></param>
        /// <returns>Returns admin object</returns>
        [HttpPost]
        public IActionResult Post([FromBody]Admin admin)
        {
            var record = _authenticateService.Authenticate(admin.Email, admin.Password);
            if (record == null)
                return BadRequest(new { message = "Email or password is not incorrect" });
            else
                return Ok(record);
        }
    }
}

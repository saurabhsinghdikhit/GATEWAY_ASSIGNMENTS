using CS.PMA.BAL.Interfaces;
using CS.PMA.BE.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CS.PMA.WebAPI.Controllers
{
    public class UserController : ApiController
    {
        private readonly IUserManager _UserManager;

        /// <summary>
        /// Constructor dependency injection
        /// </summary>
        /// <returns></returns>
        public UserController(IUserManager UserManager)
        {
            _UserManager = UserManager;
        }

        /// <summary>
        /// Do register
        /// </summary>
        /// <returns></returns>
        [HttpPost, Route("user/register")]
        public IHttpActionResult DoRegister(UserVM user)
        {
            if (_UserManager.Register(user)==1)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }

        }

        /// <summary>
        /// Do login
        /// </summary>
        /// <returns></returns>
        [HttpPost, Route("user/login")]
        public IHttpActionResult DoLogin(LoginVM user)
        {
            var record = _UserManager.Login(user);
            if (record != null)
            {
                return Ok(record);
            }
            else
            {
                return NotFound();
            }

        }
    }
}

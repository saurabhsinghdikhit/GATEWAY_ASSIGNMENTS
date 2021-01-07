using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ProductManagementWebAPI.Models;
namespace ProductManagementWebAPI.Controllers
{
    public class UserRegistrationController : ApiController
    {
        ProductManagementUserEntities db = new ProductManagementUserEntities();
        public IHttpActionResult userRegistrationForm(User _user)
        {
            if (!ExistingEmail(_user.Email))
            {
                db.Users.Add(new User()
                {
                    Name = _user.Name,
                    Password = _user.Password,
                    Email = _user.Email,
                    CreatedAt = DateTime.Now
                });
                db.SaveChanges();
                return Ok();
            }
            else
            {
                return NotFound();
            }
            
        }
        private bool ExistingEmail(string email)
        {
            User userRecord = db.Users.Where(x => x.Email.Equals(email)).FirstOrDefault();
            if (userRecord == null)
                return false;
            else
                return true;

        }
    }
}

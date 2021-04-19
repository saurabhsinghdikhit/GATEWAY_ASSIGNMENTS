using HRM.BE.BussinessEntities;
using HRM.Common.JWT_Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace HRM.API.Services
{
    public class AuthenticateService : IAuthenticateService
    {
        private readonly AppSettings _appSettings;
        public AuthenticateService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }
        /// <summary>
        /// Static list for admin credentials
        /// </summary>
        private List<Admin> admins = new List<Admin>()
        {
            new Admin
            {
                Email="admin@gmail.com",
                Password="admin"
            },
            new Admin
            {
                Email="saurabh@gmail.com",
                Password="saurabh"
            }
        };
        /// <summary>
        /// Admin login
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns>Return admin</returns>
        public Admin Authenticate(string email, string password)
        {
            var admin = admins.SingleOrDefault(x => x.Email.ToUpper() == email.ToUpper() && x.Password == password);
            if (admin == null)
                return null;
            // JWT token generation at admin login
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name,admin.Email.ToString()),
                    new Claim(ClaimTypes.Role,"Admin"),
                    new Claim(ClaimTypes.Version,"V3.1")
                }),
                Expires = DateTime.UtcNow.AddDays(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            admin.Password = null;
            admin.Token = tokenHandler.WriteToken(token);
            return admin;
        }
    }
}

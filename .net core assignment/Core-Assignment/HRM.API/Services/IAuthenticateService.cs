using HRM.BE.BussinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRM.API.Services
{
    public interface IAuthenticateService
    {
        Admin Authenticate(string email, string password);
    }
}

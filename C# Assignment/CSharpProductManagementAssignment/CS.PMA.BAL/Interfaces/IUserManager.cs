using CS.PMA.BE.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS.PMA.BAL.Interfaces
{
    public interface IUserManager
    {
        int Register(UserVM user);
        UserVM Login(LoginVM user);
    }
}

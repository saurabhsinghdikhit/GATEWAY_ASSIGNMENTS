using CS.PMA.BAL.Interfaces;
using CS.PMA.BE.ViewModels;
using CS.PMA.DAL.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS.PMA.BAL.Implementation
{
    public class UserManager : IUserManager
    {
        private readonly IUserRepository _userRepository;
        public UserManager(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public UserVM Login(LoginVM user)
        {
            
            return _userRepository.Login(user);
        }

        public int Register(UserVM user)
        {
            return _userRepository.Register(user);
        }
    }
}

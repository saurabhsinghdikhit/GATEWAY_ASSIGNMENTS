using CS.PMA.BE.ViewModels;
using CS.PMA.DAL.Database;
using CS.PMA.DAL.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS.PMA.DAL.Repository.Implementation
{
    public class UserRepository : IUserRepository
    {
        private readonly PMDbContext context;
        public UserRepository()
        {
            context = new PMDbContext();
        }
        public int Register(UserVM user)
        {
            try
            {
                var userRecord = AutoMapper.Mapper.Map<User>(user);
                if (!ExistingEmail(user.Email))
                {
                    userRecord.CreatedAt = DateTime.Now;
                    context.Users.Add(userRecord);
                    context.SaveChanges();
                    return 1;
                }
                else
                {
                    return 2;
                }
            }
            catch (Exception)
            {
                return 3;
            }
        }

        private bool ExistingEmail(string email)
        {
                User userRecord = context.Users.Where(x => x.Email.Equals(email)).FirstOrDefault();
                if (userRecord == null)
                    return false;
                else
                    return true;
        }

        public UserVM Login(LoginVM user)
        {
            var userRecord = context.Users.Where(x => x.Email.Equals(user.Email) && x.Password.Equals(user.Password)).FirstOrDefault();
            if (userRecord == null)
            {
                return null;
            }
            else
            {
                return AutoMapper.Mapper.Map<UserVM>(userRecord);
            }

        }
    }
}

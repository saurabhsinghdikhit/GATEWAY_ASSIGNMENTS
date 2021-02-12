using AutoMapper;
using CS.PMA.BE.ViewModels;
using CS.PMA.DAL.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS.PMA.DAL.AutomapperProfile
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<ProductVM, Product>();
            CreateMap<Product, ProductVM>();
            CreateMap<UserVM, User>();
            CreateMap<User, UserVM>();
            
        }
    }
}

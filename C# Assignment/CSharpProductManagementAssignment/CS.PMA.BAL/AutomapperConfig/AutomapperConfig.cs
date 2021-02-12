using AutoMapper;
using CS.PMA.DAL.AutomapperProfile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS.PMA.BAL.AutomapperConfig
{
    public class AutomapperConfig
    {
        public static void Configure()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<AutomapperProfile>();
            });
        }
    }
}

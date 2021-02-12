using AutoMapper;
using SBS.DAL.AutoMapperConfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBS.BAL.AutomapperConfig
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

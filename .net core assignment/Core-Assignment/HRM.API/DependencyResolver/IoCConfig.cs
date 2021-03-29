using HRM.BAL.Implementation;
using HRM.BAL.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRM.API.DependencyResolver
{
    public static class IoCConfig
    {
        public static void ConfigureServices(ref IServiceCollection services)
        {
            services.AddTransient<IEmployeeManager, EmployeeManager>();
        }
    }
}

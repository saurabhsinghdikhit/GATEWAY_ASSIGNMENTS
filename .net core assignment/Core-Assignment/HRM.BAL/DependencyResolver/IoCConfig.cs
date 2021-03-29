using HRM.DAL.Implementation;
using HRM.DAL.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRM.BAL.DependencyResolver
{
    public static class IoCConfig
    {
        public static void ConfigureServices(ref IServiceCollection services)
        {
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
        }
    }
}

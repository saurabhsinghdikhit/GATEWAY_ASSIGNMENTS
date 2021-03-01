using System.Web.Http;
using TESTING.CLPMT.BAL.Implementations;
using TESTING.CLPMT.BAL.Interfaces;
using Unity;
using Unity.WebApi;

namespace TESTING.CLPMT.WEPAPI
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IPassengerManager, PassengerManager>();
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}
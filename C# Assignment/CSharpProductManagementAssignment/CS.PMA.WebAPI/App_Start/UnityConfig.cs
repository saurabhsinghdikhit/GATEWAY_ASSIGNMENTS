using CS.PMA.BAL.Implementation;
using CS.PMA.BAL.Interfaces;
using CS.PMA.BAL.UnityHelper;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace CS.PMA.WebAPI
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            container.RegisterType<IUserManager, UserManager>();
            container.RegisterType<IProductManager, ProductManager>();
            container.AddNewExtension<UnityRepositoryHelper>();
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}
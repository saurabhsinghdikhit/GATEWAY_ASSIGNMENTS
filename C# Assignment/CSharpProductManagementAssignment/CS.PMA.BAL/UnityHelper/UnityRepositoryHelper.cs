using CS.PMA.DAL.Repository.Implementation;
using CS.PMA.DAL.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Extension;
using Unity;
namespace CS.PMA.BAL.UnityHelper
{
    public class UnityRepositoryHelper : UnityContainerExtension
    {
        protected override void Initialize()
        {
            Container.RegisterType<IUserRepository, UserRepository>();
            Container.RegisterType<IProductRepository, ProductRepository>();
        }
            
    }
}

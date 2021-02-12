using System.Web.Http;
using WebActivatorEx;
using SBS.WebAPI;
using Swashbuckle.Application;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace SBS.WebAPI
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            
            var thisAssembly = typeof(SwaggerConfig).Assembly;
            GlobalConfiguration.Configuration
             .EnableSwagger(c =>
             {
                 c.SingleApiVersion("v1", "First WEB API Demo");
                 c.IncludeXmlComments(string.Format(@"{0}\bin\SBS.WebAPI.xml",
                                      System.AppDomain.CurrentDomain.BaseDirectory));
             })
             .EnableSwaggerUi();
        }
    }
}

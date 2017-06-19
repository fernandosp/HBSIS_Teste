using System.Web.Http;
using FSP.HBSIS.Application.AutoMapper;

namespace FSP.HBSIS.Services.REST.ClienteAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            AutoMapperConfig.RegisterMappings();
        }
    }
}

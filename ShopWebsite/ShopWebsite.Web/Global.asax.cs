using System.Web.Mvc;
using System.Web.Routing;

namespace ShopWebsite.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
  
            Bootstrapper.Run();
        }
    }
}

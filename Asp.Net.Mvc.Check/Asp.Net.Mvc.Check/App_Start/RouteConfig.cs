using System.Web.Mvc;
using System.Web.Routing;

namespace Asp.Net.Mvc.Check
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute("ShopSchema2", "Shop/OldAction/{id}", new { controller = "Home", action = "Index", id="defaultId" });

            routes.MapRoute("TestSchema", "Test/{action}", new { controller = "Home" });

            routes.MapRoute("", "Prefix{controller}/{action}", new { controller = "New", action = "About" });

            routes.MapRoute("", "Public/{controller}/{action}", new { controller = "New", action = "Index" });

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}

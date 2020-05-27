using System.Web.Mvc;
using System.Web.Routing;

namespace Asp.Net.Mvc.Check
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute("ShopSchema2", "Shop/OldAction/{id}", new { controller = "Home", action = "Index", id = "defaultId" });

            routes.MapRoute("TestSchema", "Test/{action}", new { controller = "Home", action = "Index", id = UrlParameter.Optional });

            routes.MapRoute("", "Prefix{controller}/{action}", new { controller = "New", action = "About" });

            routes.MapRoute("", "Public/{controller}/{action}", new { controller = "New", action = "Index" });

            // Test Namespace priority
            //routes.MapRoute("AddContollerRoute", "Home/{action}/{id}/{*catchall}", new { controller = "Home", action = "Index", id = UrlParameter.Optional }, new[] { "Asp.Net.Mvc.Check.Controllers2" });

            //routes.MapRoute("MyRoute", "{controller}/{action}/{id}/{*catchall}", new { controller = "Home", action = "Index", id = UrlParameter.Optional }, new[] { "Asp.Net.Mvc.Check.Controllers"});

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                new[] { "Asp.Net.Mvc.Check.Controllers" }
            );
        }
    }
}

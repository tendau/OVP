using System.Web.Mvc;
using System.Web.Routing;

namespace Onlive_VRP_Portal
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Account", action = "Login", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                "NewService",
                "Home/NewService",
                new { Controller = "Home", Action = "NewService", id = UrlParameter.Optional }
                );
        }
    }
}
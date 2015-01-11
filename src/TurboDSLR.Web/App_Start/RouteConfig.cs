using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using Autofac;
using Autofac.Core;
using TurboDSLR.Framework.Web.Routing;

namespace TurboDSLR
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapMvcAttributeRoutes();

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            //register custom routes (plugins, etc)
            IRoutePublisher routePublisher =  new RoutePublisher();
            routePublisher.RegisterRoutes(routes);

            //routes.MapRoute(
            //    name: "Login",
            //    url: "login",
            //    defaults: new { controller = "Home", action = "Login", id = UrlParameter.Optional }
            //);
        }
    }
}

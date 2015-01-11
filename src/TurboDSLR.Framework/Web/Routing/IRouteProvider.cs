using System.Web.Routing;

namespace TurboDSLR.Framework.Web.Routing
{
    public interface IRouteProvider
    {
        void RegisterRoutes(RouteCollection routes);

        int Priority { get; }
    }
}

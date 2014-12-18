using System.Web.Routing;

namespace PostBoard.Framework.Web.Routing
{
    public interface IRouteProvider
    {
        void RegisterRoutes(RouteCollection routes);

        int Priority { get; }
    }
}

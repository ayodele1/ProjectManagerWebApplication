using System.Web.Mvc;
using System.Web.Routing;

namespace ProjectManager.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            //var namespaces = new[] { typeof(HomeController).Namespace };
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { area = "General", controller = "Home", action = "Index", id = UrlParameter.Optional }
            ).DataTokens["area"] = "General";

            //routes.MapRoute("Home", "", new { area = "General", controller = "Home", action = "Index" });
            //(RouteTable.Routes[routes.Count - 1] as Route).DataTokens["area"] = "General";

        }
    }
}

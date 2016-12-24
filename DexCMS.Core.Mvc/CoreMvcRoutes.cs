using DexCMS.Core.Infrastructure.Models;
using DexCMS.Core.Mvc.Enums;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Routing;

namespace DexCMS.Core.Mvc
{
    public static class CoreMvcRoutes
    {
        public static void Configure(RouteCollection routes, DexCMSConfiguration config)
        {
            routes.LowercaseUrls = !config.RetrieveValue<bool>(CoreRouteOptions.DisableLowercaseUrls.ToString());
            List<string> ignoreRoutes = config.RetrieveValue<List<string>>(CoreRouteOptions.MvcIgnoreRoutes.ToString());
            if (ignoreRoutes == null)
            {
                ignoreRoutes = new List<string>
                {
                    "{resource}.axd/{*pathInfo}",
                    "libs/{*any}"
                };
            }
            foreach (var ignoreRoute in ignoreRoutes)
            {
                routes.IgnoreRoute(ignoreRoute);
            }

        }
        public static void CreateDefaltRoutes(RouteCollection routes, DexCMSConfiguration config)
        {
            routes.MapRoute(
                "Error",
                "error",
                new { controller = "Error", action = "Index" });
            routes.MapRoute(
                "NotFound",
                "404",
                new { controller = "Error", action = "NotFound" });
        }

        public static void CreateFinalRoutes(RouteCollection routes, DexCMSConfiguration config)
        {
            routes.MapRoute(
                "NotFound",
                "{*url}",
                new { controller = "Error", action = "NotFound" });
        }
    }

}

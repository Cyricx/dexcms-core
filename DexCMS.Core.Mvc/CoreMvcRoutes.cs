using DexCMS.Core.Infrastructure.Models;
using DexCMS.Core.Mvc.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Routing;

namespace DexCMS.Core.Mvc
{
    public static class BaseMvcRoutes
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

        public static void CreateFinalRoutes(RouteCollection routes, DexCMSConfiguration config)
        {
            routes.MapRoute(
                "404-PageNotFound",
                "{*url}",
                new { controller = "Error", action = "InvalidPage" });
        }
    }

}

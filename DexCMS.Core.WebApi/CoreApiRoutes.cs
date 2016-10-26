using DexCMS.Core.Infrastructure.Models;
using DexCMS.Core.WebApi.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace DexCMS.Core.WebApi
{
    public static class CoreApiRoutes
    {
        public static void Configure(HttpConfiguration httpConfig, DexCMSConfiguration config)
        {
            JsonMediaTypeFormatter jsonFormatter = httpConfig.Formatters.JsonFormatter;
            List<string> supportedMediaTypes = config.RetrieveValue<List<string>>(CoreApiOptions.SupportedMediaTypes.ToString());
            if (supportedMediaTypes == null)
            {
                supportedMediaTypes = new List<string>
                {
                    "text/html"
                };
            }

            if (supportedMediaTypes != null)
            {
                foreach (var mediaType in supportedMediaTypes)
                {
                    jsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue(mediaType));
                }
            }
            if (!config.RetrieveValue<bool>(CoreApiOptions.IgnoreReferenceHandling.ToString()))
            {
                jsonFormatter.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            }
            if (!config.RetrieveValue<bool>(CoreApiOptions.UseCamelCase.ToString()))
            {
                jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            }
        }

        public static void CreateDefaultRoutes(HttpConfiguration httpConfig, DexCMSConfiguration config)
        {
            string baseApi = config.RetrieveValue<string>(CoreApiOptions.CoreApiUrl.ToString());
            if (string.IsNullOrEmpty(baseApi))
            {
                baseApi = "api";
            }

            httpConfig.Routes.MapHttpRoute(
                name: "FileUpload",
                routeTemplate: baseApi + "/fileupload/upload",
                defaults: new { controller = "fileupload", action = "upload" }
            );

            httpConfig.Routes.MapHttpRoute(
                name: "RoleApi",
                routeTemplate: baseApi + "/roles/{id}",
                defaults: new { controller = "roles", id = RouteParameter.Optional }
            );

            httpConfig.Routes.MapHttpRoute(
                name: "UserApi",
                routeTemplate: baseApi + "/users/{id}",
                defaults: new { controller = "users", id = RouteParameter.Optional }
            );

            httpConfig.Routes.MapHttpRoute(
                name: "DefaultApiGetAll",
                routeTemplate: baseApi + "/{controller}"
            );

            httpConfig.Routes.MapHttpRoute(
                name: "CompositeApi",
                routeTemplate: baseApi + "/{controller}/{id}/{secondKey}",
                defaults: new { },
                constraints: new { id = @"^[0-9]+$", secondKey = @"^[0-9]+$" }
            );

            httpConfig.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: baseApi + "/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional },
                constraints: new { id = @"^[0-9]+$" }
            );

            httpConfig.Routes.MapHttpRoute(
                name: "DefaultApiByGroupID",
                routeTemplate: baseApi + "/{controller}/{bytype}/{id}",
                defaults: null,
                constraints: new { id = @"^[0-9]+$" }
            );
        }

    }
}

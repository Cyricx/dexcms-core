using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;
using System.Web.Optimization;

namespace DexCMS.Core.Mvc.HtmlHelpers
{
    public static class DexCMSRender
    {
        private static string Version = WebConfigurationManager.AppSettings["Version"];
        private static string VersionQueryString = WebConfigurationManager.AppSettings["VersionQueryString"];

        public static IHtmlString StylesWithVersion(params string[] paths)
        {
            return Styles.Render(AddVersionToPaths(paths));
        }

        public static IHtmlString ScriptsWithVersion(params string[] paths)
        {
            return Scripts.Render(AddVersionToPaths(paths));
        }

        private static string[] AddVersionToPaths(params string[] paths)
        {
            return paths.Select(x => BuildWithVersion(x)).ToArray();
        }

        private static string BuildWithVersion(string path)
        {
            return path + (path.Contains("?") ? "&" : "?") + VersionQueryString + "=" + Version;
        }
    }
}

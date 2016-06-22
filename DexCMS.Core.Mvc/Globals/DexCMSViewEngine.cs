using System.Web.Mvc;

namespace DexCMS.Core.Mvc.Globals
{
    public class DexCMSViewEngine : RazorViewEngine
    {
        public DexCMSViewEngine()
        {

            AreaViewLocationFormats = new[]
            {
                "~/Areas/{2}/Views/{1}/{0}.cshtml",
                "~/Areas/{2}/Views/Shared/{0}.cshtml",
                "~/Views/DexCMS-Areas/{2}/{1}/{0}.cshtml",
                "~/Views/DexCMS-Areas/{2}/Shared/{0}.cshtml"
            };
            AreaMasterLocationFormats = new[]
            {
                "~/Areas/{2}/Views/{1}/{0}.cshtml",
                "~/Areas/{2}/Views/Shared/{0}.cshtml",
                "~/Views/DexCMS-Areas/{2}/{1}/{0}.cshtml",
                "~/Views/DexCMS-Areas/{2}/Shared/{0}.cshtml"
            };
            AreaPartialViewLocationFormats = new[]
            {
                "~/Areas/{2}/Views/{1}/{0}.cshtml",
                "~/Areas/{2}/Views/Shared/{0}.cshtml",
                "~/Views/DexCMS-Areas/{2}/{1}/{0}.cshtml",
                "~/Views/DexCMS-Areas/{2}/Shared/{0}.cshtml"
            };

            ViewLocationFormats = new[]
            {
                "~/Views/{1}/{0}.cshtml",
                "~/Views/Shared/{0}.cshtml",
                "~/Views/DexCMS/{1}/{0}.cshtml",
                "~/Views/DexCMS/Shared/{0}.cshtml"
            };
            MasterLocationFormats = new[]
            {
                "~/Views/{1}/{0}.cshtml",
                "~/Views/Shared/{0}.cshtml",
                "~/Views/DexCMS/{1}/{0}.cshtml",
                "~/Views/DexCMS/Shared/{0}.cshtml"
            };
            PartialViewLocationFormats = new[]
            {
                "~/Views/{1}/{0}.cshtml",
                "~/Views/Shared/{0}.cshtml",
                "~/Views/DexCMS/{1}/{0}.cshtml",
                "~/Views/DexCMS/Shared/{0}.cshtml"
            };

            FileExtensions = new[]
            {
                "cshtml"
            };

        }
    }
}

using System.Web.Mvc;

namespace DexCMS.Core.Server.Globals
{
    public static class FiltersConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}

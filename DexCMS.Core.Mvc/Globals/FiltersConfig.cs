using System.Web.Mvc;

namespace DexCMS.Core.Mvc.Globals
{
    public static class FiltersConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}

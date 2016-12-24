using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace DexCMS.Core.Mvc
{
    public class DexCMSController: Controller
    {
            protected override void OnException(ExceptionContext filterContext)
            {
                Exception ex = filterContext.Exception;
                filterContext.ExceptionHandled = true;
            string route = "Error";

            if (ex.GetType() == typeof(HttpException) && ((HttpException)ex).ErrorCode == 404) {
                route = "NotFound";
            }

            filterContext.Result = RedirectToRoute(route);
                //var model = new HandleErrorInfo(filterContext.Exception, filterContext.RouteData.Values["Controller"].ToString(), filterContext.RouteData.Values["Action"].ToString());

                //filterContext.Result = new ViewResult()
                //{
                //    ViewName = "Error",
                //    ViewData = new ViewDataDictionary(model)
                //};
            
        }
    }
}

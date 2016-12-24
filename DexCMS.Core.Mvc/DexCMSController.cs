using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DexCMS.Core.Mvc
{
    public class DexCMSController: Controller
    {
            protected override void OnException(ExceptionContext filterContext)
            {
                Exception ex = filterContext.Exception;
                filterContext.ExceptionHandled = true;
            
                var model = new HandleErrorInfo(filterContext.Exception, filterContext.RouteData.Values["Controller"].ToString(), filterContext.RouteData.Values["Action"].ToString());

                filterContext.Result = new ViewResult()
                {
                    ViewName = "Error",
                    ViewData = new ViewDataDictionary(model)
                };

            }
    }
}

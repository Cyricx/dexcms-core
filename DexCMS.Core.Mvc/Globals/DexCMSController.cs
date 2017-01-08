using DexCMS.Core.Infrastructure;
using DexCMS.Core.Infrastructure.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace DexCMS.Core.Mvc.Globals
{
    public class DexCMSController : Controller
    {
        protected override void OnException(ExceptionContext filterContext)
        {
            filterContext.ExceptionHandled = true;
            Logger.WriteLog(LogType.Error, filterContext.Exception.StackTrace);
            filterContext.Result = RedirectToRoute("Error");
        }
    }
}

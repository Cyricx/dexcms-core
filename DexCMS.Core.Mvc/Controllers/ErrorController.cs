using DexCMS.Core;
using DexCMS.Core.Enums;
using DexCMS.Core.Mvc.Globals;
using System.Web.Mvc;

namespace DexCMS.Core.Mvc.Controllers
{

    public class ErrorController : DexCMSController
    {

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult NotFound()
        {
            Logger.WriteLog(LogType.PageNotFound, "Page Not Found: " + HttpContext.Request.RawUrl);
            return View();
        }
	}
}
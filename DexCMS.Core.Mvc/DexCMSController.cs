﻿using DexCMS.Core.Infrastructure;
using DexCMS.Core.Infrastructure.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace DexCMS.Core.Mvc
{
    public class DexCMSController : Controller
    {
        protected override void OnException(ExceptionContext filterContext)
        {
            Exception ex = filterContext.Exception;
            filterContext.ExceptionHandled = true;
            string route = "Error";
            Logger.WriteLog(LogType.Error, ex.StackTrace);
            filterContext.Result = RedirectToRoute(route);

        }
    }
}

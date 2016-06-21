using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;

namespace DexCMS.Core.Mvc.Globals
{
    public static class DexCMSBeginRequest
    {
        public static void ForceLowerCase(HttpRequest request, HttpResponse response)
        {
            //FORCE Lowercase urls (added primarily for angular html5 mode support)

            //You don't want to redirect on posts, or images/css/js
            bool isGet = HttpContext.Current.Request.RequestType.ToLowerInvariant().Contains("get");
            if (isGet && HttpContext.Current.Request.Url.AbsolutePath.Contains(".") == false)
            {
                string lowercaseURL = (request.Url.Scheme + "://" + HttpContext.Current.Request.Url.Authority + HttpContext.Current.Request.Url.AbsolutePath);
                if (Regex.IsMatch(lowercaseURL, @"[A-Z]"))
                {
                    //You don't want to change casing on query strings
                    lowercaseURL = lowercaseURL.ToLower() + HttpContext.Current.Request.Url.Query;

                    response.Clear();
                    response.Status = "301 Moved Permanently";
                    response.AddHeader("Location", lowercaseURL);
                    response.End();
                }
            }
        }
    }
}

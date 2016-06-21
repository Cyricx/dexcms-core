using DexCMS.Core.Infrastructure.Globals;
using Microsoft.AspNet.Identity.Owin;
using System.Web;
using System.Web.Mvc;

namespace DexCMS.Core.Mvc
{
    public class ApplicationOwinContext:Controller
    {
        public ApplicationUserManager GetApplicationOwinContext()
        {
           return HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
        }
    }
}

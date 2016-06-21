using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TTCMS.Server.Globals;

namespace DexCMS.Core.Server
{
    public class ApplicationOwinContext:Controller
    {
        public ApplicationUserManager GetApplicationOwinContext()
        {
           return HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
        }
    }
}

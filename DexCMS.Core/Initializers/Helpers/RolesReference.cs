using DexCMS.Core.Contexts;
using DexCMS.Core.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DexCMS.Core.Initializers.Helpers
{
    public class RolesReference
    {
        public ApplicationRole Admin { get; set; }
        public ApplicationRole Installer { get; set; }

        public RolesReference(IDexCMSCoreContext Context)
        {
            Admin = Context.RoleManager.FindByName("Admin");
            Installer = Context.RoleManager.FindByName("Installer");
        }
    }
}

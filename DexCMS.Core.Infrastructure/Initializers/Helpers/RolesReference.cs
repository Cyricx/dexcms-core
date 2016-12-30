using DexCMS.Core.Infrastructure.Contexts;
using Microsoft.AspNet.Identity;

namespace DexCMS.Core.Infrastructure.Initializers.Helpers
{
    public class RolesReference
    {
        public string Admin { get; set; }
        public string Installer { get; set; }

        public RolesReference(IDexCMSCoreContext Context)
        {
            Admin = Context.RoleManager.FindByName("Admin").Id;
            Installer = Context.RoleManager.FindByName("Installer").Id;
        }
    }
}

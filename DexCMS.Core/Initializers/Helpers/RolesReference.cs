using DexCMS.Core.Contexts;
using Microsoft.AspNet.Identity;

namespace DexCMS.Core.Initializers.Helpers
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

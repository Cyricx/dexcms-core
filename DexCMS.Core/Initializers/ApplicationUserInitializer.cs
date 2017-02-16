using DexCMS.Core.Contexts;
using DexCMS.Core.Globals;
using DexCMS.Core.Initializers.Helpers;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DexCMS.Core.Initializers
{
    class ApplicationUserInitializer:DexCMSInitializer<IDexCMSCoreContext>
    {
        private IdentityHelper Helper;
        private RolesReference Roles;

        public ApplicationUserInitializer(IDexCMSCoreContext context): base (context)
        {
            Helper = new IdentityHelper(context);
            Roles = new RolesReference(context);
        }

        public override void Run(bool addDemoContent = true)
        {
            if (addDemoContent)
            {
                Helper.CreateUserIfNotExists("installer@chrisbyram.com", "Dexcms@123", new IdentityRole[] { Roles.Admin, Roles.Installer });
                Helper.CreateUserIfNotExists("admin@chrisbyram.com", "Dexcms@123", new IdentityRole[] { Roles.Admin });
                Helper.CreateUserIfNotExists("tester@chrisbyram.com", "Dexcms@123");
            }
        }
    }
}

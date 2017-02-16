using DexCMS.Core.Contexts;
using DexCMS.Core.Globals;
using DexCMS.Core.Initializers.Helpers;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DexCMS.Core.Initializers
{
    class ApplicationRoleInitializer : DexCMSInitializer<IDexCMSCoreContext>
    {
        private IdentityHelper Helper;

        public ApplicationRoleInitializer(IDexCMSCoreContext context): base (context)
        {
            Helper = new IdentityHelper(context);
        }

        public override void Run(bool addDemoContent = true)
        {
            IdentityRole admin = Helper.CreateRole("Admin");
            IdentityRole installer = Helper.CreateRole("Installer");

        }
    }
}

using DexCMS.Core.Contexts;
using DexCMS.Core.Globals;
using DexCMS.Core.Initializers.Helpers;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DexCMS.Core.Initializers
{
    class IdentityInitializer:DexCMSInitializer<IDexCMSCoreContext>
    {
        public IdentityHelper Helper { get; set; }

        public IdentityInitializer(IDexCMSCoreContext context): base (context)
        {
            Helper = new IdentityHelper(context);
        }

        public override void Run(bool addDemoContent = true)
        {
            InitializeIdentityForEF(Context, addDemoContent);
        }

        public void InitializeIdentityForEF(IDexCMSCoreContext db, bool addDemoContent)
        {
            IdentityRole admin = Helper.CreateRole("Admin");
            IdentityRole installer = Helper.CreateRole("Installer");

            if (addDemoContent)
            {
                Helper.CreateUserIfNotExists("Installer@chrisbyram.com", "Dexcms@123", new IdentityRole[] { admin, installer });
                Helper.CreateUserIfNotExists("tester@chrisbyram.com", "Dexcms@123");
            }
        }
    }
}

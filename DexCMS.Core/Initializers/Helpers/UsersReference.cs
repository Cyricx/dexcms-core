using DexCMS.Core.Contexts;
using DexCMS.Core.Models;
using Microsoft.AspNet.Identity;

namespace DexCMS.Core.Initializers.Helpers
{
    public class UsersReference
    {
        public ApplicationUser Admin { get; set; }
        public ApplicationUser Installer { get; set; }
        public ApplicationUser Tester { get; set; }

        public UsersReference(IDexCMSCoreContext Context)
        {
            Installer = Context.UserManager.FindByEmail("installer@chrisbyram.com");
            Admin = Context.UserManager.FindByEmail("admin@chrisbyram.com");
            Tester = Context.UserManager.FindByEmail("tester@chrisbyram.com");
        }
    }
}

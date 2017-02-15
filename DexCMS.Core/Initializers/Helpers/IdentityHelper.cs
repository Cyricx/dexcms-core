using DexCMS.Core.Contexts;
using DexCMS.Core.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DexCMS.Core.Initializers.Helpers
{
    public class IdentityHelper
    {
        private IDexCMSCoreContext Context;

        public IdentityHelper(IDexCMSCoreContext context)
        {
            Context = context;
        }

        public void AddRolesToUser(IdentityRole[] roles, ApplicationUser user)
        {
            var rolesForUser = Context.UserManager.GetRoles(user.Id);
            foreach (var role in roles)
            {
                if (!rolesForUser.Contains(role.Name))
                {
                    var result = Context.UserManager.AddToRole(user.Id, role.Name);
                }
            }
        }

        public ApplicationUser CreateUserIfNotExists(string name, string password, IdentityRole[] roles = null)
        {
            var user = Context.UserManager.FindByName(name);

            if (user == null)
            {
                user = new ApplicationUser { UserName = name, Email = name, EmailConfirmed = true };
                var result = Context.UserManager.Create(user, password);
                result = Context.UserManager.SetLockoutEnabled(user.Id, false);
            }
            if (roles != null && roles.Length > 0)
            {
                AddRolesToUser(roles, user);
            }
            return user;
        }

        public IdentityRole CreateRole(string roleName)
        {
            var role = Context.RoleManager.FindByName(roleName);
            if (role == null)
            {
                role = new ApplicationRole(roleName);
                var roleresult = Context.RoleManager.Create(role);
            }
            return role;
        }

    }
}

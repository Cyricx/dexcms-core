using DexCMS.Core.Infrastructure.Contexts;
using DexCMS.Core.Infrastructure.Globals;
using DexCMS.Core.Infrastructure.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;

namespace DexCMS.Core.Infrastructure.Initializers
{
    class IdentityInitializer:DexCMSInitializer<IDexCMSCoreContext>
    {
        public IdentityInitializer(IDexCMSCoreContext context): base (context)
        {
        }

        public override void Run(bool addDemoContent = true)
        {
            InitializeIdentityForEF(Context, addDemoContent);
        }

        public void InitializeIdentityForEF(IDexCMSCoreContext db, bool addDemoContent)
        {

            string[] roleNames = { "Admin", "Installer" };
            List<IdentityRole> roles = CreateRoles(roleNames);

            if (addDemoContent)
            {
                const string name = "Installer@chrisbyram.com";
                const string password = "Dexcms@123";
                ApplicationUser user = CreateUserIfNotExists(name, password);
                AddRolesToUser(roles, user);
            }
        }

        private void AddRolesToUser(List<IdentityRole> roles, ApplicationUser user)
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

        private ApplicationUser CreateUserIfNotExists(string name, string password)
        {
            var user = Context.UserManager.FindByName(name);
            if (user == null)
            {
                user = new ApplicationUser { UserName = name, Email = name, EmailConfirmed = true };
                var result = Context.UserManager.Create(user, password);
                result = Context.UserManager.SetLockoutEnabled(user.Id, false);
            }

            return user;
        }

        private List<IdentityRole> CreateRoles(string[] roleNames)
        {
            List<IdentityRole> roles = new List<IdentityRole>();
            foreach (var roleName in roleNames)
            {
                var role = Context.RoleManager.FindByName(roleName);
                if (role == null)
                {
                    role = new ApplicationRole(roleName);
                    var roleresult = Context.RoleManager.Create(role);
                }
                roles.Add(role);
            }

            return roles;
        }

    }
}

using DexCMS.Core.Infrastructure.Contexts;
using DexCMS.Core.Infrastructure.Globals;
using DexCMS.Core.Infrastructure.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Web;

namespace DexCMS.Core.Infrastructure.Initializers
{
    class IdentityInitializer
    {
        public DexCMSContext Context { get; set; }
        public IdentityInitializer(DexCMSContext context)
        {
            Context = context;
        }

        public void Run()
        {
            InitializeIdentityForEF(Context);
        }

        public static void InitializeIdentityForEF(DexCMSContext db)
        {
            //ApplicationUserManager userManager = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            UserManager<ApplicationUser> userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            //ApplicationRoleManager roleManager = HttpContext.Current.GetOwinContext().Get<ApplicationRoleManager>();
            RoleManager<ApplicationRole> roleManager = new RoleManager<ApplicationRole>(new RoleStore<ApplicationRole>(db));

            const string name = "Installer@chrisbyram.com";
            const string password = "Dexcms@123";
            string[] roleNames = { "Admin", "Installer" };

            List<IdentityRole> roles = CreateRoles(roleManager, roleNames);

            ApplicationUser user = CreateUserIfNotExists(userManager, name, password);

            AddRolesToUser(userManager, roles, user);
        }

        private static void AddRolesToUser(UserManager<ApplicationUser> userManager, List<IdentityRole> roles, ApplicationUser user)
        {
            var rolesForUser = userManager.GetRoles(user.Id);
            foreach (var role in roles)
            {
                if (!rolesForUser.Contains(role.Name))
                {
                    var result = userManager.AddToRole(user.Id, role.Name);
                }
            }
        }

        private static ApplicationUser CreateUserIfNotExists(UserManager<ApplicationUser> userManager, string name, string password)
        {
            var user = userManager.FindByName(name);
            if (user == null)
            {
                user = new ApplicationUser { UserName = name, Email = name, EmailConfirmed = true };
                var result = userManager.Create(user, password);
                result = userManager.SetLockoutEnabled(user.Id, false);
            }

            return user;
        }

        private static List<IdentityRole> CreateRoles(RoleManager<ApplicationRole> roleManager, string[] roleNames)
        {
            List<IdentityRole> roles = new List<IdentityRole>();
            foreach (var roleName in roleNames)
            {
                var role = roleManager.FindByName(roleName);
                if (role == null)
                {
                    role = new ApplicationRole(roleName);
                    var roleresult = roleManager.Create(role);
                }
                roles.Add(role);
            }

            return roles;
        }

    }
}

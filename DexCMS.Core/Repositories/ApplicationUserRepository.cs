using DexCMS.Core.Globals;
using DexCMS.Core.Interfaces;
using DexCMS.Core.Models;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;

namespace DexCMS.Core.Repositories
{
    public class ApplicationUserRepository: IApplicationUserRepository
    {
        private ApplicationUserManager _userManager;
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        public IQueryable<ApplicationUser> Items
        {
            get { return UserManager.Users;  }
        }

        public Task<ApplicationUser> RetrieveAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return null;
            }
            else
            {
                return UserManager.FindByIdAsync(id);
            }
        }

        public async Task<IdentityResult> UpdateAsync(ApplicationUser item, string id)
        {
            var result = await UserManager.UpdateAsync(item);

            return result;
        }

        public Task<IdentityResult> AddAsync(ApplicationUser item)
        {
            return UserManager.CreateAsync(item);
        }

        public Task<IdentityResult> DeleteAsync(ApplicationUser item)
        {
            return UserManager.DeleteAsync(item);
        }

        public async Task<IdentityResult> UpdateRolesAsync(string id, string[] newRoleIds)
        {
            var user = await RetrieveAsync(id);

            var userRoles = await UserManager.GetRolesAsync(id);

            var result = await UserManager.AddToRolesAsync(user.Id, newRoleIds.Except(userRoles).ToArray<string>());

            if (result.Succeeded)
            {
                result = await UserManager.RemoveFromRolesAsync(user.Id, userRoles.Except(newRoleIds).ToArray<string>());
            }

            return result;
        }
        
        public async Task<IdentityResult> UpdateRolesAsync(ApplicationUser user, string[] newRoleIds)
        {
            var userRoles = await UserManager.GetRolesAsync(user.Id);
            string[] rolesToAdd = newRoleIds.Except(userRoles).ToArray<string>();
            string[] rolesToRemove = userRoles.Except(newRoleIds).ToArray<string>();

            var result = await UserManager.AddToRolesAsync(user.Id, rolesToAdd);

            if (result.Succeeded)
            {
                result = await UserManager.RemoveFromRolesAsync(user.Id, rolesToRemove);
            }

            return result;

        }
    }
}

﻿using DexCMS.Core.Infrastructure.Globals;
using DexCMS.Core.Infrastructure.Interfaces;
using DexCMS.Core.Infrastructure.Models;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;

namespace DexCMS.Core.Infrastructure.Repositories
{
    public class UserRepository: IUserRepository
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
    }
}
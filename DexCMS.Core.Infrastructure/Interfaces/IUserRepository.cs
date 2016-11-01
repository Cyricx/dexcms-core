using DexCMS.Core.Infrastructure.Globals;
using DexCMS.Core.Infrastructure.Models;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DexCMS.Core.Infrastructure.Interfaces
{
    public interface IUserRepository
    {
        ApplicationUserManager UserManager { get; }
        IQueryable<ApplicationUser> Items { get; }
        Task<ApplicationUser> RetrieveAsync(string id);
        Task<IdentityResult> UpdateAsync(ApplicationUser item, string id);
        Task<IdentityResult> AddAsync(ApplicationUser item);
        Task<IdentityResult> DeleteAsync(ApplicationUser item);
        Task<IdentityResult> UpdateRolesAsync(string id, string[] newRoleIds);
        Task<IdentityResult> UpdateRolesAsync(ApplicationUser user, string[] newRoleIds);
    }
}

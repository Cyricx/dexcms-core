using DexCMS.Core.Infrastructure.Globals;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity.EntityFramework;
using DexCMS.Core.Infrastructure.Interfaces;
using Microsoft.AspNet.Identity;
using DexCMS.Core.Infrastructure.Models;

namespace DexCMS.Core.Infrastructure.Repositories
{
    public class RoleRepository: IRoleRepository
    {
        private ApplicationRoleManager _roleManager;
        public ApplicationRoleManager RoleManager
        {
            get
            {
                return _roleManager ?? HttpContext.Current.GetOwinContext().Get<ApplicationRoleManager>();
            }
            private set
            {
                _roleManager = value;
            }
        }

        public IQueryable<ApplicationRole> Items
        {
            get { return RoleManager.Roles; }
        }

        public Task<ApplicationRole> RetrieveAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return null;
            } else {
                return RoleManager.FindByIdAsync(id);
            }
        }

        public Task<IdentityResult> UpdateAsync(ApplicationRole item, string id)
        {
            return RoleManager.UpdateAsync(item);
        }

        public Task<IdentityResult> AddAsync(ApplicationRole item)
        {
            return RoleManager.CreateAsync(item);
        }

        public Task<IdentityResult> DeleteAsync(ApplicationRole item)
        {
            return RoleManager.DeleteAsync(item);
        }
    }
}

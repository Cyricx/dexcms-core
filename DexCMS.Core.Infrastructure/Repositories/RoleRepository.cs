using DexCMS.Core.Infrastructure.Globals;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity.EntityFramework;
using DexCMS.Core.Infrastructure.Interfaces;
using Microsoft.AspNet.Identity;

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

        public IQueryable<IdentityRole> Items
        {
            get { return RoleManager.Roles; }
        }

        public Task<IdentityRole> RetrieveAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return null;
            } else {
                return RoleManager.FindByIdAsync(id);
            }
        }

        public Task<IdentityResult> UpdateAsync(IdentityRole item, string id)
        {
            return RoleManager.UpdateAsync(item);
        }

        public Task<IdentityResult> AddAsync(IdentityRole item)
        {
            return RoleManager.CreateAsync(item);
        }

        public Task<IdentityResult> DeleteAsync(IdentityRole item)
        {
            return RoleManager.DeleteAsync(item);
        }
    }
}

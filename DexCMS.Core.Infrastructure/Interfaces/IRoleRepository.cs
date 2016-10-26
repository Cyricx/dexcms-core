using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DexCMS.Core.Infrastructure.Interfaces
{
    public interface IRoleRepository
    {
        IQueryable<IdentityRole> Items { get; }
        Task<IdentityRole> RetrieveAsync(string id);
        Task<IdentityResult> UpdateAsync(IdentityRole item, string id);
        Task<IdentityResult> AddAsync(IdentityRole item);
        Task<IdentityResult> DeleteAsync(IdentityRole item);
    }
}

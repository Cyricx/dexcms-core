using DexCMS.Core.Infrastructure.Models;
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
        IQueryable<ApplicationRole> Items { get; }
        Task<ApplicationRole> RetrieveAsync(string id);
        Task<IdentityResult> UpdateAsync(ApplicationRole item, string id);
        Task<IdentityResult> AddAsync(ApplicationRole item);
        Task<IdentityResult> DeleteAsync(ApplicationRole item);
    }
}

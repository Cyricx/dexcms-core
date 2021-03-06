﻿using DexCMS.Core.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DexCMS.Core.Interfaces
{
    public interface IApplicationRoleRepository
    {
        IQueryable<ApplicationRole> Items { get; }
        Task<ApplicationRole> RetrieveAsync(string id);
        Task<IdentityResult> UpdateAsync(ApplicationRole item, string id);
        Task<IdentityResult> AddAsync(ApplicationRole item);
        Task<IdentityResult> DeleteAsync(ApplicationRole item);
    }
}

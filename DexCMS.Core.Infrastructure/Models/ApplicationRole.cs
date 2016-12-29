using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DexCMS.Core.Infrastructure.Models
{
    public class ApplicationRole : IdentityRole
    {

        public ApplicationRole(string roleName) : base(roleName) { }
        public ApplicationRole() { }
    }
}

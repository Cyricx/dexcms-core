using DexCMS.Core.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DexCMS.Core.Contexts
{
    public class DexCMSContext: IdentityDbContext<ApplicationUser>, IDexCMSCoreContext
    {
        private UserManager<ApplicationUser> _userManager;
        private RoleManager<ApplicationRole> _roleManager;

        public DexCMSContext() : base("ConnectionString", throwIfV1Schema: false) { }

        public DbSet<Log> Logs { get; set; }
        public DbSet<SettingDataType> SettingDataTypes { get; set; }
        public DbSet<SettingGroup> SettingGroups { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Image> Images { get; set; }

        public UserManager<ApplicationUser> UserManager
        {
            get
            {
                if (_userManager == null)
                {
                    _userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(this));
                }
                return  _userManager;
            }
        }

        public RoleManager<ApplicationRole> RoleManager
        {
            get
            {
                if (_roleManager == null)
                {
                    _roleManager = new RoleManager<ApplicationRole>(new RoleStore<ApplicationRole>(this));
                }
                return _roleManager;
            }
        }

        public static DexCMSContext Create()
        {
            return new DexCMSContext();
        }
    }
}

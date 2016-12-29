using DexCMS.Core.Infrastructure.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DexCMS.Core.Infrastructure.Contexts
{
    public class DexCMSContext: IdentityDbContext<ApplicationUser>, IDexCMSCoreContext
    {
        public DexCMSContext() : base("ConnectionString", throwIfV1Schema: false) { }

        public DbSet<Log> Logs { get; set; }
        public DbSet<SettingDataType> SettingDataTypes { get; set; }
        public DbSet<SettingGroup> SettingGroups { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Image> Images { get; set; }

        public static DexCMSContext Create()
        {
            return new DexCMSContext();
        }
    }
}

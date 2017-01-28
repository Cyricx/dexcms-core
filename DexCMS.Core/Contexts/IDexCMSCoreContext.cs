using DexCMS.Core.Models;
using Microsoft.AspNet.Identity;
using System.Data.Entity;

namespace DexCMS.Core.Contexts
{
    public interface IDexCMSCoreContext: IDexCMSContext
    {
        DbSet<Log> Logs { get; set; }
        DbSet<SettingDataType> SettingDataTypes { get; set; }
        DbSet<SettingGroup> SettingGroups { get; set; }
        DbSet<Setting> Settings { get; set; }
        DbSet<State> States { get; set; }
        DbSet<Country> Countries { get; set; }
        DbSet<Image> Images { get; set; }
        RoleManager<ApplicationRole> RoleManager { get; }
        UserManager<ApplicationUser> UserManager { get; }
    }
}

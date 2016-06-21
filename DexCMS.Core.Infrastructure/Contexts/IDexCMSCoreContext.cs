using DexCMS.Core.Infrastructure.Models;
using System.Data.Entity;

namespace DexCMS.Core.Infrastructure.Contexts
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
    }
}

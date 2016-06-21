using DexCMS.Core.Infrastructure.Models;

namespace DexCMS.Core.Infrastructure.Interfaces
{
    public interface ISettingRepository:IRepository<Setting>
    {
        string GetValue(string settingName);
    }
}

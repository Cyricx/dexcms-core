using DexCMS.Core.Models;

namespace DexCMS.Core.Interfaces
{
    public interface ISettingRepository:IRepository<Setting>
    {
        string GetValue(string settingName);
    }
}

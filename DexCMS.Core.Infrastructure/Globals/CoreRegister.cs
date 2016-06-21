using DexCMS.Core.Infrastructure.Contexts;
using DexCMS.Core.Infrastructure.Interfaces;
using DexCMS.Core.Infrastructure.Repositories;
using Ninject;

namespace DexCMS.Core.Infrastructure.Globals
{
    public static class CoreRegister<T> where T : IDexCMSCoreContext
    {
        public static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<ILogRepository>().To<LogRepository>();
            kernel.Bind<ISettingDataTypeRepository>().To<SettingDataTypeRepository>();
            kernel.Bind<ISettingGroupRepository>().To<SettingGroupRepository>();
            kernel.Bind<ISettingRepository>().To<SettingRepository>();
            kernel.Bind<ICountryRepository>().To<CountryRepository>();
            kernel.Bind<IImageRepository>().To<ImageRepository>();
            kernel.Bind<IStateRepository>().To<StateRepository>();
            kernel.Bind<IDexCMSCoreContext>().To<T>();
        }
    }
}

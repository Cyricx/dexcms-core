using DexCMS.Core.Contexts;
using DexCMS.Core.Interfaces;
using DexCMS.Core.Repositories;
using Ninject;

namespace DexCMS.Core.Globals
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
            kernel.Bind<IApplicationRoleRepository>().To<ApplicationRoleRepository>();
            kernel.Bind<IApplicationUserRepository>().To<ApplicationUserRepository>();
            kernel.Bind<IDexCMSCoreContext>().To<T>();
        }
    }
}

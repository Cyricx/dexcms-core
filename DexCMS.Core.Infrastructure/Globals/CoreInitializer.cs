using DexCMS.Core.Infrastructure.Contexts;
using DexCMS.Core.Infrastructure.Globals.Initializers;

namespace DexCMS.Core.Infrastructure.Globals
{
    public static class CoreInitializer
    {
        public static void Initialize(IDexCMSCoreContext context)
        {

            //! Setting Data Types
            SettingDataTypeInitializer.Run(context);

            //! Setting Groups
            SettingGroupInitializer.Run(context);

            //! Settings
            SettingInitializer.Run(context);

            //! Countries
            CountryInitializer.Run(context);

            //! States
            StateInitializer.Run(context);

        }

    }
}

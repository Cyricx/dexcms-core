using DexCMS.Core.Infrastructure.Contexts;
using DexCMS.Core.Infrastructure.Globals.Initializers;

namespace DexCMS.Core.Infrastructure.Globals
{
    public class CoreInitializer: DexCMSInitializer<IDexCMSCoreContext>
    {
        public CoreInitializer(IDexCMSCoreContext context) : base(context)
        {
        }

        public override void Run()
        {
            (new SettingDataTypeInitializer(Context)).Run();
            (new SettingGroupInitializer(Context)).Run();
            (new SettingInitializer(Context)).Run();
            (new CountryInitializer(Context)).Run();
            (new StateInitializer(Context)).Run();
        }
    }
}

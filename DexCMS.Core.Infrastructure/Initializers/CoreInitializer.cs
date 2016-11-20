using DexCMS.Core.Infrastructure.Contexts;
using DexCMS.Core.Infrastructure.Globals;

namespace DexCMS.Core.Infrastructure.Initializers
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

using DexCMS.Core.Infrastructure.Contexts;
using DexCMS.Core.Infrastructure.Models;

namespace DexCMS.Core.Infrastructure.Initializers
{
    public class CoreInitializer
    {
        public DexCMSContext Context { get; set; }
        public CoreInitializer(DexCMSContext context) 
        {
            Context = context;
        }

        public void Run()
        {
            (new IdentityInitializer(Context)).Run();
            (new SettingDataTypeInitializer(Context)).Run();
            (new SettingGroupInitializer(Context)).Run();
            (new SettingInitializer(Context)).Run();
            (new CountryInitializer(Context)).Run();
            (new StateInitializer(Context)).Run();
            (new ImageInitializer(Context)).Run();
        }
    }
}

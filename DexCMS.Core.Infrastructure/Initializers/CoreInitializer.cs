using System;
using System.Collections.Generic;
using DexCMS.Core.Infrastructure.Contexts;
using DexCMS.Core.Infrastructure.Globals;

namespace DexCMS.Core.Infrastructure.Initializers
{
    public class CoreInitializer: DexCMSLibraryInitializer<IDexCMSCoreContext>
    {
        public CoreInitializer(IDexCMSCoreContext context) : base(context)
        {
        }

        public override List<Type> Initializers
        {
            get
            {
                return new List<Type>
                {
                    typeof(IdentityInitializer),
                    typeof(SettingDataTypeInitializer),
                    typeof(SettingGroupInitializer),
                    typeof(SettingInitializer),
                    typeof(CountryInitializer),
                    typeof(StateInitializer),
                    typeof(ImageInitializer)
                };
            }
        }
    }
}

using DexCMS.Core.Contexts;
using DexCMS.Core.Globals;
using System;
using System.Collections.Generic;

namespace DexCMS.Core.Mvc.Initializers
{
    public class CoreMvcInitializer: DexCMSLibraryInitializer<IDexCMSCoreContext>
    {
        public CoreMvcInitializer(IDexCMSCoreContext context) : base(context) { }

        public override List<Type> Initializers
        {
            get
            {
                return new List<Type>();
            }
        }

    }
}

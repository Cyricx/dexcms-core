using DexCMS.Core.Contexts;
using System;
using System.Reflection;

namespace DexCMS.Core.Globals
{
    public static class DexCMSApplicationInitializer
    {

        public static void InitializeApplication(IDexCMSContext Context, string[] modules, bool addDemoContent = true)
        {
            foreach (var module in modules)
            {
                ExecuteModule(Context, module, addDemoContent);
            }
        }

        private static void ExecuteModule(IDexCMSContext Context, string module, bool addDemoContent)
        {
            string baseModule = string.Format("DexCMS.{0}.Initializers.{0}Initializer, DexCMS.{0}, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", module);
            string mvcModule = string.Format("DexCMS.{0}.Mvc.Initializers.{0}MvcInitializer, DexCMS.{0}.Mvc, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", module);

            ExecuteLibrary(Context, baseModule, addDemoContent);
            ExecuteLibrary(Context, mvcModule, addDemoContent);
        }

        private static void ExecuteLibrary(IDexCMSContext Context, string module, bool addDemoContent)
        {
            Type modClass = Type.GetType(module);
            if (modClass != null)
            {
                var instance = Activator.CreateInstance(modClass, Context);
                MethodInfo method = modClass.GetMethod("Run");
                method.Invoke(instance, new object[] { addDemoContent });
            }
        }
    }
}

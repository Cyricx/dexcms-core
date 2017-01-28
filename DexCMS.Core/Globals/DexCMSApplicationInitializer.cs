using DexCMS.Core.Contexts;
using System;

namespace DexCMS.Core.Globals
{
    public class DexCMSApplicationInitializer<T> where T : IDexCMSContext
    {
        private T _context;

        public T Context
        {
            get { return _context; }
        }

        public DexCMSApplicationInitializer(T context)
        {
            _context = context;
        }

        public void InitializeApplication(IDexCMSContext context, string[] modules, bool addDemoContent = true)
        {
            foreach (var module in modules)
            {
                ExecuteModule(module, addDemoContent);
            }
        }

        private void ExecuteModule(string module, bool addDemoContent)
        {
            string baseModule = string.Format("DexCMS.{0}.Initializers.{0}Initializer", module);
            string mvcModule = string.Format("DexCMS.{0}.Mvc.Initializers.{0}MvcInitializer", module);

            ExecuteLibrary(baseModule, addDemoContent);
            ExecuteLibrary(mvcModule, addDemoContent);
        }

        private void ExecuteLibrary(string module, bool addDemoContent)
        {
            Type modClass = Type.GetType(module);
            ((DexCMSLibraryInitializer<T>)Activator.CreateInstance(modClass, Context)).Run(addDemoContent);
        }
    }
}

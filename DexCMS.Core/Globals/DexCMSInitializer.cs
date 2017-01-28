using DexCMS.Core.Contexts;

namespace DexCMS.Core.Globals
{
    public abstract class DexCMSInitializer<T> where T : IDexCMSContext
    {
        private T _context;

        public T Context
        {
            get { return _context; }
        }

        public DexCMSInitializer(T context)
        {
            _context = context;
        }

        public abstract void Run(bool addDemoContent = true);

    }
}

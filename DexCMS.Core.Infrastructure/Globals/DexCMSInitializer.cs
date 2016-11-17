using DexCMS.Core.Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DexCMS.Core.Infrastructure.Globals
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

        public abstract void Run();
    }
}

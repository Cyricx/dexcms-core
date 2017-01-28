using DexCMS.Core.Contexts;
using System;
using System.Collections.Generic;

namespace DexCMS.Core.Globals
{
    public abstract class DexCMSLibraryInitializer<T> where T : IDexCMSContext
    {
        private T _context;

        public T Context
        {
            get { return _context; }
        }

        public DexCMSLibraryInitializer(T context)
        {
            _context = context;
        }

        public virtual void Run(bool addDemoContent = true)
        {
            Initializers.ForEach(x =>
                ((DexCMSInitializer<T>)Activator.CreateInstance(x, Context)).Run(addDemoContent)
            );
        }

        public abstract List<Type> Initializers { get; }
    }
}

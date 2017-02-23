using System.Collections.Generic;

namespace DexCMS.Core.Globals
{
    public abstract class DexCMSViewModel<V, M>
    {
        public static List<V> MapForClient(IEnumerable<M> models)
        {
            return DexCMSModelMapper<M>.MapForClient<V>(models);
        }

        public static V MapForClient(M model)
        {
            return DexCMSModelMapper<M>.MapForClient<V>(model);
        }

        public static void MapForServer(V viewModel, M model)
        {
            DexCMSModelMapper<M>.MapForServer(viewModel, model);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DexCMS.Core.Infrastructure.Models
{
    public class DexCMSConfiguration
    {
        public Dictionary<string, object> Configurations { get; set; }

        public T RetrieveValue<T>(string key)
        {
            if (Configurations.ContainsKey(key) && Configurations[key].GetType() == typeof(T))
            {
                return (T)Configurations[key];
            }
            else
            {
                return default(T);
            }
        }

        public DexCMSConfiguration()
        {
            Configurations = new Dictionary<string, object>();
        }
    }
}

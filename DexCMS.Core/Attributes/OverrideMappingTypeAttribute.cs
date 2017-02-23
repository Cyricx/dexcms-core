using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DexCMS.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class OverrideMappingTypeAttribute: Attribute
    {
        private readonly MappingType _mappingType;

        public OverrideMappingTypeAttribute(MappingType mappingType)
        {
            _mappingType = mappingType;
        }

        public MappingType MappingType { get { return _mappingType;  } }
    }

    public enum MappingType
    {
        ServerAndClient,
        ClientOnly,
        NoMappings
    }
}

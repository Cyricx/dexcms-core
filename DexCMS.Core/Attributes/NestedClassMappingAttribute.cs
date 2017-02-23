using System;

namespace DexCMS.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class NestedClassMappingAttribute : Attribute
    {
        private readonly Type _mapType;
        private readonly bool _isList;

        public NestedClassMappingAttribute(Type mapType, bool isList = false)
        {
            _mapType = mapType;
            _isList = isList;
        }

        public Type MapType
        {
            get { return _mapType; }
        }

        public bool IsList
        {
            get { return _isList; }
        }
    }
}

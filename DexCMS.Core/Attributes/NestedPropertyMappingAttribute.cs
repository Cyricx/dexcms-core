using System;

namespace DexCMS.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class NestedPropertyMappingAttribute : Attribute
    {
        private readonly string _baseProperty;
        private readonly string _childProperty;

        public NestedPropertyMappingAttribute(string baseProperty, string childProperty)
        {
            _baseProperty = baseProperty;
            _childProperty = childProperty;
        }

        public string BaseProperty
        {
            get { return _baseProperty; }
        }
        public string ChildProperty
        {
            get { return _childProperty; }
        }
    }
}

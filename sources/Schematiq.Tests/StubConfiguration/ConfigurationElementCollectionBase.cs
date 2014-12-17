namespace Schematiq.Tests.StubConfiguration
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;

    public abstract class ConfigurationElementCollectionBase<TElement> : ConfigurationElementCollection
        where TElement : ConfigurationElement, new()
    {
        private readonly Func<TElement, object> _keyAccessor;

        protected ConfigurationElementCollectionBase(string elementName, Func<TElement, object> keyAccessor)
        {
            ElementName = elementName;
            _keyAccessor = keyAccessor;
        }

        protected override string ElementName { get; }

        public override ConfigurationElementCollectionType CollectionType
            => ConfigurationElementCollectionType.BasicMap;

        public virtual IEnumerable<TElement> ChildElements
        {
            get
            {
                for (var i = 0; i < Count; i++)
                    yield return this[i];
            }
        }

        public virtual TElement this[int index]
        {
            get { return (TElement) BaseGet(index); }
            set
            {
                if (BaseGet(index) != null)
                    BaseRemoveAt(index);

                BaseAdd(index, value);
            }
        }

        public new TElement this[string name]
            => (TElement) BaseGet(name);

        protected override ConfigurationElement CreateNewElement()
        {
            return new TElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return _keyAccessor(((TElement) element));
        }
    }
}
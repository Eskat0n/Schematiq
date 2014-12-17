namespace Schematiq.Tests.StubConfiguration
{
    using System;
    using System.Configuration;

    [ConfigurationCollection(typeof (BookElement), AddItemName = "book",
        CollectionType = ConfigurationElementCollectionType.BasicMap)]
    public class BookElementCollection : ConfigurationElementCollection
    {
        public override ConfigurationElementCollectionType CollectionType
            => ConfigurationElementCollectionType.BasicMap;

        protected override string ElementName
            => "book";

        public BookElement this[int index]
        {
            get { return (BookElement) BaseGet(index); }
            set
            {
                if (BaseGet(index) != null)
                    BaseRemoveAt(index);

                BaseAdd(index, value);
            }
        }

        public new BookElement this[string name]
            => (BookElement) BaseGet(name);

        protected override ConfigurationElement CreateNewElement()
        {
            return new BookElement();
        }

        protected override Object GetElementKey(ConfigurationElement element)
        {
            return ((BookElement) element).Title;
        }
    }
}
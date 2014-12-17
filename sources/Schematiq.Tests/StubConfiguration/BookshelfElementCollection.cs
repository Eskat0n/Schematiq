namespace Schematiq.Tests.StubConfiguration
{
    using System;
    using System.Configuration;

    [ConfigurationCollection(typeof(BookshelfElement), AddItemName = "bookshelf", CollectionType = ConfigurationElementCollectionType.BasicMap)]
    public class BookshelfElementCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new BookshelfElement();
        }

        protected override Object GetElementKey(ConfigurationElement element)
        {
            return ((BookshelfElement)element).Name;
        }

        public override ConfigurationElementCollectionType CollectionType
            => ConfigurationElementCollectionType.BasicMap;

        protected override string ElementName
            => "bookshelf";

        public BookshelfElement this[int index]
        {
            get
            {
                return (BookshelfElement)BaseGet(index);
            }
            set
            {
                if (BaseGet(index) != null)
                    BaseRemoveAt(index);

                BaseAdd(index, value);
            }
        }

        new public BookshelfElement this[string name]
            => (BookshelfElement)BaseGet(name);
    }
}
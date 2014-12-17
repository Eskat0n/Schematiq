namespace Schematiq.TypedGenerators
{
    using System;
    using System.Configuration;
    using System.Linq;
    using System.Xml;

    internal class CollectionSchemaGenerator : ISchemaGenerator
    {
        private static readonly Type CollectionType = typeof(ConfigurationElementCollection);
        private static readonly Type ConfigurationCollectionAttributeType = typeof(ConfigurationCollectionAttribute);

        public SchemaElementType SchemaElementType => SchemaElementType.Tag;

        public bool CanGenerate(Type elementType)
        {
            return CollectionType.IsAssignableFrom(elementType);
        }

        public void Generate(Type elementType, string elementName, XmlWriter xmlWriter, bool allowMultiple = false)
        {
            var collectionAttribute = elementType.GetCustomAttributes(ConfigurationCollectionAttributeType, true)
                .Cast<ConfigurationCollectionAttribute>()
                .SingleOrDefault();

            if (collectionAttribute == null)
                throw new InvalidOperationException(
                    string.Format("Unable to determine collection element name for type {0}", elementType.Name));

            xmlWriter.WriteStartElement("xs", "element", null);
            xmlWriter.WriteAttributeString("name", elementName);
            xmlWriter.WriteStartElement("xs", "complexType", null);
            xmlWriter.WriteStartElement("xs", "sequence", null);

            var childItemType = collectionAttribute.ItemType;
            var childItemName = collectionAttribute.AddItemName;
            SchemaGeneratorsRegistry.Default.GetSchemaGenerator(childItemType)
                .Generate(childItemType, childItemName, xmlWriter, true);

            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndElement();
        }
    }
}
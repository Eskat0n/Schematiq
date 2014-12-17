namespace Schematiq.TypedGenerators
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Linq;
    using System.Reflection;
    using System.Xml;
    using Extensions;

    internal class ObjectSchemaGenerator : ISchemaGenerator
    {
        private static readonly Type SectionType = typeof (ConfigurationSection);
        private static readonly Type CollectionType = typeof (ConfigurationElementCollection);
        private static readonly Type ElementType = typeof (ConfigurationElement);
        public SchemaElementType SchemaElementType => SchemaElementType.Tag;

        public bool CanGenerate(Type elementType)
        {
            if (CollectionType.IsAssignableFrom(elementType))
                return false;

            return SectionType.IsAssignableFrom(elementType) ||
                   ElementType.IsAssignableFrom(elementType);
        }

        public void Generate(Type elementType, string elementName, XmlWriter xmlWriter, bool allowMultiple = false)
        {
            var schemaGeneratorsRegistry = SchemaGeneratorsRegistry.Default;

            var propertyInfos = elementType.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            var tagPropertyInfos = propertyInfos
                .Where(x => schemaGeneratorsRegistry.IsTag(x.PropertyType));
            var attributePropertyInfos = propertyInfos
                .Where(x => schemaGeneratorsRegistry.IsAttribute(x.PropertyType));

            xmlWriter.WriteStartElement("xs", "element", null);
            xmlWriter.WriteAttributeString("name", elementName);
            if (allowMultiple)
                xmlWriter.WriteAttributeString("maxOccurs", "unbounded");

            xmlWriter.WriteStartElement("xs", "complexType", null);
            xmlWriter.WriteStartElement("xs", "sequence", null);
            Generate(tagPropertyInfos, xmlWriter);
            xmlWriter.WriteEndElement();
            Generate(attributePropertyInfos, xmlWriter);
            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndElement();
        }

        private static void Generate(IEnumerable<PropertyInfo> propertyInfos, XmlWriter xmlWriter)
        {
            foreach (var propertyInfo in propertyInfos)
            {
                var childType = propertyInfo.PropertyType;
                var childElementName = propertyInfo.GetConfigurationPropertyName();
                if (childElementName != null)
                    SchemaGeneratorsRegistry.Default.GetSchemaGenerator(childType)
                        .Generate(childType, childElementName, xmlWriter);
            }
        }
    }
}
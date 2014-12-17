namespace Schematiq.TypedGenerators
{
    using System;
    using System.Collections.Generic;
    using System.Xml;

    public class IntegerSchemaGenerator : ISchemaGenerator
    {
        private static readonly HashSet<Type> IntegerTypes = new HashSet<Type>
        {
            typeof (byte),
            typeof (short),
            typeof (ushort),
            typeof (int),
            typeof (uint),
            typeof (long),
            typeof (ulong),
            typeof (byte?),
            typeof (short?),
            typeof (ushort?),
            typeof (int?),
            typeof (uint?),
            typeof (long?),
            typeof (ulong?)
        };

        public SchemaElementType SchemaElementType => SchemaElementType.Attribute;

        public bool CanGenerate(Type elementType)
        {
            return IntegerTypes.Contains(elementType);
        }

        public void Generate(Type elementType, string elementName, XmlWriter xmlWriter, bool allowMultiple = false)
        {
            xmlWriter.WriteStartElement("xs", "attribute", null);
            xmlWriter.WriteAttributeString("name", elementName);
            xmlWriter.WriteAttributeString("type", "xs:integer");

            xmlWriter.WriteEndElement();
        }
    }
}
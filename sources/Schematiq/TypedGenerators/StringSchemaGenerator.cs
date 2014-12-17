namespace Schematiq.TypedGenerators
{
    using System;
    using System.Xml;

    public class StringSchemaGenerator : ISchemaGenerator
    {
        private static readonly Type StringType = typeof(string);

        public SchemaElementType SchemaElementType => SchemaElementType.Attribute;

        public bool CanGenerate(Type elementType)
        {
            return elementType == StringType;
        }

        public void Generate(Type elementType, string elementName, XmlWriter xmlWriter, bool allowMultiple = false)
        {
            xmlWriter.WriteStartElement("xs", "attribute", null);
            xmlWriter.WriteAttributeString("name", elementName);
            xmlWriter.WriteAttributeString("type", "xs:string");

            xmlWriter.WriteEndElement();
        }
    }
}
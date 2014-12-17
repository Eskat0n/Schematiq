namespace Schematiq.TypedGenerators
{
    using System;
    using System.Xml;

    public class BooleanSchemaGenerator : ISchemaGenerator
    {
        private static readonly Type BooleanType = typeof (bool);
        private static readonly Type NullableBooleanType = typeof (bool?);
        public SchemaElementType SchemaElementType => SchemaElementType.Attribute;

        public bool CanGenerate(Type elementType)
        {
            return elementType == BooleanType ||
                   elementType == NullableBooleanType;
        }

        public void Generate(Type elementType, string elementName, XmlWriter xmlWriter, bool allowMultiple = false)
        {
            xmlWriter.WriteStartElement("xs", "attribute", null);
            xmlWriter.WriteAttributeString("name", elementName);
            xmlWriter.WriteAttributeString("type", "xs:boolean");

            xmlWriter.WriteEndElement();
        }
    }
}
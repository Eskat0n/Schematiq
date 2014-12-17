namespace Schematiq
{
    using System;
    using System.Configuration;
    using System.Text;
    using System.Xml;

    public class XsdGenerator
    {
        private readonly XmlWriterSettings _settings;

        public XsdGenerator()
        {
            _settings = new XmlWriterSettings();
        }

        public XsdGenerator(XmlWriterSettings settings)
        {
            _settings = settings;
        }

        public string Generate(Type rootElementType, string rootElementName)
        {
            var stringBuilder = new StringBuilder();
            using (var xmlWriter = XmlWriter.Create(stringBuilder, _settings))
            {
                xmlWriter.WriteStartElement("xs", "schema", "http://www.w3.org/2001/XMLSchema");

                SchemaGeneratorsRegistry.Default.GetSchemaGenerator(rootElementType)
                    .Generate(rootElementType, "rootElementName", xmlWriter);

                xmlWriter.WriteEndElement();
                xmlWriter.Flush();

                return stringBuilder.ToString();
            }
        }
    }
}

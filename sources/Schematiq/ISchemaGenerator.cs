namespace Schematiq
{
    using System;
    using System.Xml;

    public interface ISchemaGenerator
    {
        /// <summary>
        ///     Returns type of schema element which will be produced by this generator as
        ///     <see cref="Schematiq.SchemaElementType" /> enum member
        /// </summary>
        SchemaElementType SchemaElementType { get; }

        /// <summary>
        ///     Checks whether this generator can produce xsd schema elements for element type specififed in
        ///     <paramref name="elementType" /> parameter
        /// </summary>
        /// <param name="elementType">Element type</param>
        /// <returns></returns>
        bool CanGenerate(Type elementType);

        void Generate(Type elementType, string elementName, XmlWriter xmlWriter, bool allowMultiple = false);
    }
}
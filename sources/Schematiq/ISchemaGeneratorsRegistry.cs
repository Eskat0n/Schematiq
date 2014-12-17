namespace Schematiq
{
    using System;

    public interface ISchemaGeneratorsRegistry
    {
        ISchemaGenerator GetSchemaGenerator(Type elementType);

        bool IsTag(Type elementType);

        bool IsAttribute(Type elementType);
    }
}
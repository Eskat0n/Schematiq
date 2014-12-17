namespace Schematiq
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using TypedGenerators;

    public sealed class SchemaGeneratorsRegistry : ISchemaGeneratorsRegistry
    {
        private static readonly ICollection<ISchemaGenerator> SchemaGenerators
            = new List<ISchemaGenerator>
            {
                new BooleanSchemaGenerator(),
                new IntegerSchemaGenerator(),
                new StringSchemaGenerator(),
                new ObjectSchemaGenerator(),
                new CollectionSchemaGenerator(),
            };

        internal static ISchemaGeneratorsRegistry Default => new SchemaGeneratorsRegistry();

        public static void Register(ISchemaGenerator schemaGenerator)
        {
            SchemaGenerators.Add(schemaGenerator);
        }

        public static void Exclude(ISchemaGenerator schemaGenerator)
        {
            SchemaGenerators.Remove(schemaGenerator);
        }

        public ISchemaGenerator GetSchemaGenerator(Type elementType)
        {
            var schemaGenerator = SchemaGenerators
                .SingleOrDefault(x => x.CanGenerate(elementType));

            if (schemaGenerator == null)
                throw new NotSupportedException(string.Format("Type {0} is not supported", elementType.Name));

            return schemaGenerator;
        }

        public bool IsTag(Type elementType)
        {
            return IsSchemaElementType(elementType, SchemaElementType.Tag);
        }

        public bool IsAttribute(Type elementType)
        {
            return IsSchemaElementType(elementType, SchemaElementType.Attribute);
        }

        private static bool IsSchemaElementType(Type elementType, SchemaElementType schemaElementType)
        {
            return SchemaGenerators
                .Where(x => x.SchemaElementType == schemaElementType)
                .Any(x => x.CanGenerate(elementType));
        }
    }
}
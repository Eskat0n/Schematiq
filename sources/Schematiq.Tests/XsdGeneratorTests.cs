namespace Schematiq.Tests
{
    using System;
    using System.IO;
    using System.Xml;
    using NUnit.Framework;
    using StubConfiguration;

    [TestFixture]
    public class XsdGeneratorTests
    {
        private const string StubSchemaFileName = "StubSchema.xsd";

        [Test]
        public void ShouldGenerateCorrectStubSchema()
        {
            var xsdGenerator = new XsdGenerator(new XmlWriterSettings {Indent = true});

            var actualXsdSchema = xsdGenerator.Generate(typeof(LibrarySection), "library");
            var expectedXsdSchema = File.ReadAllText(StubSchemaFileName);

            Assert.AreEqual(expectedXsdSchema, actualXsdSchema);
        }

        [Test]
        [Category("Live")]
        public void PrintGeneratedStubSchema()
        {
            var xsdGenerator = new XsdGenerator(new XmlWriterSettings {Indent = true});
            var xsdSchema = xsdGenerator.Generate(typeof(LibrarySection), "library");

            Console.WriteLine(xsdSchema);
        }
    }
}
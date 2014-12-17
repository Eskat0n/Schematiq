namespace Schematiq.Tests.StubConfiguration
{
    using System.Configuration;

    public class AuthorElement : ConfigurationElement
    {
        /// <summary>
        /// Название линии
        /// </summary>
        [ConfigurationProperty("name", DefaultValue = "")]
        public string Name
        {
            get { return (string)this["name"]; }
        }

        /// <summary>
        /// Код кармана начала линии
        /// </summary>
        [ConfigurationProperty("unitCode")]
        public long UnitCode
        {
            get { return (long)this["unitCode"]; }
        }

        /// <summary>
        /// Код операции при входе на линию
        /// </summary>
        [ConfigurationProperty("operationCode")]
        public long OperationCode
        {
            get { return (long)this["operationCode"]; }
        }
    }
}

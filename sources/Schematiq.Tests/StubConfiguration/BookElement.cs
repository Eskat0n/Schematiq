namespace Schematiq.Tests.StubConfiguration
{
    using System.Configuration;

    /// <summary>
    /// </summary>
    public class BookElement : ConfigurationElement
    {
        /// <summary>
        /// </summary>
        [ConfigurationProperty("isAvailable", DefaultValue = true)]
        public bool IsAvailable => (bool) base["isAvailable"];

        /// <summary>
        /// </summary>
        [ConfigurationProperty("year", IsRequired = true)]
        public int Year => (int) base["year"];

        /// <summary>
        /// </summary>
        [ConfigurationProperty("title", IsRequired = true)]
        public string Title => (string) base["title"];

        /// <summary>
        /// </summary>
        [ConfigurationProperty("authors")]
        public AuthorElementCollection Authors
            => (AuthorElementCollection) base["authors"];
    }
}
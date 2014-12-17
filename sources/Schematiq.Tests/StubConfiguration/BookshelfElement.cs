namespace Schematiq.Tests.StubConfiguration
{
    using System.Configuration;

    /// <summary>
    /// </summary>
    public class BookshelfElement : ConfigurationElement
    {
        /// <summary>
        /// </summary>
        [ConfigurationProperty("name", IsRequired = true, DefaultValue = "")]
        public string Name => (string) base["name"];

        /// <summary>
        /// </summary>
        [ConfigurationProperty("layout", DefaultValue = "")]
        public string Layout => (string) base["layout"];

        /// <summary>
        /// </summary>
        [ConfigurationProperty("title", DefaultValue = "")]
        public string Title => (string) base["title"];

        /// <summary>
        /// </summary>
        [ConfigurationProperty("code", IsRequired = true, DefaultValue = (long) 0)]
        public long Code => (long) base["code"];

        /// <summary>
        /// </summary>
        [ConfigurationProperty("books")]
        public BookElementCollection Books
            => (BookElementCollection) base["books"];
    }
}
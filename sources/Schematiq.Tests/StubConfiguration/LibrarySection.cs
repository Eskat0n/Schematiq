namespace Schematiq.Tests.StubConfiguration
{
    using System.Configuration;

    /// <summary>
    ///     
    /// </summary>
    public class LibrarySection : ConfigurationSection
    {
        /// <summary>
        ///     
        /// </summary>
        [ConfigurationProperty("bookshelves")]
        public BookshelfElementCollection Bookshelves
            => (BookshelfElementCollection) base["bookshelves"];
    }
}
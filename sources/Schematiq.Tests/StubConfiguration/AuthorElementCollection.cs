namespace Schematiq.Tests.StubConfiguration
{
    using System.Configuration;

    /// <summary>
    /// </summary>
    [ConfigurationCollection(typeof (AuthorElement), AddItemName = "author",
        CollectionType = ConfigurationElementCollectionType.BasicMap)]
    public class AuthorElementCollection : ConfigurationElementCollectionBase<AuthorElement>
    {
        public AuthorElementCollection()
            : base("author", x => x.Name)
        {
        }
    }
}